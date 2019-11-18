using System;

namespace QLBH_Carina_API
{
    public partial class Site2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/login.aspx");
            }

            lbNgDung.Text = Session["TenNhanVien"].ToString();
            lbEmail.Text = Session["Email"].ToString();
            lbNgDung2.Text = Session["TenNhanVien2"].ToString();
        }

        protected void Btnlogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/login.aspx");
        }
    }
}