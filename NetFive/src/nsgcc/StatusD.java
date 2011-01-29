/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package nsgcc;

import java.net.*;
import javax.swing.JOptionPane;

/**
 *
 * @author zhangzheng
 */
public class StatusD extends Thread {

    DatagramSocket dts;
    DatagramPacket rcvp;

    public StatusD() {
        super("StatusDaemon");
        //System.out.println("Start StatusDaemon");
    }

    @Override
    public void run() {
        byte[] buffer = new byte[256];
        try {
            dts = new DatagramSocket(PubData.getpRcv());
            rcvp = new DatagramPacket(buffer, buffer.length);
            while (true) {
                dts.receive(rcvp);
                String recvs = new String(rcvp.getData()).substring(0, rcvp.getLength());
                System.out.printf("%d->%d - Recv:%s IP:%s\n", rcvp.getPort(),
                        PubData.getpRcv(), recvs, rcvp.getAddress().getHostAddress());
                if (!rcvp.getAddress().getHostAddress().equals(PubData.myAddr)) {
                    analyze(recvs);
                }
            }
        } catch (Exception ee) {
            ee.printStackTrace();
        }
    }

    void Refuse(String reson) {
        NControl.sendMessageUDP("No#" + PubData.getMyName() + "#" + reson, rcvp.getAddress(), PubData.getpPub(), PubData.getpRcv());
        return;
    }

    void analyze(String msg) {
        String[] tmp = msg.split("#");
        if (tmp[0].equals("Find")) {
            NControl.sendMessageUDP("Status#" + PubData.getMyName() + "#" + PubData.getStatus(),
                    rcvp.getAddress(), PubData.getpPub(), PubData.getpRcv());
        } else if (tmp[0].equals("Status")) {
            PubData.addUser(tmp[1], rcvp.getAddress().getHostAddress(), Integer.parseInt(tmp[2].trim()));
        } else if (tmp[0].equals("Come")) {
            if (PubData.getStatus() == 0) {
                int id = -1;
                try {
                    id = Integer.parseInt(tmp[3]);
                } catch (Exception ex) {
                    ex.printStackTrace();
                    return;
                }
                if (tmp[2].equals("1")) {
                    long start = System.currentTimeMillis();
                    String aaa = String.format("%s邀请你进行%s游戏。", tmp[1], PubData.gmlst[id]);
                    int xxx = JOptionPane.showConfirmDialog(null, aaa, "游戏邀请", JOptionPane.YES_NO_OPTION);
                    long end = System.currentTimeMillis();
                    if (end - start > 15000) {
                        JOptionPane.showMessageDialog(null, "操作超时！", "提示", JOptionPane.INFORMATION_MESSAGE);
                        return;
                    }
                    if (xxx == JOptionPane.NO_OPTION) {
                        Refuse("None");
                        return;
                    }
                }
                PubData.setStatus(1);
                NControl.sendMessageUDP("Come#" + PubData.getMyName() + "#0" + "#" + tmp[3], rcvp.getAddress(), PubData.getpPub(), PubData.getpRcv());
                PubData.gamenow = null;
                //PubData.gamenow = new Gomg();
                try {
                    PubData.gamenow = PubData.NewGame(id);
                } catch (Exception ex) {
                    ex.printStackTrace();
                    Refuse("Error");
                    PubData.setStatus(0);
                }
                NControl.setGameDest(rcvp.getAddress());
                PubData.gamenow.SetSendMethod(new SendMethod() {

                    public boolean send(byte[] obj) {
                        return NControl.sendGameData(obj);
                    }
                });

                PubData.gamedaemon.setSendMethod(new SendMethod() {

                    public boolean send(byte[] obj) {
                        try {
                            PubData.gamenow.Analyze(obj);
                        } catch (Exception ex) {
                            ex.printStackTrace();
                            return false;
                        }
                        return true;
                    }
                });

                PubData.setStatus(2);
                NControl.sendMessageUDP("Ready#" + PubData.getMyName(), rcvp.getAddress(), PubData.getpPub(), PubData.getpRcv());
            }
        } else if (tmp[0].equals("Ready")) {
            if (PubData.getStatus() == 2) {
                //System.out.println("Game Will Start");
                PubData.gamenow.StartGame(rcvp.getAddress().getHostAddress(), tmp[1]);
            } else {
                NControl.sendMessageUDP("Wait#" + PubData.getMyName(), rcvp.getAddress(), PubData.getpPub(), PubData.getpRcv());
            }
        } else if (tmp[0].equals("Wait")) {
            if (PubData.getStatus() == 2) {
                NControl.sendMessageUDP("Ready#" + PubData.getMyName(), rcvp.getAddress(), PubData.getpPub(), PubData.getpRcv());
            }
        } else if (tmp[0].equals("No")) {
            JOptionPane.showMessageDialog(null, tmp[1] + "因为[" + tmp[2] + "]拒绝了你的邀请。", "消息", JOptionPane.INFORMATION_MESSAGE);
        } else {
            System.out.println("StatusD:Unrecognized");
        }
    }
}


