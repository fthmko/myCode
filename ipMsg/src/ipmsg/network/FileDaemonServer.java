/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package ipmsg.network;

import ipmsg.etc.GlobalConstant;
import java.net.ServerSocket;
import java.net.Socket;

/**
 *
 * @author Noeru
 */
public class FileDaemonServer extends Thread{
    ServerSocket ss;
    
    @Override
    public void run(){
        try {
            ss= new ServerSocket(GlobalConstant.IPMSG_DEFAULT_PORT);
            while (true) {
                Socket s = ss.accept();
                new Thread(new SendFileDeamon(s)).start();
            }
        } catch (Exception e) {
        }
    }

}
