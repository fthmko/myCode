/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package ipmsg.etc;

import ipmsg.file.ConfigAddedUsers;
import ipmsg.file.ConfigBlacklist;
import ipmsg.file.Configuration;
import ipmsg.gui.MsgWindow;
import ipmsg.network.UtilityNet;
import java.net.InetAddress;
import java.net.UnknownHostException;
import java.util.HashMap;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.Vector;
import java.util.concurrent.Semaphore;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;

/**
 *
 * @author qqiu
 */
public class GlobalVar {

    /**
     * 可变变量
     */
    public static String USER_NAME;//用户名
    public static String HOST_NAME;//主机名
    public static String HOST_GROUP;//工作组名
    public static char SEND_MSG_STYLE;
    public static String CHARACTER_ENCODING;
    public static char THEME;
    public static int LOG_MAX_LEN;
    /**
     * 不可变变量
     */
    //public static boolean UTF8;//系统编码类型
    public static String SYS_NAME = "飞鸽传书";
    public static String USER_HOME;//用户主目录
    public static String NEW_LINE;//换行符
    public static String FILE_PATH_DELIMITER; //文件系统分隔符
    public static char OS; //操作系统类型
    //本地ip列表
    public static Vector<String> ALL_IP_ADDRESS = new Vector<String>();
    /**
     * 信号量
     */
    public static Semaphore COMMAND_QUEUE_EMPTY =
            new Semaphore(GlobalConstant.COMMAND_QUEUE_MAX);
    public static Semaphore COMMAND_QUEUE_fULL = new Semaphore(0);

    public static void init() {
        initSystemVar();
        Configuration.readConfig();
        ConfigBlacklist.readConfig();
        ConfigAddedUsers.readConfig();
    }

    /**
     * 声明系统参数，对于可修改参数，使用系统默认参数。
     */
    public static void initDefault() {
        USER_NAME = System.getProperty("user.name");
        HOST_GROUP = "LanMsg";
        try {
            if (OS == GlobalConstant.WINDOWS) {
                HOST_NAME = InetAddress.getLocalHost().getCanonicalHostName();
            } else {
                HOST_NAME = InetAddress.getLocalHost().getHostName();
            }
        } catch (UnknownHostException ex) {
        }
        SEND_MSG_STYLE = GlobalConstant.CTRL_ENTER;
        CHARACTER_ENCODING = "GB2312";
        THEME = GlobalConstant.JAVA;
        LOG_MAX_LEN = 1000;
    }

    /**
     * 初始化一些不能更改的系统参数
     */
    private static void initSystemVar() {

        //用户主目录
        USER_HOME = System.getProperty("user.home");
        //换行分隔符
        NEW_LINE = System.getProperty("line.separator");
        //文件路径分隔符
        FILE_PATH_DELIMITER = System.getProperty("file.separator");
        //操作系统类型
        if (System.getProperty("os.name").equalsIgnoreCase("linux")) {
            OS = GlobalConstant.LINUX;
        } else if (System.getProperty("os.name").startsWith("Windows")) {
            OS = GlobalConstant.WINDOWS;
        } else {
            OS = GlobalConstant.OTHER_OS;
        }
        //获取系统ip
        UtilityNet.getMyIps();
    }
    //************************************************************************
    /**
     * 报文缓冲池
     */
    private static LinkedList<Command> COMMAND_QUEUE = new LinkedList<Command>();
    private final static Lock COMMAND_QUEUE_Lock = new ReentrantLock();

    public static void pushCommand(Command com) {
        COMMAND_QUEUE_Lock.lock();
        COMMAND_QUEUE.add(com);
        COMMAND_QUEUE_Lock.unlock();

    }

    public static Command popCommand() {
        COMMAND_QUEUE_Lock.lock();
        Command com = COMMAND_QUEUE.removeFirst();
        COMMAND_QUEUE_Lock.unlock();
        return com;
    }
    //***********************************************************************
    /**
     * 用户列表
     */
    private static LinkedList<User> USER_LIST = new LinkedList<User>();
    private final static Lock USER_LIST_Lock = new ReentrantLock();

    public static void addUser(String ip, String name, String group, String host) {
        USER_LIST_Lock.lock();
        User usr;
        //如果不存在则添加
        if ((usr = getUser(ip)) == null) {
            GlobalVar.USER_LIST.add(new User(ip, name, group, host));
        } else {
            usr.setName(name);
            usr.setGroup(group);
            usr.setHost(host);
        }
        USER_LIST_Lock.unlock();
    }

    public static void delUser(String ip) {

        USER_LIST_Lock.lock();
        Iterator it = GlobalVar.USER_LIST.iterator();
        while (it.hasNext()) {
            User obj = (User) it.next();
            if (obj.getIp().equals(ip)) {
                it.remove();
            }
        }
        USER_LIST_Lock.unlock();
    }

