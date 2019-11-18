using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace BT_lon
{
    public partial class Cap_nhat_MK : Form
    {
        public Cap_nhat_MK()
        {
            InitializeComponent();
            panel1.Hide();
        }
        private void btnkiemtra_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            string sql = string.Format("select * from Nhan_vien where Ten_dang_nhap = '" + username.Text + "' and Mat_khau = '" + password.Text + "'", con);
            OleDbDataAdapter ad = new OleDbDataAdapter(sql, con);
            DataTable dt = new DataTable();
            //Đổ dữ liệu lấy được từ Query ra DataTable dt
            ad.Fill(dt);
            if (dt.Rows.Count == 1) // Có 1 trường dữ liệu trả về
            {
                panel1.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản không đúng mời nhập lại !!!");
            }
        }
        private void btncapnhat_Click_1(object sender, EventArgs e)
        {

            if (txt1.Text == "") MessageBox.Show("Password mới không được để trống");
            else if (txt2.Text == "") MessageBox.Show("Nhập lại Password Không được để trống");
            else if (dateTimePicker1.Text == "") MessageBox.Show("Ngày sinh không được để trống");
            else if (txt_QQ.Text == "") MessageBox.Show("Quê quán không được để trống");
            else if (txt_DC.Text == "") MessageBox.Show("Địa chỉ không được để trống");
            else if (txt_DT.Text == "") MessageBox.Show("Số điện thoại không được để trống");
            else if (txt1.Text != txt2.Text) MessageBox.Show("Password mới trùng nhau mời nhập lại");
            else
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
                con.Open();
                string sql = string.Format(@"update Nhan_vien set  Mat_khau ='" + txt2.Text + "' ,  Ngay_sinh ='" + dateTimePicker1.Text + "'  , Que_quan ='" + txt_QQ.Text + "', Dia_chi ='" + txt_DC.Text + "', Dien_thoai ='" + txt_DT.Text + "' WHERE Ten_dang_nhap ='" + username.Text + "'");
                OleDbCommand cmd = new OleDbCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thông tin đã được cập nhật");
            }

        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void so_dien_thoai(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
