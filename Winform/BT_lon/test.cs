using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

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
            System.Diagnostics.Process.Start("chrome.exe", "C:\\Users\\dauquan\\Desktop\\QLBH_Carina_API\\QLBH_Carina_API\\home.aspx");  
        }

    }
}
