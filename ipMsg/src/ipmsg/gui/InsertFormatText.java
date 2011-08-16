/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package ipmsg.gui;

import java.awt.Color;
import javax.swing.JTextPane;
import javax.swing.text.BadLocationException;
import javax.swing.text.SimpleAttributeSet;
import javax.swing.text.StyleConstants;
import javax.swing.text.StyledDocument;

/**
 *
 * @author qqiu
 */
public class InsertFormatText {
    
    private JTextPane jp;
    private StyledDocument doc = null;
    
    public InsertFormatText(JTextPane jp){
        this.jp=jp;
        doc = this.jp.getStyledDocument();
    }
    
    /**
     * 使用指定的一些变量生成文本显示格式。
     * @param fonts 字体
     * @param style 式样
     * @param size 文字大小
     * @param color 文字颜色
     * @return SimpleAttributeSet
     */
    private SimpleAttributeSet getFontAttrib(String fonts,
            String style,int size,String color){
        
        SimpleAttributeSet attrSet = new SimpleAttributeSet();

        if (fonts != null)StyleConstants.setFontFamily(attrSet, fonts);

        if (style.equals("常规")) {
            StyleConstants.setBold(attrSet, false);
            StyleConstants.setItalic(attrSet, false);
        } else if (style.equals("粗体")) {
            StyleConstants.setBold(attrSet, true);
            StyleConstants.setItalic(attrSet, false);
        } else if (style.equals("斜体")) {
            StyleConstants.setBold(attrSet, false);
            StyleConstants.setItalic(attrSet, true);
        } else if (style.equals("粗斜体")) {
            StyleConstants.setBold(attrSet, true);
            StyleConstants.setItalic(attrSet, true);
        }
        
        
        if(size>0)StyleConstants.setFontSize(attrSet, size);

        if (color.equals("黑色")) {
            StyleConstants.setForeground(attrSet, new Color(0, 0, 0));
        } else if (color.equals("红色")) {
            StyleConstants.setForeground(attrSet, new Color(255, 0, 0));
        } else if (color.equals("蓝色")) {
            StyleConstants.setForeground(attrSet, new Color(0, 0, 255));
        } else if (color.equals("黄色")) {
            StyleConstants.setForeground(attrSet, new Color(255, 255, 0));
        } else if (color.equals("绿色")) {
            StyleConstants.setForeground(attrSet, new Color(0, 255, 0));
        }
        
        return attrSet;
        
        
    }
    
    public void insertFormatText(String str,//内容
            String fonts,//字体
            String style,//字形
            int size,//字体大小
            String color){ //字体颜色
        try {
            doc.insertString(doc.getLength(), str, 
                    this.getFontAttrib(fonts, style, size, color));
        }catch (BadLocationException e) {
        }
    }

}
