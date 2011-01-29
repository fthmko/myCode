using System;
using System.Data;
using System.Data.Sql;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Text;

/// <summary>
///dbop 的摘要说明
/// </summary>
public static class dbop
{
    public static string strcon = @"Data Source=192.168.11.130\SQLEXPRESS;Initial Catalog=test;Persist Security Info=True;User ID=lctmui;Password=183729";
    static SqlConnection dbcon;
    public static bool lstsq = false;
    static bool state = false;

    public static void init()
    {
        dbcon = new SqlConnection(strcon);
        dbcon.Open();
        state = true;
    }
    public static bool excsql(string sql)
    {
        if (!state) init();
        SqlCommand cmd = new SqlCommand(sql, dbcon);
        try
        {
            cmd.ExecuteNonQuery();
        }
        catch
        {
            return false;
        }
        return true;
    }
    public static DataSet selectq(string sql, string tabn)
    {
        try
        {
            SqlCommand dbcmd = new SqlCommand(sql, dbcon);
            SqlDataAdapter dbadp = new SqlDataAdapter(dbcmd);
            DataSet dbset = new DataSet();
            dbadp.Fill(dbset, tabn);
            lstsq = true;
            return dbset;
        }
        catch
        {
            lstsq = false;
            return new DataSet();
        }
    }
    public static bool check(string tb, string wh)
    {
        if (!state) init();
        string strchk = "select * from " + tb + " where " + wh;
        DataSet chk = selectq(strchk, tb);
        if (chk.Tables[0].Rows.Count != 0)
            return true;
        return false;
    }
    public static bool check2(string tb, string tl, string data)
    {
        string wh = tl + "='" + data + "'";
        return check(tb, wh);
    }
    public static string fmd5(string str)
    {
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        byte[] str1 = Encoding.UTF8.GetBytes(str);
        byte[] str2 = md5.ComputeHash(str1, 0, str1.Length);
        md5.Clear();
        (md5 as IDisposable).Dispose();
        return Convert.ToBase64String(str2);
    }
    public static string getp(string nm, string tb, string coln ,string colm)
    {
        return (string)selectq("select " + colm + " from " + tb + " where " + coln + " = '" + nm + "'", tb).Tables[0].Rows[0][0];
    }
    public static string getpwd(string nm)
    {
        return getp(nm, "usr", "usr_nm", "usr_pwd");
    }
    public static bool checkstr(string inp)
    {
        if (inp.Length < 4) return false;
        char[] qe = inp.ToCharArray();
        foreach (char cc in qe)
        {
            if (!Char.IsLetterOrDigit(cc)) return false;
        }
        return true;
    }
    public static DataSet getnew(DateTime last)
    {
        string sele = "select usr_nm,txt,dat from log where dat>'" + last + "'";
        return selectq(sele, "log");
    }
    public static string strenc(string input)
    {
        //半角转全角：
        char[] c = input.ToCharArray();
        for (int i = 0; i < c.Length; i++)
        {
            if (c[i] == 32)
            {
                c[i] = (char)12288; continue;
            }
            if (c[i] < 127) c[i] = (char)(c[i] + 65248);
        }
        return new string(c); 
    }
    public static string strdec(string input)
    {
        char[] c = input.ToCharArray();
        for (int i = 0; i < c.Length; i++)
        {
            if (c[i] == 12288)
            {
                c[i] = (char)32; continue;
            }
            if (c[i] > 65280 && c[i] < 65375)
                c[i] = (char)(c[i] - 65248);
        }
        return new string(c); 
    }
}
