/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package ipmsg.etc;

import java.util.Vector;

/**
 *
 * @author Noeru
 */
public class User {
    private String ip=null;
    private String name=null;
    private String group=null;
    private String host=null;

    public User(String ip, String name, String group, String host) {
        this.ip = ip;
        this.name = name;
        this.group = group;
        this.host = host;
    }
    
    public String getGroup() {
        return group;
    }

    public String getHost() {
        return host;
    }

    public String getIp() {
        return ip;
    }

    public String getName() {
        return name;
    }

    public void setGroup(String group) {
        this.group = group;
    }

    public void setHost(String host) {
        this.host = host;
    }

    public void setIp(String ip) {
        this.ip = ip;
    }

    public void setName(String name) {
        this.name = name;
    }
    
    public Vector toList(){
        return null;
    }

    

}
