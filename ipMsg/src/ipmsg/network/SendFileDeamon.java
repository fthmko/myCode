/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package ipmsg.network;

import ipmsg.etc.FileLinkList;
import ipmsg.etc.FileNode;
import ipmsg.etc.GlobalConstant;
import ipmsg.etc.GlobalVar;
import ipmsg.etc.UtilityGlobal;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.Socket;
import java.net.SocketException;

/**
 *
 * @author Noeru
 */
public class SendFileDeamon extends Thread {
    
    private Socket socket;
    private DataOutputStream outputStream;
    private DataInputStream inputStream;
    
    public SendFileDeamon(Socket socket){
        this.socket=socket;
    }
    
    @Override
    public void run(){
        String str;
        int offset,packetNo;
        int fileKind=-1;
        
        try {
            this.inputStream = new DataInputStream(
                    new BufferedInputStream(
                    this.socket.getInputStream()));
            this.outputStream = new DataOutputStream(
                    socket.getOutputStream());
        } catch (IOException ex) {
            this.exit();
            return;
        }
        
        for (offset = 0; offset < 4; offset++) {
            if (UtilityNet.readDelimiter(inputStream, 100) == null) {
                this.exit();
                return;
            }
        }
        
        //操作码
        str = UtilityNet.readDelimiter(inputStream, 100);
        if (str == null){
            this.exit();
            return;
        }
        try {
            packetNo = Integer.parseInt(str);
        } catch (NumberFormatException e){
            this.exit();
            return;
        }
        
        //操作码判断
        if ((packetNo & GlobalConstant.IPMSG_GETDIRFILES) == 
                GlobalConstant.IPMSG_GETDIRFILES) {
            fileKind=GlobalConstant.IPMSG_FILE_DIR;
        } else if ((packetNo & GlobalConstant.IPMSG_GETFILEDATA) ==
                GlobalConstant.IPMSG_GETFILEDATA) {
            fileKind=GlobalConstant.IPMSG_FILE_REGULAR;
        } else {
            this.exit();
            return;
        }
        
        //包编号
        str = UtilityNet.readDelimiter(inputStream, 100);
        if (str == null){
            this.exit();
            return;
        }
        try {
            packetNo = Integer.parseInt(str, 16);
//            System.out.println("file packetNo : " + packetNo);
        } catch (NumberFormatException e){
            this.exit();
            return;
        }
        
        //文件偏移量（编号）
        str = UtilityNet.readDelimiter(inputStream, 100);
        if (str == null){
            this.exit();
            return;
        }
        try {
            offset = Integer.parseInt(str, 16);
//            System.out.println("offset : " + offset);
        } catch (NumberFormatException e){
            this.exit();
            return;
        }
        //貌似飞鸽根本就没有发送改域，尽管协议里面有说说明
        /*文件内部偏移量（未用）
        System.out.println("off3");
        if (UtilityNet.readDelimiter(inputStream, 100) == null){
            this.exit();
            System.out.println("offset1");
            return;
        }*/
        
        
        FileLinkList flist=GlobalVar.getFileList(packetNo);
        if(flist==null||flist.isActive()){
            this.exit();
            return;
        }
        
        //接收方不匹配
//        System.out.println(this.socket.getInetAddress().getHostAddress());
        if(!this.socket.getInetAddress().getHostAddress().equals(
                flist.getIp())){
            this.exit();
            return;
        }
        
        //文件不存在或者被使用
        FileNode fnode=flist.getFiles().get(offset);
        if(fnode==null||fnode.isIsTransfered()){
            this.exit();
            return;
        }
        
        
        //文不对题
        if(fnode.getFileKind()!=fileKind){
            this.exit();
            return;
        }
        
        flist.setActive(true);
        switch(fileKind){
            case GlobalConstant.IPMSG_FILE_DIR:
//                System.out.println("发送目录");
                this.sendDir(flist, fnode);
                break;
            case GlobalConstant.IPMSG_FILE_REGULAR:
//                System.out.println("发送文件");
                this.sendFile(flist,fnode);
                break;
            default :
                this.exit();
        }
    }
    
    //发送目录
    private void sendDir(FileLinkList flist,FileNode fnode){
//        System.out.println("进入目录"+fnode.getFileName());
        if(this.sendDir(new File(fnode.getFileName()))){
            fnode.setIsTransfered(true);
            flist.setActive(false);
            if(flist.isTanstered()){
                GlobalVar.delFileList(flist.getPacketNo());
            }
        }else flist.setActive(false);
        
    }    
    private boolean sendDir(File file) {
        if(file==null||
                (!file.isDirectory()&&!file.isFile()))return false;
//        if(file.isDirectory())System.out.println("发送目录 ： "+file.getPath());
//        else System.out.println("发送文件 ： "+file.getPath());
        if(!this.sendSubDir(file))return false;
        
        if(file.isDirectory()){
            File[]subdir=file.listFiles();
            int i,count=subdir.length;
            for(i=0;i<count;i++)
                if(!this.sendDir(subdir[i]))return false;
            if(!this.sendSubDir(null))return false;
        }
        return true;
    }
    private boolean sendSubDir(File file){
        try {
            this.outputStream.write(
                    this.createHeader(file).getBytes(GlobalVar.CHARACTER_ENCODING));
            if (file!=null&&file.isFile()) {
                if(!this.sendFile(file.getPath()))return false;
            }
            return true;
        } catch (IOException ex) {
            return false;
        }
    }
    private String createHeader(File file) {
        String res;
        if (file == null) {
            res = ":.:0:" +
                    Integer.toHexString(GlobalConstant.IPMSG_FILE_RETPARENT) +
//                    "00000003" +
                    ":0:";
        } else {
            res = ":" + file.getName() + ":" +
                    Long.toHexString(file.length()) + ":" +
//                     "000000000:" +
                    (file.isDirectory() ? 
                        Integer.toHexString(GlobalConstant.IPMSG_FILE_DIR) : 
                        Integer.toHexString(GlobalConstant.IPMSG_FILE_REGULAR))
                        +":0:";
        }
        try {
            return UtilityGlobal.dec2Hex(
                    res.getBytes(GlobalVar.CHARACTER_ENCODING).length + 8)+res;
        } catch (UnsupportedEncodingException ex) {
            return null;
        }
    }
    
    //发送文件
    private void sendFile(FileLinkList flist,FileNode fnode) {
        if(this.sendFile(fnode.getFileName())){
            fnode.setIsTransfered(true);
            flist.setActive(false);
            if(flist.isTanstered()){
                GlobalVar.delFileList(flist.getPacketNo());
            }
        }else flist.setActive(false);
    }
    private boolean sendFile(String filePath){
        try {
            
            DataInputStream fis = new DataInputStream(
                        new BufferedInputStream(
                        new FileInputStream(filePath)));
            
            byte[] buf = new byte[GlobalConstant.DEFAULT_F_LENGTH];

            int read = 0;
            while (true) {
                if (fis != null) {
                    read = fis.read(buf);
                }
                if (read == -1) {
                    break;
                }
                this.outputStream.write(buf, 0, read);
            }
            this.outputStream.flush();
            fis.close();
            return true;
            
        } catch (SocketException e) {
            return false;
        } catch (IOException e){
            return false;
        }
        
    }
    
    private void exit(){
        try {
            this.inputStream.close();
            this.outputStream.close();
            this.socket.close();
        } catch (IOException ex) {
        }
    }

}
