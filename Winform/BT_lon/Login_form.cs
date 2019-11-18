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
    public partial class Login_form : Form
    {
        public Login_form()
        {
            InitializeComponent();
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            if (txt1.Text == "") MessageBox.Show("User name không được để trống");
            else if (txt2.Text == "") MessageBox.Show("Password Không được để trống");
            else
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
                con.Open();
                //Khởi tạo Query
                string sql = string.Format("select * from Nhan_vien where Ten_dang_nhap = '" + txt1.Text + "' and Mat_khau = '" + txt2.Text + "'", con);
                OleDbDataAdapter ad = new OleDbDataAdapter(sql, con);
                DataTable dt = new DataTable();
                //Đổ dữ liệu lấy được từ Query ra DataTable dt
                ad.Fill(dt);
                if (dt.Rows.Count == 1) // Có 1 trường dữ liệu trả về
                {
                    DungChung.User = dt.Rows[0]["ID_nhan_vien"].ToString();
                    sql = string.Format(@"SELECT Nhan_vien.ID_nhan_vien, Chuc_Nang.moTa
                                            FROM Nhan_vien INNER JOIN (Chuc_Nang INNER JOIN Quyen_ChucNang ON Chuc_Nang.ID_chucNang = Quyen_ChucNang.ID_chucNang) ON Nhan_vien.ID_quyen = Quyen_ChucNang.ID_quyen
                                            WHERE (((Nhan_vien.ID_nhan_vien)='{0}'));", DungChung.User);
                    dt = DungChung.getDataTable(sql);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DungChung.chucnangUser += dt.Rows[i]["moTa"].ToString() + ",";
                    }
                    this.Hide();
                    Form1 frm = new Form1();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại vui lòng kiểm tra User name & Password của bạn!!!");
                }
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn tắt?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            Close();
        }

        private void Rastourar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Rastourar.Visible = false;
            Maximizar.Visible = true;
        }

        private void Maximizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Maximizar.Visible = false;
            Rastourar.Visible = true;
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
