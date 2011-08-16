/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package ipmsg.etc;

/**
 *
 * @author qqiu
 */
public class GlobalConstant {

    //modified
    public static final int IPMSG_DEFAULT_PORT=0x0C8A;
    public static final int IPMSG_VERSION =0x01;
    /**
     * IPMSG_NOOPERATION     不进行任何操作
     * IPMSG_BR_ENTRY     用户上线
     * IPMSG_BR_EXIT         用户退出
     * IPMSG_ANSENTRY     通报在线
     * IPMSG_SENDMSG         发送消息
     * IPMSG_RECVMSG         通报收到消息
     * IPMSG_GETFILEDATA     请求通过TCP传输文件
     * IPMSG_RELEASEFILES   停止接收文件
     * IPMSG_GETDIRFILES     请求传输文件夹
     */
    
    //空操作
    public static final int IPMSG_NOOPERATION = 0x00000000;
    //登陆
    public static final int IPMSG_BR_ENTRY = 0x00000001;
    //离开
    public static final int IPMSG_BR_EXIT = 0x00000002;
    //登陆的回复
    public static final int IPMSG_ANSENTRY = 0x00000003;
    //离开一会儿
    public static final int IPMSG_BR_ABSENCE = 0x00000004;
    
    /**
     * IPMSG_SENDCHECKOPT   传送检查(需要对方返回确认信息)
     * IPMSG_FILEATTACHOPT   传送文件选项
     */
    
    /**
     * IPMSG_FILE_REGULAR   普通文件
     * IPMSG_FILE_DIR     目录文件
     * IPMSG_FILE_RETPARENT   返回上一级目录
     */
    public static final int IPMSG_BR_ISGETLIST = 0x00000018;
    public static final int IPMSG_OKGETLIST = 0x00000015;
    public static final int IPMSG_GETLIST = 0x00000016;
    public static final int IPMSG_ANSLIST = 0x00000017;
    
    public static final int IPMSG_SENDMSG = 0x00000020;
    public static final int IPMSG_RECVMSG = 0x00000021;
    
    public static final int IPMSG_READMSG = 0x00000030;
    public static final int IPMSG_DELMSG = 0x00000031;
    
    public static final int IPMSG_GETINFO = 0x00000040;
    public static final int IPMSG_SENDINFO = 0x00000041;
    
    //文件传输
    public static final int IPMSG_GETFILEDATA=0x00000060;
    public static final int IPMSG_RELEASEFILES=0x00000061;//取消文件传输
    public static final int IPMSG_GETDIRFILES=0x00000062;
    
    //other opt
    public static final int IPMSG_ABSENCEOPT = 0x00000100;
    public static final int IPMSG_SERVEROPT = 0x00000200;
    public static final int IPMSG_DIALUPOPT = 0x00010000;
    public static final int IPMSG_FILEATTACHOPT=0x00200000;
    
    //发送消息需要回复
    public static final int IPMSG_SENDCHECKOPT = 0x00000100;
    public static final int IPMSG_SECRETOPT = 0x00000200;
    public static final int IPMSG_BROADCASTOPT = 0x00000400;
    public static final int IPMSG_MULTICASTOPT = 0x00000800;
    public static final int IPMSG_NOPOPUPOPT = 0x00001000;
    public static final int IPMSG_AUTORETOPT = 0x00002000;
    public static final int IPMSG_RETRYOPT = 0x00004000;
    public static final int IPMSG_PASSWORDOPT = 0x00008000;
    public static final int IPMSG_NOLOGOPT = 0x00020000;
    public static final int IPMSG_NEWMUTIOPT = 0x00040000;
    
    //文件类型
    public static final int IPMSG_FILE_REGULAR = 0x00000001;
    public static final int IPMSG_FILE_DIR = 0x00000002;
    public static final int IPMSG_FILE_RETPARENT = 0x00000003;
    
//    public static final int MAXBUF = 8192; 
    public static final int DEFAULT_F_LENGTH = 8092;

    public static final int COMMAND_LEN=1500;
    public static final int MSG_LEN=1000;
    public static final short NAMELEN=50;
    
    
    /**
     * 默认的配置文件夹保存目录。（.LanMsg）
     */
    public static final String DEFAULT_CONFIG_DIR=".LanMsg_ipMsg";
    /**
     * 默认的配置文件名称。（LanMsg.conf）
     */
    public static final String DEFAULT_CONFIG_FILE="LanMsg.conf";
    /**
     * 默认的黑名单保存文件名称。（BlackList.conf)
     */
    public static final String DEFAULT_BLACKLIST_FILE="BlackList.conf";
    /**
     * 用户添加的联系人保存文件名称。（ExtraContact.conf)
     */
    public static final String DEFAULT_CONTACT_FILE="ManualAddUser.conf";
    /**
     * 文件名前缀
     */
    public static final String DEFAULT_FILE_PREFIX="[LanMsg]";
    
    /**
     * 操作系统常量
     */
    static final public char LINUX=0;
    static final public char WINDOWS=1;
    static final public char OTHER_OS=2;
    
    //发送消息方式
    public static final char CTRL_ENTER=0;
    public static final char ENTER=1;
    
    //字符编码
    public static final char GB2312=0;
    public static final char UTF8=1;
    public static final char SHIFT_JIS=2;
    
    //主题类型
    public static final char JAVA=0;
    public static final char OS_BASED=1;
    
    /**
     * 消息队列最大容量
     */
    static final public int COMMAND_QUEUE_MAX=100;
    
    public static int GET_MODE(int flag){
        return flag& 0x000000ff;
    }
    public static int GET_OPT(int flag){
        return flag& 0xffffff00;
    }
}
