/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package ipmsg.etc;

import java.io.File;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.Vector;

/**
 *
 * @author Noeru
 */
public class FileLinkList {
    private String ip;
    private int packetNo;
    private boolean active=false;

    public void setActive(boolean active) {
        this.active = active;
    }

    public boolean isActive() {
        return active;
    }
    private ArrayList<FileNode>files=new ArrayList<FileNode>();

    public String getIp() {
        return ip;
    }

    public void setIp(String ip) {
        this.ip = ip;
    }

    public void setPacketNo(int packetNo) {
        this.packetNo = packetNo;
    }

    public int getPacketNo() {
        return packetNo;
    }

    public ArrayList<FileNode> getFiles() {
        return files;
    }
    
    public boolean isTanstered(){
        boolean res=true;
        Iterator it=this.files.iterator();
        while(it.hasNext()) {
            FileNode obj = (FileNode) it.next();
            if(!obj.isIsTransfered()){
                res=false;
                break;
            }
        }
        return res;
    }

    public Vector<String>exportFileList(){
        int count=0;
        Vector<String>tmp=new Vector<String>();
        Iterator it=this.files.iterator();
        while(it.hasNext()) {
            FileNode obj = (FileNode) it.next();
            if(!obj.isIsTransfered())
                tmp.add(count+" . "+obj.getFileName());
            count++;
        }
        return tmp;
    }
    
    public String exportPacket(){
        StringBuffer sb=new StringBuffer();
        Iterator it=this.getFiles().iterator();
        while(it.hasNext()){
            FileNode obj = (FileNode) it.next();
            sb.append(Integer.toHexString(obj.getFileNo())+":"+
                    new File(obj.getFileName()).getName()+":"+
                    Long.toHexString(obj.getFileLen())+":"+
                    0+":"+
                    Integer.toHexString(obj.getFileKind())+":"+(char)0x07);
        }
        return sb.toString();
    }
    
    public static FileLinkList createFileLinkList(String str,String ip,int packetNo){
//        System.out.println("str : "+str);
        FileLinkList res=new FileLinkList();
        FileNode node;
        res.ip=ip;
        res.packetNo=packetNo;

        int prePos , pos , count,i;
        String tmpStr;
        
        while(true){

            prePos =pos = 0;
            node=new FileNode();
            for (i = 0; i < 5;) {
                count = 1;
                if ((pos = str.indexOf(":", pos)) < 0) {
                    return null;
                }
                while (str.charAt(++pos) == ':') {
                    count++;
                }
                if (count % 2 == 0) {
                    continue;
                }
                tmpStr = str.substring(prePos, pos - 1);
                switch (i) {
                    case 0:
                        if (!node.setFileNo(tmpStr)) {
                            return null;
                        }
                        break;
                    case 1:node.setFileName(tmpStr);
                        break;
                    case 2:
                        if (!node.setFileLen(tmpStr)) {
                            return null;
                        }
                        break;
                    case 3:
                        node.setTime(tmpStr);
                        break;
                    case 4:
                        if (!node.setFileKind(tmpStr)) {
                            return null;
                        }
                        break;
                    default:
                        return null;
                }
                prePos = pos;
                i++;
            }
            res.files.add(node);
            
            pos = str.indexOf((char)0x07, pos);
            str=str.substring(pos+1);
//            System.out.println("Str : "+ str);
            if(str.indexOf((char)0x07)<0)break;
        }
        return res;
    }
    
    public void show(){
        System.out.println("ip : "+this.ip);
        for(int i=0;i<this.files.size();i++){
            if (this.files.get(i) != null) {
                System.out.println("序列号 ： " + this.files.get(i).getFileNo());
                System.out.println("文件名 : " + this.files.get(i).getFileName());
                System.out.println("长度 : " + this.files.get(i).getFileLen());
                System.out.println("类型 : " + this.files.get(i).getFileKind());
            }
        }
    }

}
