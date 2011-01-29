/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package nsgcc;

/**
 *
 * @author zhangzheng
 */
public interface GameImpl {
    String getGameName();
    void StartGame(String host,String name);
    void Analyze(byte[] data);
    void SetSendMethod(SendMethod sd);
}
