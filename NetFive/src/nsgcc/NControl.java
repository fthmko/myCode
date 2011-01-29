/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package nsgcc;

import java.net.*;
import java.io.*;

/**
 *
 * @author zhangzheng
 */
public class NControl {

    //private static boolean tcpconnected = false;
    //private static Socket socket;
    //private static ObjectOutputStream output;
    //private static boolean gamestarted = false;
    private static InetAddress gamedst;

    public static boolean sendMessageUDP(String msgs, InetAddress agp, int portme, int porthe) {
        try {
            byte[] msg = msgs.getBytes();
            DatagramSocket portPub = new DatagramSocket(portme);
            DatagramPacket dkp = new DatagramPacket(msg, msg.length, agp, porthe);
            portPub.setSoTimeout(500);
            try {
                System.out.printf("%d->%d , Send:%s IP:%s\n", PubData.getpPub(), dkp.getPort(), msgs, agp.getHostAddress());
                portPub.send(dkp);
                portPub.close();
                return true;

            } catch (SocketTimeoutException xe) {
                xe.printStackTrace();
            }
            portPub.close();
        } catch (Exception ee) {
            ee.printStackTrace();
        }
        return false;
    }
/*
    public static boolean ConnectTCP(InetAddress host) {
        System.out.println("====ConnectTCP To:"+host.getHostAddress()+","+PubData.getpGma());
        try {
            System.out.println("====ConnectTCP Socket Initing");
            socket = new Socket(host,PubData.getpGma(),InetAddress.getLocalHost(),PubData.getpGmb());
            System.out.println("====ConnectTCP Socket Set");
            output = new ObjectOutputStream(socket.getOutputStream());
            System.out.println("====ConnectTCP Stream Set");
            tcpconnected = true;
        } catch (Exception ex) {
            ex.printStackTrace();
        }
        System.out.println("====ConnectTCP Finish");
        return tcpconnected;
    }

    public static void DisconnectTCP() {
        try {
            output.close();
            socket.close();
        } catch (IOException ex) {
            ex.printStackTrace();
        }
        tcpconnected = false;
    }
*/
    public static void setGameDest(InetAddress dest)
    {
        gamedst = dest;
    }

    public static boolean sendGameData(byte[] msg)
    {
         try {
            DatagramSocket portPub = new DatagramSocket(PubData.getpGmb());
            DatagramPacket dkp = new DatagramPacket(msg, msg.length, gamedst, PubData.getpGma());
            portPub.setSoTimeout(500);
            try {
                //System.out.printf("%d->%d , Send GameData To IP:%s\n", PubData.getpPub(), dkp.getPort(), gamedst.getHostAddress());
                portPub.send(dkp);
                portPub.close();
                return true;

            } catch (SocketTimeoutException xe) {
                xe.printStackTrace();
            }
            portPub.close();
        } catch (Exception ee) {
            ee.printStackTrace();
        }
        return false;
    }
/*
    public static boolean sendMessageTCP(Object msg) {
        if (!tcpconnected) {
            return false;
        }
        try {
            System.out.printf("Send GameData To:%s",socket.getInetAddress().getHostAddress());
            output.writeObject(msg);
            output.flush();
            return true;
        } catch (Exception e) {
            e.printStackTrace();
        }
        return false;
    }

    public static boolean StartGameDaemon(SendMethod ccb) {
        if (gamestarted) {
            return false;
        }
        Thread gm = new GameD(ccb);
        gm.setDaemon(true);
        gm.start();
        gamestarted = true;
        return true;
    }
*/
    public static boolean sendFindMsg() {
        InetAddress t;
        try {
            t = InetAddress.getByName("192.168.86.255");
            return sendMessageUDP("Find#" + PubData.getMyName(), t, PubData.getpPub(), PubData.getpRcv());
        } catch (UnknownHostException ex) {
            System.out.println("Error:NControl.UnknownHostException");
            ex.printStackTrace();
        }
        return false;
    }
}
