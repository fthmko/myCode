/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package ipmsg.gui;

import ipmsg.etc.GlobalVar;
import java.awt.Component;
import java.io.File;
import javax.swing.ImageIcon;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JOptionPane;

/**
 *
 * @author Noeru
 */
public class UtilityGui {
    
    /**
     * 初始化一个带消息的聊天窗口。用于后台服务器接收消息。
     * @param msgContent 消息内容。
     * @param from 消息来自。
     * @param broadcast 是否是广播消息。
     */
    static public boolean newWindow(String to,String msgContent,
            String from){
        MsgWindow win;
        //如果是广播
        if(to==null){
            //如果已经打开
            if((win=GlobalVar.getWindow("broadcast"))!=null){
                if(msgContent!=null)win.appendNewMsg(msgContent, from);
                return false;
            }//如果未打开，则先打开。
            else{
                new MsgWindow(null,msgContent,from).setVisible(true);
            }
            
        }else{  
            //如果已经打开
            if((win=GlobalVar.getWindow(to))!=null){
                if(msgContent!=null)win.appendNewMsg(msgContent, from);
                return false;
            }//如果未打开，则先打开。
            else{
                new MsgWindow(to,msgContent,from).setVisible(true);
            }
        }
        return true;
        
    }
    
    /**
     * 初始化一个消息的窗口。用于用户自行打开。
     * @param ip 对方ip，如果ip不为空，则只使用该参数。
     * @param contacts  如果ip为空。则使用本参数。表示初始化群聊窗口。
     * 如果都为空，则表示群聊。
     * @return
     
    static public boolean newWindow(String ip,
            ArrayList<String> contacts){
 
        
        /**
         * ip==null&&contacts==null:广播
         * 仅仅ip==null ：群聊
         * 仅仅contacts==null ：私聊。
         *
        
        /**
         * 对于私聊和广播，不能重复打开。
         *
        if (ip == null) {
            if (contacts == null) {
                //广播
                if (GlobalVar.msgWidnowReg.containsKey("broadcast")) {
                    return false;
                }
                new MsgWindow(null, null, null).setVisible(true);
            } else {
                //群聊
                new MsgWindow(contacts).setVisible(true);
            }
        } else {

            if (GlobalVar.msgWidnowReg.containsKey(ip)) {
                return false;
            }
            new MsgWindow(ip, null, null).setVisible(true);
        }
        return true;
        
    }*/
    
    /**
     * 设置图标
     * @param frame 基于的frame
     */
    static public void setIcon(JFrame frame){
        
        ImageIcon   icon=new   ImageIcon(
                frame.getClass().getResource("/lanmsg_v2/resource/logo.png"));
        frame.setIconImage(icon.getImage());
    }
    
     
    /**
     * 要求用户输入字符串
     * @param cpnt 基于的GUI组件
     * @param title 输入框的标题
     * @param tip  输入框的提示
     * @param maxLen 输入的最大字符
     * @return 返回输入的字符串
     */
    static public String getInputString(Component cpnt,String title,
            String tip,int maxLen){
        int messagetype=JOptionPane.INFORMATION_MESSAGE;
        String res=null;
        do{
            res=(String)JOptionPane.showInputDialog(cpnt,
                    title,tip,messagetype);
            if(res==null)return null;
        }while(res.trim().isEmpty()||res.trim().length()>maxLen);
        return res.trim();
    } 
    
    /**
     * 弹出提示消息
     * @param cpnt 基于的gui组件
     * @param content 需要提示的内容
     */
    static public void showNotice(Component cpnt,String content){
        JOptionPane.showMessageDialog(cpnt,"\n"+content+"\n");
    }
    
    /**
     * 请求用户确认
     * @param cpnt 基于的gui组件
     * @param title 确认框标题
     * @param tip 确认框提示
     * @return 返回用户的态度，同意（否）
     */
    static public boolean confirm(Component cpnt,String title,String tip){
        if(JOptionPane.showConfirmDialog(cpnt,tip,title,
                JOptionPane.OK_CANCEL_OPTION,JOptionPane.QUESTION_MESSAGE,null)
                ==JOptionPane.CANCEL_OPTION)return false;
        return true;
    }

    static public String chooseFile(JFrame frame,boolean file){
        JFileChooser chooser = new JFileChooser();
//        chooser
        if(file)chooser.setFileSelectionMode(JFileChooser.FILES_ONLY);
        else chooser.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);
        int returnVal = chooser.showOpenDialog(frame);
        if(returnVal == JFileChooser.APPROVE_OPTION) {
            return chooser.getSelectedFile().getPath();
        }else return null;
    }
    
    static public File[] chooseFile(JFrame frame) {
        javax.swing.JFileChooser chooser = new JFileChooser();
        chooser.setFileSelectionMode(
                JFileChooser.FILES_AND_DIRECTORIES);
        chooser.setMultiSelectionEnabled(true);
        int returnVal = chooser.showOpenDialog(frame);

        if (returnVal == JFileChooser.APPROVE_OPTION) {
            return chooser.getSelectedFiles();
        } else {
            return null;
        }
    }

    static public String getPasswd(javax.swing.JFrame frame,
            String noteMsg, String title) {
        String passwd;
        javax.swing.JPasswordField pwd = new javax.swing.JPasswordField();
        Object[] message = {noteMsg, pwd};
        while (true) {
            int res = javax.swing.JOptionPane.showConfirmDialog(
                    frame, message, title,
                    javax.swing.JOptionPane.OK_CANCEL_OPTION,
                    javax.swing.JOptionPane.QUESTION_MESSAGE);
            if (res == javax.swing.JOptionPane.OK_OPTION) {
                if ((passwd = new String(pwd.getPassword())) != null &&
                        !passwd.equals("")) {
                    return passwd;
                }
            } else {
                break;
            }
        }
        return null;
    }

}
