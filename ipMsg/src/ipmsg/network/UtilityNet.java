/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package ipmsg.network;

import ipmsg.etc.GlobalConstant;
import ipmsg.etc.Command;
import ipmsg.etc.UtilityGlobal;
import ipmsg.etc.GlobalVar;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.NetworkInterface;
import java.net.Socket;
import java.net.SocketException;
import java.util.Enumeration;

/**
 *
 * @author qqiu
 */
public class UtilityNet {
    
    static public DatagramSocket msgSocket;
    
    private static void sendUdpPacket(Command com,String ip) {

        byte[] bText = com.exportToBuf();
        try {
            DatagramPacket sendPacket = new DatagramPacket(
                    bText, bText.length,
                    InetAddress.getByName(ip),
                    GlobalConstant.IPMSG_DEFAULT_PORT);
            UtilityNet.msgSocket.send(sendPacket);
        } catch (IOException ex) {
        }
    }
    
    public static void sendUdpPacket(Command com){
        sendUdpPacket(com,com.getIp());
    }
    
    public static void broadcastUdpPacket(Command com){
        sendUdpPacket(com,"255.255.255.255");
        for(int i=0;i<GlobalVar.ADDED_USER.size();i++){
            if(!GlobalVar.ALL_IP_ADDRESS.contains(GlobalVar.ADDED_USER.get(i)))
            {
                sendUdpPacket(com,GlobalVar.ADDED_USER.get(i));
            }
        }
    }
    
    public static void getMyIps(){
        GlobalVar.ALL_IP_ADDRESS.clear();
        try {
            Enumeration<NetworkInterface> netInterfaces = null;
            netInterfaces = NetworkInterface.getNetworkInterfaces();
            while (netInterfaces.hasMoreElements()) {
                NetworkInterface ni = netInterfaces.nextElement();
                //如果以eth开头。因为可能包含lo，ppp等接口
//                if (ni.getDisplayName().startsWith("eth")) {
                //只要第一个eth开头的接口就停止。
                Enumeration<InetAddress> ips = ni.getInetAddresses();
                String tmpIp;
                while (ips.hasMoreElements()) {
                    tmpIp = ips.nextElement().getHostAddress();
                    //这里忽略ipV6格式的地址信息。
                    if (UtilityGlobal.isIP(tmpIp)&&!tmpIp.startsWith("127")) {
                        GlobalVar.ALL_IP_ADDRESS.add(tmpIp);
                    }
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
    

    /**
     * 检查端口绑定情况
     * @return
     */
    public static boolean checkPort(){
        try {
            new DatagramSocket(GlobalConstant.IPMSG_DEFAULT_PORT).close();
            return true;
        } catch (SocketException ex) {
            return false;
        }
    }
    
    /**
     * 从套接字口读取信息，直到读入':'字符为止。
     * @param inputStream
     * @param bufSize 
     * @return
     */
    public static String readDelimiter(DataInputStream inputStream,
            int bufSize) {
        byte[] res = new byte[bufSize];
        int count = 0;
        try {
            while (count<bufSize-1) {
                inputStream.read(res, count, 1);
//                if(res[count]==0)continue;
                if (res[count] == (byte) ':') {
                    break;
                }
                count++;
            }
            res[count] = 0;
            return new String(res, GlobalVar.CHARACTER_ENCODING).trim();
        } catch (IOException ex) {
            return null;
        }
    }
    public static String readDelimiter(Socket socket,int bufSize) {
        try {
            return readDelimiter(
                    new DataInputStream(
                    new BufferedInputStream(
                    socket.getInputStream())), 
                    bufSize);
        } catch (IOException ex) {
            return null;
        }
    }

}
