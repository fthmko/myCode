/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package ipmsg.file;

import ipmsg.etc.GlobalConstant;
import ipmsg.etc.GlobalVar;

/**
 *
 * @author qqiu
 */
public class Configuration {
    /**
     * 需要保存的变量包括：
     * 用户昵称
     * 主机名称
     * 发送消息方式
     * 编码方式
     * 主题类型
     * 日志长度限制
     */
    
    
    static String path ;
    
    /**
     * 初始化需要
     */
    
    public static void readConfig(){
        path = GlobalVar.USER_HOME + GlobalVar.FILE_PATH_DELIMITER +
                GlobalConstant.DEFAULT_CONFIG_DIR + 
                GlobalVar.FILE_PATH_DELIMITER+
                GlobalConstant.DEFAULT_CONFIG_FILE;
        try {
            ConfigOperation config = new ConfigOperation(path);
  
            GlobalVar.USER_NAME=config.getValue("userName");
            GlobalVar.HOST_GROUP=config.getValue("hostGroup");
            GlobalVar.HOST_NAME=config.getValue("hostName");
            GlobalVar.SEND_MSG_STYLE=(char)new Integer(
                    config.getValue("sendMsgStyle")).intValue();
            GlobalVar.CHARACTER_ENCODING=config.getValue("character_encoding");
                    /*(char)new Integer(
                    config.getValue("character_encoding")).intValue();*/
            GlobalVar.THEME=(char)new Integer(
                    config.getValue("theme")).intValue();
            GlobalVar.LOG_MAX_LEN=new Integer(
                    config.getValue("logMaxLen")).intValue();
        } catch (NumberFormatException e){
            errorHappen();
        } catch (ConfigurationException e){
            errorHappen();
        }
        
    }
    
    public static void writeConfig(){
        
        try {
            ConfigOperation config = new ConfigOperation(path);
            
            config.setValue("userName", GlobalVar.USER_NAME);
            config.setValue("hostGroup", GlobalVar.HOST_GROUP);
            config.setValue("hostName", GlobalVar.HOST_NAME);
            config.setValue("sendMsgStyle", (int)GlobalVar.SEND_MSG_STYLE+"");
            config.setValue("character_encoding", GlobalVar.CHARACTER_ENCODING);
            config.setValue("theme", (int)GlobalVar.THEME+"");
            config.setValue("logMaxLen", GlobalVar.LOG_MAX_LEN+"");
            config.saveFile();
            
        } catch (ConfigurationException ex) {
            //捕获我们自定义的异常
            ex.printStackTrace();
        }
    }
    
    private static void errorHappen(){
        GlobalVar.initDefault();
        
        //新建配置主目录
        UtilityConfig.creatFile(GlobalVar.USER_HOME + 
                GlobalVar.FILE_PATH_DELIMITER +
                GlobalConstant.DEFAULT_CONFIG_DIR, 
                UtilityConfig.dir);

        //刷新配置文件
        UtilityConfig.creatFile(path, UtilityConfig.file);
    }

}
