using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT_lon
{
    public partial class Them_NV : Form
    {
        public Them_NV()
        {
            InitializeComponent();
        }

        string mats = "MNV";
        private void btn_NV_Thoai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string radio_button = string.Empty;
        string phanquen = string.Empty;
        private void btn_NV_Luu_Click(object sender, EventArgs e)
        {

            if (phanquen != "" && t3.Text != "" && t4.Text != "" && dateTimePicker1.Text != "" && thanhpho.Text != "" && radio_button != "" && t7.Text != "" && t8.Text != "" && t9.Text != "" && t10.Text != "")
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
                con.Open();
                String sql = "insert into Nhan_vien (ID_nhan_vien,ID_quyen,Ho,Ten,Ngay_sinh,Que_quan,Trang_thai_lam_viec,Dia_chi,Dien_thoai,Ten_dang_nhap,Mat_khau) values (@ID_nhan_vien,@ID_quyen,@Ho,@Ten,@Ngay_sinh,@Que_quan,@Trang_thai_lam_viec,@Dia_chi,@Dien_thoai,@Ten_dang_nhap,@Mat_khau)";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                cmd.Parameters.Add(new OleDbParameter("@ID_nhan_vien", t1.Text));
                cmd.Parameters.Add(new OleDbParameter("@ID_quyen", phanquen));
                cmd.Parameters.Add(new OleDbParameter("@Ho", t3.Text));
                cmd.Parameters.Add(new OleDbParameter("@Ten", t4.Text));
                cmd.Parameters.Add(new OleDbParameter("@Ngay_sinh", dateTimePicker1.Text));
                cmd.Parameters.Add(new OleDbParameter("@Que_quan", thanhpho.Text));
                cmd.Parameters.Add(new OleDbParameter("@Trang_thai_lam_viec", radio_button));
                cmd.Parameters.Add(new OleDbParameter("@Dia_chi", t7.Text));
                cmd.Parameters.Add(new OleDbParameter("@Dien_thoai", t8.Text));
                cmd.Parameters.Add(new OleDbParameter("@Ten_dang_nhap", t9.Text));
                cmd.Parameters.Add(new OleDbParameter("@Mat_khau", t10.Text));
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
            mats = "MNV";
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("select top 1 * from Nhan_vien ORDER BY Nhan_vien.ID_nhan_vien DESC", con);
            DataTable tb = new DataTable();
            oda.Fill(tb);
            con.Close();
            int ma = int.Parse(tb.Rows[0]["ID_nhan_vien"].ToString().Substring(3, tb.Rows[0]["ID_nhan_vien"].ToString().Length - 3)) + 1;
            mats = mats + ma.ToString();
            t1.Text = mats;
        }

        private void rbtn1_CheckedChanged(object sender, EventArgs e)
        {
            radio_button = "Đang Làm Việc";
        }

        private void rbtn2_CheckedChanged(object sender, EventArgs e)
        {
            radio_button = "Nghỉ Việc";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            phanquen = "1";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            phanquen = "2";
        }

        private void Them_NV_Load(object sender, EventArgs e)
        {
            t1.Enabled = false;
            taomanhanvien();
        }

        protected void Clear()
        {
            //radio_button = "";
            t3.Text = "";
            t4.Text = "";
            thanhpho.Text = "";
            //phanquen = "";
            t7.Text = "";
            t8.Text = "";
            t9.Text = "";
            t10.Text = "";
        }

        private void them_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void so_dien_thoai_keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
