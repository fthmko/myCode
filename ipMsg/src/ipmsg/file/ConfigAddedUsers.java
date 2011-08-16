/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package ipmsg.file;

import ipmsg.etc.GlobalConstant;
import ipmsg.etc.UtilityGlobal;
import ipmsg.etc.GlobalVar;

/**
 *
 * @author qqiu
 */
public class ConfigAddedUsers {
    
    static String path ;
    
    /**
     * 初始化需要
     */
    
    public static void readConfig(){
        try {
            path = GlobalVar.USER_HOME + GlobalVar.FILE_PATH_DELIMITER + 
                    GlobalConstant.DEFAULT_CONFIG_DIR + 
                    GlobalVar.FILE_PATH_DELIMITER + 
                    GlobalConstant.DEFAULT_CONTACT_FILE;

            ConfigOperation config = new ConfigOperation(path);

            String manualAddUser = config.getValue("addedUsers");
            //如果为空
            if (manualAddUser == null || manualAddUser.equals("")) {
                return;
            }
            //分成若干个ip
            String[] manualAddUsers = manualAddUser.split(";");

            //写入全局变量
            for (int i = manualAddUsers.length - 1; i >= 0; i--) {
                if (UtilityGlobal.isIP(manualAddUsers[i])) {
                    GlobalVar.ADDED_USER.add(manualAddUsers[i]);
                }
            }
        } catch (ConfigurationException ex) {
            errorHappen();
        }
        
    }
    
    public static void writeConfig(){
        
        try {
            ConfigOperation config = new ConfigOperation(path);
            
            StringBuffer sb=new StringBuffer();
            
            for(int i=GlobalVar.ADDED_USER.size()-1;i>0;i--)
                sb.append(GlobalVar.ADDED_USER.get(i)+";");
            
            if(GlobalVar.ADDED_USER.size()>0)
                sb.append(GlobalVar.ADDED_USER.get(0));
            
            config.setValue("addedUsers", sb.toString());
            config.saveFile();
            
        } catch (ConfigurationException ex) {
            //捕获我们自定义的异常
            ex.printStackTrace();
        }
    }
    
    private static void errorHappen(){
        //刷新配置文件
        UtilityConfig.creatFile(path, UtilityConfig.file);
    }

}
