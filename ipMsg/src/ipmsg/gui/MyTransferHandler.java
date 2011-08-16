/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package ipmsg.gui;

import ipmsg.etc.GlobalConstant;
import ipmsg.etc.GlobalVar;
import java.awt.datatransfer.DataFlavor;
import java.awt.datatransfer.Transferable;
import java.awt.datatransfer.UnsupportedFlavorException;
import java.io.File;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Iterator;
import java.util.List;
import javax.swing.DefaultListModel;
import javax.swing.JList;
import javax.swing.TransferHandler;

/**
 *
 * @author qqiu
 */
/**
 * 该类实现类似飞鸽的拖放功能。<br>
 * 支持windows和linux。<br>
 * 但是java对该功能的实现居然不一样。居然跨平台？？？
 */
public class MyTransferHandler extends TransferHandler {
    
    private JList jlist;
    
    public MyTransferHandler(JList jlist){
        this.jlist=jlist;
    }

    @Override
    /**
     * 能不能拖放
     */
    public boolean canImport(TransferHandler.TransferSupport support) {
        if ((GlobalVar.OS == GlobalConstant.WINDOWS &&
                !support.isDataFlavorSupported(
                DataFlavor.javaFileListFlavor)) ||
                (GlobalVar.OS == GlobalConstant.LINUX&&
                !support.isDataFlavorSupported(DataFlavor.stringFlavor))) {
            return false;
        }
        return true;
    }

    @Override
    /**
     * 导入数据。<br>
     * 该函数对windows和linux有不同的实现。
     */
    public boolean importData(TransferHandler.TransferSupport support) {
        if (!canImport(support)) {
            return false;
        }
        List list = null;
        Iterator iterator;
        Transferable tr = support.getTransferable();

        //获取本地listmodel并初始化
        DefaultListModel listModel;
        if (jlist.getModel().getSize() == 0) {
            listModel = new DefaultListModel();
        } else {
            listModel = (DefaultListModel) jlist.getModel();
        }


        if (support.isDataFlavorSupported(DataFlavor.javaFileListFlavor)) {
            try {
                list = (List) (tr.getTransferData(DataFlavor.javaFileListFlavor));
            } catch (UnsupportedFlavorException e) {
                // TODO Auto-generated catch block
                e.printStackTrace();
            } catch (IOException e) {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }
            iterator = list.iterator();
            while (iterator.hasNext()) {
                File f = (File) iterator.next();

                if (!listModel.contains(f.getPath())) {
                    listModel.addElement(f.getPath());
                }
            }

        } else if (support.isDataFlavorSupported(DataFlavor.stringFlavor)) {
            String listname = null;
            try {
                listname = (tr.getTransferData(DataFlavor.stringFlavor)).toString();
            } catch (UnsupportedFlavorException e) {
                // TODO Auto-generated catch block
                e.printStackTrace();
            } catch (IOException e) {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }
            list = new ArrayList<String>(Arrays.asList(listname.split("\r\n")));
            iterator = list.iterator();
            while (iterator.hasNext()) {
                File f = null;
                try {
                    f = new File(new URI((String) iterator.next()));
//                        System.out.println("string : " + f.getPath());

                    if (!listModel.contains(f.getPath())) {
                        listModel.addElement(f.getPath());
                    }

                } catch (java.lang.NullPointerException e) {
                } catch (URISyntaxException ex) {
                } catch (IllegalArgumentException e) {
                }
//                    MainFrame.vt.addElement(f);
            }
        } else {
            return false;
        }

        jlist.setModel(listModel);
        if (jlist.getModel().getSize() > 0) {
            jlist.setSelectedIndex(0);
        }
        return true;
    }
}