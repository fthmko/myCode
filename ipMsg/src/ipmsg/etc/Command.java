/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package ipmsg.etc;

import java.io.UnsupportedEncodingException;
import java.util.Date;

/**
 *
 * @author qqiu
 */
public class Command {
    
    private int version;
    private int flag;
    private int packetNo;
    private String senderName=null;
    private String senderHost=null;
    private String additional=null;
    private String ip=null;


    public Command(){
    }
    
    public Command(int flag) {
        this.flag=flag;
        this.packetNo=(int) new Date().getTime();
        this.version=GlobalConstant.IPMSG_VERSION;
        this.senderName=GlobalVar.USER_NAME;
        this.senderHost=GlobalVar.HOST_NAME;
    }


    public String getIp() {
        return this.ip;
    }
    //get方法
    public int getFlag() {
        return this.flag;
    }
    
    public String getAdditional() {
        return this.additional;
    }

    public int getPacketNo() {
        return this.packetNo;
    }

    public String getSenderHost() {
        return this.senderHost;
    }

    public String getSenderName() {
        return this.senderName;
    }

    public int getVersion() {
        return this.version;
    }

    

    
    
    /**
     * 超过长度限制将返回false
     * @param additional
     * @return
     */
    public boolean setAdditional(String additional) {
        if(additional==null||
                additional.equals("")||
                additional.length()>GlobalConstant.MSG_LEN){
            this.additional=null;
            return false;
        }
        this.additional = additional;
        return true;
    }


    public boolean setSenderHost(String senderHost) {
        if(senderHost==null||
                senderHost.equals("")||
                senderHost.length()>GlobalConstant.NAMELEN){
            this.senderHost=null;
            return false;
        }
        this.senderHost = senderHost;
        return true;
    }

    public boolean setSenderName(String senderName) {
        if(senderName==null||
                senderName.equals("")||
                senderName.length()>GlobalConstant.NAMELEN){
            this.senderName=null;
            return false;
        }
        this.senderName = senderName;
        return true;
    }

    /**
     * 初始化版本信息
     * @param version
     */
    public void setVersion(int version) {
        this.version = version;
    }
    public void setVersion(String version){
        this.setVersion(UtilityGlobal.atoi(version));
    }
    /*public boolean setVersion(String version){
        try {
            this.setVersion(Integer.parseInt(version));
            return true;

        } catch (NumberFormatException e) {
            return false;
        }
    }*/
    
    /**
     * 设置包编号
     * @param packetNo
     */
    public void setPacketNo(int packetNo) {
        this.packetNo = packetNo;
    }
    public boolean setPacketNo(String packetNo){
        try {
            this.setPacketNo(Integer.parseInt(packetNo));
            return true;
        } catch (NumberFormatException e) {
            return false;
        }
    }
    
    /**
     * 设置flag
     * @param flag
     */
    public void setFlag(int flag) {
        this.flag |= flag;
    }
    public void resetFlag(int flag){
        this.flag=flag;
    }
    public boolean setFlag(String flag){
        try {
            this.setFlag(Integer.parseInt(flag));
            return true;
        } catch (NumberFormatException e) {
            return false;
        }
    }
    
    //设置ip
    public boolean setIp(String ip) {
        if(UtilityGlobal.isIP(ip)){
            this.ip = ip;
            return true;
        }
        return false;
    }
   
    /**
     * 输出为buf
     * @return
     */
    public byte[] exportToBuf(){
        try {
            
            return (this.version + ":" +
                    this.packetNo + ":" +
                    this.senderName.replaceAll(":", "_") + ":" +
                    this.senderHost.replaceAll(":", "_") + ":" +
                    this.flag + ":" +
                    this.additional+'\0').getBytes(GlobalVar.CHARACTER_ENCODING);
//            this.additional+'\0').getBytes();

        } catch (UnsupportedEncodingException ex) {
            return null;
        }
        
    }
    
    /**
     * 根据buf生成Command
     * @param buf
     * @return
     */
    public static Command createCommand(byte[] buf,String ip){
        if(buf==null||ip==null)return null;

        //设置编码
        String tmpCom;
        
        try {
            tmpCom = new String(buf, GlobalVar.CHARACTER_ENCODING);
        } catch (UnsupportedEncodingException ex) {
            return null;
        }
        
        Command com=new Command();
        
        //临时变量
        int prePos=0,pos=0,count;
        String tmpStr;
        
        for(int i=0;i<5;){
            count=1;
            if((pos=tmpCom.indexOf(":", pos))<0)return null;
            while(tmpCom.charAt(++pos)==':')count++;
            if(count%2==0)continue;
            
            tmpStr=tmpCom.substring(prePos, pos-1);
            switch(i){
                case 0:
                    //if(!com.setVersion(tmpStr))return null;
                    com.setVersion(tmpStr);
                    break;
                case 1:
                    if(!com.setPacketNo(tmpStr))return null;
                    break;
                case 2:
                    if(!com.setSenderName(tmpStr))return null;
                    break;
                case 3:
                    if(!com.setSenderHost(tmpStr))return null;
                    break;
                case 4:
                    if(!com.setFlag(tmpStr))return null;
                    break;
                default : return null;
            }
            prePos=pos;
            i++;
        }
        if(!com.setAdditional(tmpCom.substring(pos)))return null;
        com.ip=ip;
        return com;
    }
    
    
    
    public void show(){
        System.out.println("开始");
        System.out.println("version : "+this.getVersion());
        System.out.println("user : "+ this.getSenderName());
        System.out.println("host : "+ this.getSenderHost());
        System.out.println("addtional : "+this.getAdditional());
        System.out.println("ip : "+this.getIp());
    }
}
