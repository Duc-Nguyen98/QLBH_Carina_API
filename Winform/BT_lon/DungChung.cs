using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace BT_lon
{
    class DungChung
    {
        public static String User;
        public static String chucnangUser;

        public static DataTable getDataTable(String sql)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            OleDbDataAdapter ada = new OleDbDataAdapter(sql, con);
            DataTable tb = new DataTable();
            ada.Fill(tb);
            con.Close();
            return tb;
        }

        public static void ExecuteSql(String sql)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            OleDbCommand cmd = new OleDbCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
