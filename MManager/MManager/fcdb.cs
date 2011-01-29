using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace MManager
{
    public class fcdb
    {
        static string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\MManger.accdb;Persi" +
                "st Security Info=True;Jet OLEDB:Database Password=34c76b1e";
        static OleDbConnection dbcon;
        private static bool state = false;
        public static bool lstsq = false;

        public static void setdb()
        {
            dbcon = new OleDbConnection(strConn);
            dbcon.Open();
            state = true;
        }
        public static DataSet selectq(string sql, string tabn)
        {
            try
            {
                OleDbCommand dbcmd = new OleDbCommand(sql, dbcon);
                OleDbDataAdapter dbadp = new OleDbDataAdapter();
                dbadp.SelectCommand = dbcmd;
                OleDbCommandBuilder dbbcb = new OleDbCommandBuilder(dbadp);
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

        public static bool excsql(string sql)
        {
            if (!state) throw new Exception();
            OleDbCommand cmd = new OleDbCommand(sql, dbcon);
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
        public static bool check2(string tb, string tl, string data)
        {
            if (!state) throw new Exception();
            string wh = tl + "='" + data + "'";
            return check(tb, wh);
        }

        public static bool check(string tb, string wh)
        {
            if (!state) throw new Exception();
            string strchk = "select * from " + tb + " where " + wh;
            DataSet chk = selectq(strchk, tb);
            if (chk.Tables[0].Rows.Count != 0)
                return true;
            return false;
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
        public static string getpwd()
        {
            return (string)selectq("select PWD from USR where ID = '1'", "USR").Tables[0].Rows[0][0];
        }
    }
}
