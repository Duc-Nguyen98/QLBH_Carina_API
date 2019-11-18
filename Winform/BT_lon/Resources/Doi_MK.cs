using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace BT_lon.Resources
{
    public partial class Doi_MK : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\BT Visual\BT_lon\DB_QLBH.mdb");
        public Doi_MK()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if(txtcu.Text <> Ten_dang_nhap)Then



        }

        private void Doi_MK_Load(object sender, EventArgs e)
        {

        }
    }
}
