/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package ipmsg.etc;

/**
 *
 * @author Noeru
 */
public class FileNode {
    private int fileNo;
    private String fileName;
    private long fileLen;
    private int fileKind;
    private String time;
    private boolean isTransfered=false;

    public boolean isIsTransfered() {
        return isTransfered;
    }
    
    public void setIsTransfered(boolean isTransfered) {
        this.isTransfered = isTransfered;
    }

    public boolean setFileKind(int fileKind) {
        if(fileKind==GlobalConstant.IPMSG_FILE_REGULAR||
                fileKind==GlobalConstant.IPMSG_FILE_DIR||
                fileKind==GlobalConstant.IPMSG_FILE_RETPARENT){
            this.fileKind=fileKind;
            return true;
        }return false;
    }
    public boolean setFileKind(String fileKind) {
        try {
            return this.setFileKind(Integer.parseInt(fileKind,16));
//            Integer.
            //return this.setFileKind(Integer.toHexstring(fileKind));
        } catch (NumberFormatException e) {
            return false;
        }
    }

    public void setFileLen(long fileLen) {
        this.fileLen = fileLen;
    }
    public boolean setFileLen(String fileLen) {
        try {
            this.setFileLen(Integer.parseInt(fileLen,16));
            return true;
        } catch (NumberFormatException e) {
            return false;
        }
    }

    public void setFileName(String fileName) {
        if(fileName.length()>=GlobalConstant.NAMELEN*4)
            fileName=fileName.substring(0, GlobalConstant.NAMELEN*4);
        this.fileName = fileName;
    }

    public void setFileNo(int fileNo) {
        this.fileNo = fileNo;
    }
    public boolean setFileNo(String fileNo) {
        try {
            this.setFileNo(Integer.parseInt(fileNo,16));
            return true;
        } catch (NumberFormatException e) {
            return false;
        }
    }

    public void setTime(String time) {
        this.time = time;
    }

    public int getFileKind() {
        return fileKind;
    }

    public long getFileLen() {
        return fileLen;
    }

    public String getFileName() {
        return fileName;
    }

    public int getFileNo() {
        return fileNo;
    }

    public String getTime() {
        return time;
    }
    
    public void show(){
        System.out.println("文件名 ："+this.fileName);
        System.out.println("文件长度 ： "+this.fileLen);
        System.out.println("文件类型 : "+this.fileKind);
    }

}
