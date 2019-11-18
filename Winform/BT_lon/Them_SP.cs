using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace BT_lon
{
    public partial class Them_SP : Form
    {
        public Them_SP()
        {
            InitializeComponent();
        }

        private void Them_SP_Load(object sender, EventArgs e)
        {
            taomanhanvien();
            mamahang.Enabled = false;
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT Nha_cung_cap.ID_nha_cung_cap, Ten_nha_cung_cap FROM Nha_cung_cap", con);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            tennhacungcap.ValueMember = "ID_nha_cung_cap";
            tennhacungcap.DisplayMember = "Ten_nha_cung_cap";
            tennhacungcap.DataSource = tb;

            OleDbDataAdapter add = new OleDbDataAdapter("SELECT Phan_loai.ID_phan_loai,Ten_phan_loai FROM Phan_loai", con);
            DataTable tbb = new DataTable();
            add.Fill(tbb);
            tenphanloai.ValueMember = "ID_phan_loai";
            tenphanloai.DisplayMember = "Ten_phan_loai";
            tenphanloai.DataSource = tbb;
            con.Close();
        }

        protected void Clear()
        {
            tenhang.Text = "";
            soluong.Text = "";
            donvitinh.Text = "";
            giaban.Text = "";
        }

        private void btn_NV_Thoai_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void them_Click_1(object sender, EventArgs e)
        {
            Clear();
        }

        string mats = "MMH";

        private void btn_NV_Luu_Click_1(object sender, EventArgs e)
        {
            if (tenhang.Text != "" && soluong.Text != "" && donvitinh.Text != "" && giaban.Text != "")
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
                con.Open();
                String sql = "insert into Mat_hang (ID_mat_hang,ID_phan_loai,ID_nha_cung_cap,Ten_hang,So_luong,Don_vi_tinh,Gia_hang) values (@ID_mat_hang,@ID_phan_loai,@ID_nha_cung_cap,@Ten_hang,@So_luong,@Don_vi_tinh,@Gia_hang)";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                cmd.Parameters.Add(new OleDbParameter("@ID_mat_hang", mamahang.Text));
                cmd.Parameters.Add(new OleDbParameter("@ID_phan_loai", tenphanloai.SelectedValue));
                cmd.Parameters.Add(new OleDbParameter("@ID_nha_cung_cap", tennhacungcap.SelectedValue));
                cmd.Parameters.Add(new OleDbParameter("@Ten_hang", tenhang.Text));
                cmd.Parameters.Add(new OleDbParameter("@So_luong", soluong.Text));
                cmd.Parameters.Add(new OleDbParameter("@Don_vi_tinh", donvitinh.Text));
                cmd.Parameters.Add(new OleDbParameter("@Gia_hang", giaban.Text));
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                con.Close();
                Clear();
                taomanhanvien();
                string message = "Bạn đã thêm nhân viên thành công";
                string title = "Thông Báo";
                MessageBox.Show(message, title);
            }
            else MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
        }
        private void taomanhanvien()
        {
            mats = "MMH";
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("select top 1 * from Mat_hang ORDER BY Mat_hang.ID_mat_hang DESC", con);
            DataTable tb = new DataTable();
            oda.Fill(tb);
            con.Close();
            int ma = int.Parse(tb.Rows[0]["ID_mat_hang"].ToString().Substring(3, tb.Rows[0]["ID_mat_hang"].ToString().Length - 3)) + 1;
            mats = mats + ma.ToString();
            mamahang.Text = mats;
        }

        private void soluong_keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void giaban_keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
