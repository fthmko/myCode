/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package ipmsg.network;

import ipmsg.etc.Command;
import ipmsg.etc.GlobalConstant;
import ipmsg.etc.GlobalVar;
import java.io.IOException;
import java.net.DatagramPacket;
import java.net.SocketException;

/**
 *
 * @author qqiu
 */
public class MsgDaemonServer extends Thread {

    public MsgDaemonServer() {
        /*try {
            UtilityNet.msgSocket =
                    new DatagramSocket(GlobalConstant.IPMSG_DEFAULT_PORT);
        } catch (SocketException ex) {
        }*/
    }

    @Override
    public void run() {
        try {
            byte[] buf = new byte[GlobalConstant.COMMAND_LEN];
            DatagramPacket recv = new DatagramPacket(buf, buf.length);

            Command tmpCom;
            while (true) {
                UtilityNet.msgSocket.receive(recv);
                
                if(GlobalVar.BLACK_LIST.contains(
                        recv.getAddress().getHostAddress()))continue;
                
                byte[] buf2 = new byte[recv.getLength()];
                System.arraycopy(recv.getData(), 0, buf2, 0, recv.getLength());
                if ((tmpCom = Command.createCommand(
                        buf2, recv.getAddress().getHostAddress())) != null) {
                    
//                System.out.println("2"+recv.getAddress().getHostAddress());
                    GlobalVar.COMMAND_QUEUE_EMPTY.acquire();
                    
//                System.out.println("3"+recv.getAddress().getHostAddress());
                    GlobalVar.pushCommand(tmpCom);
                    GlobalVar.COMMAND_QUEUE_fULL.release();
                }
            }
        } catch (SocketException ex) {
        } catch (IOException ex) {
        } catch (InterruptedException ex) {
        }
        
    }
}
