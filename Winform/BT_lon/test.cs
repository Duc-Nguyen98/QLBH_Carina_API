using System;
using System.Windows.Forms;

namespace BT_lon
{
    public partial class test : Form
    {

        public test()
        {
            InitializeComponent();
        }

        private void test_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void bao_tri_Click(object sender, EventArgs e)
        {
            //Process.Start("QLBH_Carina_API/Table_khach_hang.aspx");
            System.Diagnostics.Process.Start("chrome.exe", "https://localhost:44360/login.aspx");
        }

    }
}
