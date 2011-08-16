/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package ipmsg.network;

import ipmsg.etc.Command;
import ipmsg.etc.FileLinkList;
import ipmsg.etc.GlobalConstant;
import ipmsg.etc.GlobalVar;
import ipmsg.gui.GetRecFiles;
import ipmsg.gui.UtilityGui;
import java.net.DatagramSocket;
import java.net.SocketException;

/**
 *
 * @author qqiu
 */
public class MsgDaemonProcessor extends Thread{
    private InterfaceFreshUsers_Start fresh;
    public MsgDaemonProcessor(InterfaceFreshUsers_Start fresh){
        this.fresh=fresh;
        try {
            UtilityNet.msgSocket =
                    new DatagramSocket(GlobalConstant.IPMSG_DEFAULT_PORT);
        } catch (SocketException ex) {
        }
    }
    
    @Override
    public void run(){
        int MOOD,OPT,tmpPlace;
        Command tmpCom,com;
        try {
            while (true) {
                GlobalVar.COMMAND_QUEUE_fULL.acquire();
                com = GlobalVar.popCommand();
                GlobalVar.COMMAND_QUEUE_EMPTY.release();
                
//                System.out.println("processor"+com.getIp());
                
                MOOD = GlobalConstant.GET_MODE(com.getFlag());
                OPT = GlobalConstant.GET_OPT(com.getFlag());


                if ((OPT & GlobalConstant.IPMSG_SENDCHECKOPT) != 0) {
                    tmpCom = new Command(GlobalConstant.IPMSG_RECVMSG);
                    tmpCom.setAdditional("" + com.getPacketNo());
                    tmpCom.setIp(com.getIp());
                    UtilityNet.sendUdpPacket(tmpCom);
                }

                switch (MOOD) {
                    //收到消息
                    case GlobalConstant.IPMSG_SENDMSG:
                        tmpPlace=com.getAdditional().indexOf(0);
                        if (tmpPlace > 0)
                            UtilityGui.newWindow(com.getIp(),
                                    com.getAdditional().substring(0, tmpPlace),
                                    com.getIp());
                        if ((OPT & GlobalConstant.IPMSG_FILEATTACHOPT)!=0){
                            FileLinkList TMP = FileLinkList.createFileLinkList(
                                    com.getAdditional().substring(tmpPlace+1),
                                    com.getIp(),
                                    com.getPacketNo());
                            if(TMP!=null)new GetRecFiles(TMP).setVisible(true);
//                            TMP.show();
                        }
                        
                        break;
                    case GlobalConstant.IPMSG_ANSENTRY:
                    case GlobalConstant.IPMSG_BR_ABSENCE:
                        if((tmpPlace=com.getAdditional().indexOf(0))==-1)
                            GlobalVar.addUser(com.getIp(), 
                                    com.getAdditional(),null,
                                    com.getSenderHost());
                        else GlobalVar.addUser(com.getIp(), 
                                com.getAdditional().substring(0, tmpPlace)
                                ,com.getAdditional().substring(tmpPlace+1),
                                com.getSenderHost());
                        this.fresh.refreshUsers();
                        break;
                    case GlobalConstant.IPMSG_BR_ENTRY:
                        tmpCom = new Command(GlobalConstant.IPMSG_ANSENTRY);
                        tmpCom.setAdditional(GlobalVar.USER_NAME+'\0'+GlobalVar.HOST_GROUP);
                        tmpCom.setIp(com.getIp());
                        UtilityNet.sendUdpPacket(tmpCom);
                        
                        /*if((tmpPlace=com.getAdditional().indexOf(0))==-1)
                            GlobalVar.addUser(com.getIp(), com.getAdditional());
                        else GlobalVar.addUser(com.getIp(), 
                                com.getAdditional().substring(0, tmpPlace));*/
                        
                        if((tmpPlace=com.getAdditional().indexOf(0))==-1)
                            GlobalVar.addUser(com.getIp(), 
                                    com.getAdditional(),null,
                                    com.getSenderHost());
                        else GlobalVar.addUser(com.getIp(), 
                                com.getAdditional().substring(0, tmpPlace)
                                ,com.getAdditional().substring(tmpPlace+1),
                                com.getSenderHost());
                        this.fresh.refreshUsers();
                        break;
                    case GlobalConstant.IPMSG_BR_EXIT:
                        GlobalVar.delUser(com.getIp());
                        this.fresh.refreshUsers();
                        break;
                    case GlobalConstant.IPMSG_RECVMSG:
                        System.out.println("消息回复报文");
                        break;
                    case GlobalConstant.IPMSG_NOOPERATION:
                        System.out.println("空报文");
                        break;
                    case GlobalConstant.IPMSG_RELEASEFILES:
                        GlobalVar.delFileList(com.getAdditional().trim());
                        break;
                    default:{
                        System.out.println("其他报文");
//                        System.out.println(MOOD+" "+OPT);
                    }
                    

                }
            }
        } catch (InterruptedException ex) {
        }
        
    }

}