    public static User getUser(String ip) {
        USER_LIST_Lock.lock();
        User res = null;
        Iterator it = GlobalVar.USER_LIST.iterator();
        while (it.hasNext()) {
            User obj = (User) it.next();
            if (obj.getIp().equals(ip)) {
                res = obj;
                break;
            }
        }
        USER_LIST_Lock.unlock();
        return res;
    }

    public static Vector getUserList() {
        USER_LIST_Lock.lock();
        Vector<String> res = new Vector<String>();
        Iterator it = GlobalVar.USER_LIST.iterator();
        while (it.hasNext()) {
            User obj = (User) it.next();
            res.add(obj.getIp());
        }
        USER_LIST_Lock.unlock();
        return res;
    }

    public static void clearUsers() {
        USER_LIST_Lock.lock();
        GlobalVar.USER_LIST.clear();
        USER_LIST_Lock.unlock();
    }
    //************************************************************************
    /**
     * GUI聊天窗口界面的注册
     */
    private static HashMap<String, MsgWindow> MSG_WINDOW_REG =
            new HashMap<String, MsgWindow>();
    private final static Lock MSG_WINDOW_REG_Lock = new ReentrantLock();

    public static void addWindow(String id, MsgWindow win) {
        MSG_WINDOW_REG_Lock.lock();
        MSG_WINDOW_REG.put(id, win);
        MSG_WINDOW_REG_Lock.unlock();
    }

    public static void delWindow(String id) {
        MSG_WINDOW_REG_Lock.lock();
        MSG_WINDOW_REG.remove(id);
        MSG_WINDOW_REG_Lock.unlock();
    }

    public static boolean containWindow(String id) {
        boolean res;
        MSG_WINDOW_REG_Lock.lock();
        if (MSG_WINDOW_REG.containsKey(id)) {
            res = true;
        } else {
            res = false;
        }
        MSG_WINDOW_REG_Lock.unlock();
        return res;
    }

    public static MsgWindow getWindow(String id) {
        MsgWindow res;
        MSG_WINDOW_REG_Lock.lock();
        if (!MSG_WINDOW_REG.containsKey(id)) {
            res = null;
        } else {
            res = MSG_WINDOW_REG.get(id);
        }
        MSG_WINDOW_REG_Lock.unlock();
        return res;
    }
    //************************************************************************
    /**
     * 其他窗口的注册
     */
    public static Vector<String> WINDOW_REG = new Vector<String>();
    /**
     * 自行添加的好友
     */
    public static Vector<String> ADDED_USER = new Vector<String>();
    /**
     * 黑名单
     */
    public static Vector<String> BLACK_LIST = new Vector<String>();
    //************************************************************************
    /**
     * 待发送文件队列
     */
    private static LinkedList<FileLinkList> FILE_LIST = new LinkedList<FileLinkList>();
    private final static Lock FILE_LIST_Lock = new ReentrantLock();

    public static FileLinkList getFileList(int packetNo) {
        FILE_LIST_Lock.lock();
        FileLinkList res = null;
        Iterator it = FILE_LIST.iterator();
        while (it.hasNext()) {
            res = (FileLinkList) it.next();
            if (res.getPacketNo() == packetNo) {
                break;
            }
        }
        FILE_LIST_Lock.unlock();
        return res;
    }

    public static void addFileList(FileLinkList flist) {
        FILE_LIST_Lock.lock();
        FileLinkList res = null;
        Iterator it = FILE_LIST.iterator();
        while (it.hasNext()) {
            res = (FileLinkList) it.next();
            if (res.getPacketNo() == flist.getPacketNo()) {
                break;
            }
            res = null;
        }
        //如果不存在改id
        if (res == null) {
            FILE_LIST.add(flist);
        }
        FILE_LIST_Lock.unlock();
    }

    public static void delFileList(int packetNo) {
        FILE_LIST_Lock.lock();
        FileLinkList res = null;
        Iterator it = FILE_LIST.iterator();
        while (it.hasNext()) {
            res = (FileLinkList) it.next();
            if (res.getPacketNo() == packetNo) {
                it.remove();
                break;
            }
        }
        FILE_LIST_Lock.unlock();
    }

    public static void delFileList(String StrPacketNo) {
        int packetNo;
        try {
            packetNo = Integer.parseInt(StrPacketNo);
        } catch (NumberFormatException e) {
            return;
        }
        FILE_LIST_Lock.lock();
        FileLinkList res = null;
        Iterator it = FILE_LIST.iterator();
        while (it.hasNext()) {
            res = (FileLinkList) it.next();
            if (res.getPacketNo() == packetNo) {
                it.remove();
                break;
            }
        }
        FILE_LIST_Lock.unlock();
    }

    public static Vector<String> exportPacketNo() {
        FILE_LIST_Lock.lock();
        Vector<String> res = new Vector<String>();
        FileLinkList tmp = null;
        Iterator it = FILE_LIST.iterator();
        while (it.hasNext()) {
            tmp = (FileLinkList) it.next();
            res.add(tmp.getPacketNo() + "");
        }
        FILE_LIST_Lock.unlock();
        return res;

    }
}
