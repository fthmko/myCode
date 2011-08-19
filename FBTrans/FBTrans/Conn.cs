using System;
using System.Data;
using System.Data.SQLite;
using System.Data.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace FBTrans
{
    /// <summary>
    /// Description of Conn.
    /// </summary>
    public class Conn
    {
        private static bool init = false;

        private static SQLiteConnection connection;
        private static DataContext context;

        public static void Init()
        {
            if (!init)
            {
                bool tbl = System.IO.File.Exists(Environment.CurrentDirectory + "\\FBTrans.sqlite");
                connection = new SQLiteConnection("Data Source=FBTrans.sqlite;Pooling=true;FailIfMissing=false");
                init = true;
                context = new DataContext(connection);
                if (!tbl) CreateTable();
            }
        }

        private static void CreateTable()
        {
            string sqlMsg = "CREATE TABLE \"message\" (\"lang\" TEXT(4) NOT NULL,\"version\" TEXT(10) NOT NULL,\"translator\" TEXT(20),\"encode\" TEXT(20),PRIMARY KEY (\"lang\" ASC, \"version\" ASC));CREATE UNIQUE INDEX \"IDX_MSG_KEY\"ON \"message\" (\"lang\", \"version\");";
            string sqlTag = "CREATE TABLE \"tag\" (\"key\" TEXT NOT NULL,\"seq\" INTEGER NOT NULL DEFAULT 0,\"name\" TEXT NOT NULL,\"value\" TEXT,\"parent\" TEXT DEFAULT -1,\"type\" INTEGER NOT NULL DEFAULT 0,PRIMARY KEY (\"key\" ASC));CREATE UNIQUE INDEX \"IDX_TAG_KEY\"ON \"tag\" (\"key\" ASC);CREATE INDEX \"IDX_TAG_PARENT\"ON \"tag\" (\"parent\" ASC);";
            context.ExecuteCommand(sqlMsg);
            context.ExecuteCommand(sqlTag);
        }

        public static bool Execute(string sql, params object[] param)
        {
            if (!init) return false;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            int result = 0;
            //result = context.ExecuteCommand(sql, param);
            try
            {
                result = context.ExecuteCommand(sql, param);
            }
            catch
            {
                result = 0;
            }
            return result > 0;
        }

        public static BindingList<T> QueryB<T>(string sql, params object[] param)
        {
        	List<T> lst = Query<T>(sql, param);
            BindingList<T> result = new BindingList<T>();
            foreach(T i in lst){
            	result.Add(i);
            }
            return result;
        }
        public static List<T> Query<T>(string sql, params object[] param)
        {
            if (!init) return null;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            List<T> result = new List<T>();
            result.AddRange(context.ExecuteQuery<T>(sql, param));
            return result;
        }
    }
}
