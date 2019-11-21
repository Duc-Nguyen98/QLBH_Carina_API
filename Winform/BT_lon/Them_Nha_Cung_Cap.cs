using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT_lon
{
    public partial class Them_Nha_Cung_Cap : Form
    {
        public Them_Nha_Cung_Cap()
        {
            InitializeComponent();
        }

        string mats = "MNCC";

        protected void Clear()
        {
            tennhacungcap.Text = "";
            diachi.Text = "";
            gmail.Text = "";
            sodienthoai.Text = "";
        }

        private void Them_Nha_Cung_Cap_Load(object sender, EventArgs e)
        {
            idnhacungcap.Enabled = false;
            taomanhanvien();

        }
       

        private void email(object sender, EventArgs e)
        {
            string email = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(gmail.Text, email))
            {
            }
            else
            {
                MessageBox.Show("Email nhập sai mời nhập lại !!!");
                return;
            }
        }

        private void them_Click_1(object sender, EventArgs e)
        {
            Clear();
        }

        private void sodienthoai_keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_NV_Thoai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void taomanhanvien()
        {
            mats = "MNCC";
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("select top 1 * from Nha_cung_cap ORDER BY Nha_cung_cap.ID_nha_cung_cap DESC", con);
            DataTable tb = new DataTable();
            oda.Fill(tb);
            con.Close();
            int ma = int.Parse(tb.Rows[0]["ID_nha_cung_cap"].ToString().Substring(4, tb.Rows[0]["ID_nha_cung_cap"].ToString().Length - 4)) + 1;
            mats = mats + ma.ToString();
            idnhacungcap.Text = mats;
        }

        private void btn_NV_Luu_Click(object sender, EventArgs e)
        {
            if (tennhacungcap.Text != "" && diachi.Text != "" && gmail.Text != "" && sodienthoai.Text != "")
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
                con.Open();
                String sql = "insert into Nha_cung_cap (ID_nha_cung_cap,Ten_nha_cung_cap,Dia_chi,Email,Dien_thoai) values (@ID_nha_cung_cap,@Ten_nha_cung_cap,@Dia_chi,@Email,@Dien_thoai)";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                cmd.Parameters.Add(new OleDbParameter("@ID_nha_cung_cap", idnhacungcap.Text));
                cmd.Parameters.Add(new OleDbParameter("@Ten_nha_cung_cap", tennhacungcap.Text));
                cmd.Parameters.Add(new OleDbParameter("@Dia_chi", diachi.Text));
                cmd.Parameters.Add(new OleDbParameter("@Email", gmail.Text));
                cmd.Parameters.Add(new OleDbParameter("@Dien_thoai", sodienthoai.Text));
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                con.Close();
                Clear();
                taomanhanvien();
                string message = "Bạn đã thêm nhà cung cấp thành công.";
                string title = "Thông Báo";
                MessageBox.Show(message, title);
            }
            else MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
        }
    }
}
