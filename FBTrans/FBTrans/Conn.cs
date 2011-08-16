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
		
		public static void Init(){
			if (!init) {
				bool tbl = System.IO.File.Exists("FBTrans.sqlite");
				connection = new SQLiteConnection("Data Source=FBTrans.sqlite;Pooling=true;FailIfMissing=false");
				init = true;
				if (!tbl) CreateTable();
				context = new DataContext(connection);
			}
		}
		
		private static void CreateTable(){
			// TODO
		}
		
		public static bool Execute(string sql){
			if (!init) return false;
			if (connection.State == ConnectionState.Closed) {
				connection.Open();
			}
			SQLiteCommand cmd = new SQLiteCommand(sql, connection);
			return cmd.ExecuteNonQuery() > 0;
		}
		
		public static List<object> Query(string sql, string typname){
			if (!init) return null;
			if (connection.State == ConnectionState.Closed) {
				connection.Open();
			}
			SQLiteCommand cmd = new SQLiteCommand(sql, connection);
			SQLiteDataReader reader = cmd.ExecuteReader();
			
			
		}
	}
}
