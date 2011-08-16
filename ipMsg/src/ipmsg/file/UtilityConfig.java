/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package ipmsg.file;

import java.io.File;
import java.io.IOException;

/**
 *
 * @author qqiu
 */
public class UtilityConfig {
    
    static final public char file=0;
    static final public char dir=1;
    static final public char neither=2;
    
    /**
     * 返回文件的类型
     * @param path 文件路径
     * @return  返回文件的类型
     */
    private static char getFileKind(String path){
   
        File fr = new File(path);
        if(fr==null)return neither;
      
        if (fr.isFile()) {
            return file;
        } else if (fr.isDirectory()) {
            return dir;
        } else {
            return neither;
        }
    }
    
    /**
     * 删除文件
     * @param path 文件路径
     */
    public static void delFile(String path){
        if(getFileKind(path)!=neither)
            new File(path).delete();
    }
    

    /**
     * 删除指定文件，如果该文件不是指定类型。
     * @param path 文件路径
     * @param fileKind 文件类型
     * @return 执行该操作后，如果不存在指定路径的文件，则返回true，否则返回false
     
    public static boolean delFile(String path,char fileKind){
        if(getFileKind(path)==neither)return true;
        if(getFileKind(path)!=fileKind){
            delFile(path);
            return true;
        }
        return false;
    }*/
    
    /**
     * 新建文件，如果指定文件存在，对于文件将先删除后新建，目录不变。
     * @param path 文件路径
     * @param fileKind 文件类型。
     */
    public static void creatFile(String path,char fileKind){
        if(fileKind==neither)return;
        if(fileKind==dir&&getFileKind(path)==dir)return;
        
        delFile(path); 
        
        try {
            if (fileKind == file) {
                new File(path).createNewFile();
                
            }else if(fileKind==dir){
                new File(path).mkdir();
            }
        } catch (IOException ex) {
            ex.printStackTrace();
        }
        
    }
    
}
