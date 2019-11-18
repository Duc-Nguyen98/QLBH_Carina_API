using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;

namespace BT_lon
{
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
        }
        private void Home_Load(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Chung";
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            KQ_NV.Text = dt.Rows[0]["Nhan_vien_hien_tai"].ToString();
            KQ_KH.Text = dt.Rows[0]["Khach_hang"].ToString();
            KQ_NCC.Text = dt.Rows[0]["Nha_cung_cap"].ToString();
            KQ_K.Text = dt.Rows[0]["so_luong_mat_hang"].ToString();
            KQ_THD.Text = dt.Rows[0]["Tong_hoa_don"].ToString();
            KQ_HDDXL.Text = dt.Rows[0]["Hoa_don_da_xu_ly"].ToString();
            KQ_HDCXL.Text = dt.Rows[0]["Hoa_don_chua_xu_ly"].ToString();
            KQ_DTTTuan.Text = dt.Rows[0]["Doanh_thu_theo_tuan_hien_tai"].ToString();
            KQ_DTTThang.Text = dt.Rows[0]["Doanh_thu_theo_thang"].ToString();
            KQ_DTTNam.Text = dt.Rows[0]["Doanh_thu_theo_nam"].ToString();
            KQ_HNTThang.Text = dt.Rows[0]["So_luong_hang_nhap_theo_thang"].ToString();
            KQ_HNTNam.Text = dt.Rows[0]["So_luong_hang_nhap_theo_nam"].ToString();
            con.Close();
        }
    }
}
