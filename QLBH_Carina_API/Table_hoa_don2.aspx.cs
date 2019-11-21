using System;
using System.Net;
using System.Net.Mail;

namespace QLBH_Carina_API
{
    public partial class Table_hoa_don2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

    //    protected void SendMail_Click(object sender, EventArgs e)
    //    {
    //        var fromAddress = new MailAddress("banhangcarina@gmail.com", "From Name");
    //        var toAddress = new MailAddress("ducnin1998@gmail.com", "To Name");
    //        const string fromPassword = "carina1234";
    //        const string subject = "Yêu Cầu Thanh Toán Hóa Đơn Của Carina";
    //        const string body = "nooi dung mail";

    //        var smtp = new SmtpClient
    //        {
    //            Host = "smtp.gmail.com",
    //            Port = 587,
    //            EnableSsl = true,
    //            DeliveryMethod = SmtpDeliveryMethod.Network,
    //            UseDefaultCredentials = false,
    //            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
    //        };
    //        using (var message = new MailMessage(fromAddress, toAddress)
    //        {
    //            Subject = subject,
    //            Body = body
    //        })
    //        {
    //            smtp.Send(message);
    //        }
    //        // call javascript function
    //        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallSweetAlert", "sendmail()", true);
    //    }
    }
}