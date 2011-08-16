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
public class ConfigBlacklist {
    static String path ;
    
    /**
     * 初始化需要
     */
    
    public static void readConfig(){
        try {
            path = GlobalVar.USER_HOME + GlobalVar.FILE_PATH_DELIMITER + 
                    GlobalConstant.DEFAULT_CONFIG_DIR + 
                    GlobalVar.FILE_PATH_DELIMITER + 
                    GlobalConstant.DEFAULT_BLACKLIST_FILE;

            ConfigOperation config = new ConfigOperation(path);

            String blacklist = config.getValue("blacklist");
            //如果为空
            if (blacklist == null || blacklist.equals("")) {
                return;
            }
            //分成若干个ip
            String[] blacklists = blacklist.split(";");

            //写入全局变量
            for (int i = blacklists.length - 1; i >= 0; i--) {
                if (UtilityGlobal.isIP(blacklists[i])) {
                    GlobalVar.BLACK_LIST.add(blacklists[i]);
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
            
            for(int i=GlobalVar.BLACK_LIST.size()-1;i>0;i--)
                sb.append(GlobalVar.BLACK_LIST.get(i)+";");
            
            if(GlobalVar.BLACK_LIST.size()>0)
                sb.append(GlobalVar.BLACK_LIST.get(0));
            
            config.setValue("blacklist", sb.toString());
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
