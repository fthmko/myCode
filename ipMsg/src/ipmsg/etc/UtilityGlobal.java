/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package ipmsg.etc;

import java.text.SimpleDateFormat;
import java.util.Date;

/**
 *
 * @author Noeru
 */
public class UtilityGlobal {
    /**
     * 是否为ip
     * @param ip
     * @return
     */
    public static boolean isIP(String ip){
        String [] content=ip.split("\\.");
        if(content.length!=4)return false;
        int i,j;
        try{
            for(i=0;i<4;i++){
                j=Integer.parseInt(content[i]);
                if(j>255||j<0)return false;
            }
        }catch(NumberFormatException e){
            return false ;
        } 
        return true;
    }
    
     /**
     * 获取当前时间
     * @return 返回当前时间的字符串标示
     */
    public static String getTime(){
        Date curTime =new Date();
        String sss =new String("yyyy-MM-dd  kk:mm:ss");
        SimpleDateFormat sdf =new SimpleDateFormat(sss);
        String res =sdf.format(curTime); 
        return res;
    }
    
    /**
     * 获取数字。
     * @param number 待处理字符串
     * @return 返回数字
     */
    public static int getNumber(String number){
        try {
            return new Integer(number).intValue();
            
        } catch (NumberFormatException e){
            return -1;
        }
    }
    
    public static int atoi(String para) {
        if (para == null || para.trim().length() == 0) {
            return 0;
        }
        final char PLUS = '+';
        final char MINUS = '-';
        int ret = 0;
        String str = para.trim();
        int len = str.length();

        int pos = len;

        for (int i = 0; i < len; i++) {
            char ch = str.charAt(i);
            if (i == 0) {
                if (ch == PLUS || ch == MINUS) {
                    continue;
                }
            }
            if (!(ch >= '0' && ch <= '9')) {
                pos = i;
                break;
            }
        }
        try {
            if (str.charAt(0) == PLUS) {
                str = str.substring(1);
                pos--;
            }
            ret = Integer.parseInt(str.substring(0, pos));
        } catch (Exception e) {
        }
        return ret;
    }
    
    /**
     * 将整形数dec转化为固定长度（8位）的十六进制字符串
     * @param dec
     * @return
     */
    public static String dec2Hex(int dec) {
        StringBuffer sb = new StringBuffer();

        for (int i = 0; i < 8; i++) {
            int tmp = (dec >> (7 - i % 8) * 4) & 0x0f;
            if (tmp < 10)
                sb.append(tmp);
            else
                sb.append((char) ('A' + (tmp - 10)));
        }
        return sb.toString();
    }
}
