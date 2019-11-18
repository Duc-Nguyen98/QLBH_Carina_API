using buoi_4;
using System;
using System.Data;
// khai báo
using System.Data.OleDb;

namespace QLBH_Carina_API
{
    public partial class login21 : System.Web.UI.Page
    {
        Data_provider data_ = new Data_provider();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                Response.Redirect("~/home2.aspx");
            }

        }

        protected void gui_Click(object sender, EventArgs e)
        {
            string conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\ducni\OneDrive\Desktop\viewvi\Database\DB_QLBH.mdb"; // chuỗi để kết nối tới sql 
            OleDbConnection ketnoi = new OleDbConnection(conn); // thực thi kết nối
            ketnoi.Open();
            string query = "SELECT * FROM Nhan_vien WHERE Ten_dang_nhap = '" + txtusername.Text + "' AND Mat_khau = '" + txtpassword.Text + "';";
            OleDbDataAdapter oda = new OleDbDataAdapter(query, ketnoi);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            ketnoi.Close();
            if (dt.Rows.Count > 0)
            {
                Session["User"] = txtusername.Text;
                Session["TenNhanVien"] = dt.Rows[0]["Ten"].ToString();
                Session["TenNhanVien2"] = dt.Rows[0]["Ho"].ToString() + " " + dt.Rows[0]["Ten"].ToString();
                Session["Email"] = dt.Rows[0]["Email"].ToString();
                Response.Redirect("~/home2.aspx");
            }

            else
            {
                Response.Write("Bạn đã nhập sai tên đăng nhập hoặc mật khẩu !");
            }
        }

        protected void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtusername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}