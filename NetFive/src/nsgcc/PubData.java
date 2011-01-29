/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package nsgcc;

import java.util.*;
import java.io.*;

/**
 *
 * @author zhangzheng
 */
public class PubData {

    public static String[] gmlst = {"五子棋", "测试用"};
    private static String[] clnm = {"nsgcc.Gomg", "nsgcc.Gomg"};
    private static Class[] clslst;
    static Vector<String> nmlst = new Vector<String>(4, 2);
    static Vector<String> adlst = new Vector<String>(4, 2);
    static Vector<Integer> stslst = new Vector<Integer>(4, 2);
    static Vector<String> inList = new Vector<String>(4, 2);
    private static CallBack cb;
    private static String myName = "NONAME";
    private static int pPub = 7001;
    private static int pRcv = 7002;
    private static int pGma = 7011;
    private static int pGmb = 7012;
    private static int status = 0;
    static String myAddr = "";
    public static GameImpl gamenow;
    public static GameD gamedaemon;
    public static int gamecount;

    public static boolean initPubData() {

        gamecount = gmlst.length;
        if (clnm.length != gamecount) {
            return false;
        }
        clslst = new Class[gamecount];
        for (int t = 0; t < gamecount; t++) {
            try {
                clslst[t] = Class.forName(clnm[t]);
            } catch (Exception x) {
                x.printStackTrace();
                return false;
            }
        }

        return true;
    }

    public static GameImpl NewGame(int id) throws InstantiationException, IllegalAccessException {
        return (GameImpl) clslst[id].newInstance();
    }

    public static int getStatus() {
        return status;
    }

    public static void setStatus(int sts) {
        status = sts;
    }

    public static int getpGma() {
        return pGma;
    }

    public static int getpGmb() {
        return pGmb;
    }

    public static int getpRcv() {
        return pRcv;
    }

    public static int getpPub() {
        return pPub;
    }

    public static String getMyName() {
        return myName;
    }

    public static void setMyName(String myName) {
        PubData.myName = myName;
    }

    public static void setCallBack(CallBack bk) {
        cb = bk;
    }

    private static String getDesc(int sts) {
        switch (sts) {
            case 0:
                return "空闲";
            case 1:
                return "准备";
            case 2:
                return "游戏";
            case 3:
                return "未定义";
            default:
                return "错误";
        }
    }

    public static synchronized boolean addUser(String name, String addr, int status) {
        if (!adlst.contains(addr)) {
            nmlst.addElement(name);
            adlst.addElement(addr);
            stslst.addElement(status);
            inList.addElement(String.format("%s %s  %s", getDesc(status), addr, name));
            cb.execute();
            return true;
        }
        return false;
    }

    public static synchronized void RefreshUser() {
        nmlst.clear();
        //nmlst.removeAllElements();
        adlst.clear();
        stslst.clear();
        inList.clear();
        NControl.sendFindMsg();
        cb.execute();
    }

    public static Object Byte2Object(byte[] objBytes) {
        if (objBytes == null || objBytes.length == 0) {
            return null;
        }
        try {
            ByteArrayInputStream bi = new ByteArrayInputStream(objBytes);
            ObjectInputStream oi = new ObjectInputStream(bi);
            return oi.readObject();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return null;
    }

    public static byte[] Object2Byte(Object obj) {
        if (obj == null) {
            return null;
        }
        try {
            byte[] bytes;
            ByteArrayOutputStream bo = new ByteArrayOutputStream();
            ObjectOutputStream oo = new ObjectOutputStream(bo);
            oo.writeObject(obj);
            bytes = bo.toByteArray();
            bo.close();
            oo.close();
            return bytes;
        } catch (Exception e) {
            e.printStackTrace();
        }
        return null;
    }
}
