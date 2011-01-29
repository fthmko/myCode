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
public class GameD extends Thread {

    ServerSocket gameSocket;
    Socket gamePkg;
    boolean gaming;
    Object inObj;
    Object outObj;
    SendMethod cb;

    public GameD(SendMethod cbx) {
        super("GameDaemon");
        //System.out.println("Start GameDaemon On " + PubData.getpGma());
        gaming = true;
        cb = cbx;
    }

    public Object getInObjct() {
        return inObj;
    }

    public void setOutObject(Object output) {
        this.outObj = output;
    }

    public void setSendMethod(SendMethod cbx)
    {
        cb = cbx;
    }

    @Override
    public void run() {

        byte[] buffer = new byte[1024];
        try {
            DatagramSocket dts = new DatagramSocket(PubData.getpGma());
            DatagramPacket rcvp = new DatagramPacket(buffer, buffer.length);
            while (true) {
                dts.receive(rcvp);
                //System.out.printf("%d->%d - Receive GameData From IP:%s\n", rcvp.getPort(),
                //        PubData.getpGma(), rcvp.getAddress().getHostAddress());
                if (!rcvp.getAddress().getHostAddress().equals(PubData.myAddr)) {
                    cb.send(rcvp.getData());
                }
            }
        } catch (Exception ee) {
            ee.printStackTrace();
        }

        /*
        try {
        gameSocket = new ServerSocket(PubData.getpGma(),10);
        while (gaming) {
        gamePkg = gameSocket.accept();
        ObjectInputStream indata =
        new ObjectInputStream(gamePkg.getInputStream());
        inObj = indata.readObject();
        cb.send(inObj);
        System.out.printf("Receive GameData From:%s",gamePkg.getInetAddress().getHostAddress());
        }
        } catch (Exception ex) {
        System.out.printf("Error:GameD.%s\n", ex.toString());
        }
         */
    }
}
