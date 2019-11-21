using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace BT_lon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chuyen_dong.Height = btn_1.Height;
            chuyen_dong.Top = btn_1.Top;
            home1.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
            //button4.Enabled = DungChung.chucnangUser.IndexOf(button4.Tag.ToString()) > -1;
            //btn_1.Enabled = DungChung.chucnangUser.IndexOf(btn_1.Tag.ToString()) > -1;
            btn_2.Enabled = DungChung.chucnangUser.IndexOf(btn_2.Tag.ToString()) > -1;
            btn_3.Enabled = DungChung.chucnangUser.IndexOf(btn_2.Tag.ToString()) > -1;
            //btn_4.Enabled = DungChung.chucnangUser.IndexOf(btn_2.Tag.ToString()) > -1;
            //btn_5.Enabled = DungChung.chucnangUser.IndexOf(btn_2.Tag.ToString()) > -1;
            //btn_6.Enabled = DungChung.chucnangUser.IndexOf(btn_2.Tag.ToString()) > -1;
            //btn_7.Enabled = DungChung.chucnangUser.IndexOf(btn_2.Tag.ToString()) > -1;
            //btn_8.Enabled = DungChung.chucnangUser.IndexOf(btn_2.Tag.ToString()) > -1;
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            chuyen_dong.Height = btn_1.Height;
            chuyen_dong.Top = btn_1.Top;
            home1.BringToFront();
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            chuyen_dong.Height = btn_2.Height;
            chuyen_dong.Top = btn_2.Top;
            nhan_Vien1.BringToFront();

        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            chuyen_dong.Height = btn_3.Height;
            chuyen_dong.Top = btn_3.Top;
            nha_Cung_Cap1.BringToFront();

        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            chuyen_dong.Height = btn_4.Height;
            chuyen_dong.Top = btn_4.Top;
            san_Pham1.BringToFront();
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            chuyen_dong.Height = btn_6.Height;
            chuyen_dong.Top = btn_6.Top;
            hoa_Don1.BringToFront();
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            chuyen_dong.Height = btn_7.Height;
            chuyen_dong.Top = btn_7.Top;
            khach_Hang1.BringToFront();
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            chuyen_dong.Height = btn_8.Height;
            chuyen_dong.Top = btn_8.Top;
            huong_Su_Dung1.BringToFront();
           
        }

        private void logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DungChung.User = "";
                DungChung.chucnangUser = "";
                this.Close();
                Login_form ss = new Login_form();
                ss.Show();
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cap_nhat_MK ss = new Cap_nhat_MK();
            ss.ShowDialog();
        }


        private void Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("chrome.exe", "https://www.facebook.com/messages/t/2420616157977380");  
        }

        private void link_facebook_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void link_github_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void link_slack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("chrome.exe", "https://github.com/Duc-Nguyen98/QLBH_Carina_API"); 
        }

        private void button3_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("chrome.exe", " https://app.slack.com/client/TM9TCR1GX/CM81YN93J/details/pins"); 
        }

    }
}
