/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package nsgcc;

import java.util.*;
import javax.swing.JOptionPane;

/**
 *
 * @author zhangzheng
 */
public class Gomg implements GameImpl {

    private static final String gameName = "五子棋";
    SendMethod sendMhd;
    int status;
    int rdnum;
    boolean inTurn;
    int[][] map;
    GomgView tmap;
    int myvlu;
    String dname;
    String dhost;

    public String getGameName() {
        return gameName;
    }

    public void StartGame(String host, String name) {
        status = 1;
        dname = name;
        dhost = host;
        decideFirst();
    }

    public void EndGame() {
        if (status == -1) {
            return;
        }
        MyData tmp = new MyData(4, "", 0, 0);
        sendMhd.send(PubData.Object2Byte(tmp));
        status = -1;
        tmap.dispose();
        PubData.setStatus(0);
        PubData.RefreshUser();
    }

    private void decideFirst() {
        Random x = new Random();
        rdnum = x.nextInt(100);
        MyData tmp = new MyData(3, "", rdnum, 0);
        sendMhd.send(PubData.Object2Byte(tmp));
    }

    private void GameRun(boolean first) {
        map = new int[19][19];
        tmap = new GomgView(first);
        tmap.setInfo(dname, dhost);
        tmap.setStatus(first);
        tmap.setLocationRelativeTo(null);
        tmap.setVisible(true);
    }

    public boolean ImBlack() {
        return (myvlu > 0);
    }

    public int[][] getMap() {
        return map;
    }

    public boolean TakeKey(java.awt.Point pos) {
        if (map[pos.y][pos.x] != 0) {
            return false;
        }
        MyData key = new MyData(0, "Go", pos.x, pos.y);
        sendMhd.send(PubData.Object2Byte(key));
        map[pos.y][pos.x] = myvlu;
        tmap.setStatus(false);
        return true;
    }

    public void SendMsg(String msg) {
        MyData msms = new MyData(6, msg, 0, 0);
        sendMhd.send(PubData.Object2Byte(msms));
    }

    public void QuestReturn() {
        MyData msms = new MyData(1, "申请悔棋", 0, 0);
        sendMhd.send(PubData.Object2Byte(msms));
    }

    public void CheckWin(int x, int y) {
        if (CheckOne(x, y, 0, -1) ||
                CheckOne(x, y, -1, -1) ||
                CheckOne(x, y, -1, 0) ||
                CheckOne(x, y, -1, 1)) {
            MyData tmp = new MyData(5, "You Win!", 0, 0);
            sendMhd.send(PubData.Object2Byte(tmp));
            javax.swing.JOptionPane.showMessageDialog(tmap, "你输了！");
            EndGame();
        }
    }

    public boolean CheckOne(int x, int y, int dx, int dy) {
        int ct = 1;
        int v = map[y][x];
        int tx = x;
        int ty = y;
        while (true) {
            tx += dx;
            ty += dy;
            if (tx < 0 || tx > 18 || ty < 0 || ty > 18) {
                break;
            }
            if (map[ty][tx] == v) {
                ct++;
            } else {
                break;
            }
        }

        tx = x;
        ty = y;
        while (true) {
            tx -= dx;
            ty -= dy;
            if (tx < 0 || tx > 18 || ty < 0 || ty > 18) {
                break;
            }
            if (map[ty][tx] == v) {
                ct++;
            } else {
                break;
            }
        }

        if (ct > 4) {
            return true;
        }
        return false;
    }

    private void DoReturn(boolean me) {
        tmap.haslast = false;
        map[tmap.lastp.y][tmap.lastp.x] = 0;
        tmap.repaint();
        tmap.setStatus(me);
    }

    public void Analyze(byte[] data) {
        MyData db = (MyData) PubData.Byte2Object(data);
        switch (db.type) {
            case 0:                 //go
                map[db.ypos][db.xpos] = 0 - myvlu;
                tmap.DrawPoint(new java.awt.Point(db.xpos, db.ypos), !ImBlack());
                tmap.setStatus(true);
                CheckWin(db.xpos, db.ypos);
                break;
            case 1:                 //return申请
                int xxx = JOptionPane.showConfirmDialog(tmap, "对方申请悔棋", "提示", JOptionPane.YES_NO_OPTION);
                MyData msms = new MyData(2, "", 0, 0);
                if (xxx != JOptionPane.NO_OPTION) {
                    msms.xpos = 1;
                    DoReturn(false);
                }
                sendMhd.send(PubData.Object2Byte(msms));
                break;
            case 2:                 //return结果
                if (db.xpos == 1) {
                    DoReturn(true);
                } else {
                    javax.swing.JOptionPane.showMessageDialog(tmap, "对方拒绝你悔棋。");
                }
                break;
            case 6:                 //msg
                tmap.ReceiveMsg(db.info);
                break;
            case 3:                 //先手判断
                if (db.xpos == rdnum) {
                    decideFirst();
                } else {
                    if (db.xpos > rdnum) {
                        inTurn = false;
                        myvlu = -1;
                    } else {
                        inTurn = true;
                        myvlu = 1;
                    }
                    status = 1;
                    GameRun(inTurn);
                }
                break;
            case 4:                 //Exit
                javax.swing.JOptionPane.showMessageDialog(tmap, dname + "离开了游戏。");
                EndGame();
                break;
            case 5:                 //I Win
                javax.swing.JOptionPane.showMessageDialog(tmap, "你赢了！");
                EndGame();
            default:
        }
    }

    public void SetSendMethod(SendMethod sd) {
        sendMhd = sd;
    }
}

class MyData implements java.io.Serializable {

    public int type;
    public String info;
    public int xpos;
    public int ypos;

    MyData(int a, String b, int x, int y) {
        type = a;
        info = b;
        xpos = x;
        ypos = y;
    }
}
