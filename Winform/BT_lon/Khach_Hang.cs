using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;

namespace BT_lon
{
    public partial class Khach_Hang : UserControl
    {
        public Khach_Hang()
        {
            InitializeComponent();
        }

        protected void Getkhachhang()
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT Khach_hang.ID_khach_hang, ([Khach_hang].[Ho]+' '+[Khach_hang].[Ten]) AS Ten_khach_hang, Khach_hang.Ngay_sinh, Khach_hang.Que_quan, Khach_hang.Dia_chi, Khach_hang.Email, Khach_hang.Dien_thoai FROM Khach_hang", con);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            view_hoa_don.DataSource = tb;
            con.Close();
        }

        private void Khach_Hang_Load(object sender, EventArgs e)
        {
            Getkhachhang();
        }

        private void TK_textChanged(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            String sql = "SELECT Khach_hang.ID_khach_hang, ([Khach_hang].[Ho]+' '+[Khach_hang].[Ten]) AS Ten_khach_hang, Khach_hang.Ngay_sinh, Khach_hang.Que_quan, Khach_hang.Dia_chi, Khach_hang.Email, Khach_hang.Dien_thoai FROM Khach_hang WHERE Khach_hang.ID_khach_hang LIKE '%" + TK.Text + "%' OR Khach_hang.Ho LIKE '%" + TK.Text + "%' OR Khach_hang.Ten LIKE '%" + TK.Text + "%' OR Khach_hang.Ngay_sinh LIKE '%" + TK.Text + "%' OR Khach_hang.Que_quan LIKE '%" + TK.Text + "%' OR Khach_hang.Dia_chi LIKE '%" + TK.Text + "%' OR Khach_hang.Email LIKE '%" + TK.Text + "%' OR Khach_hang.Dien_thoai LIKE '%" + TK.Text + "%'";
            OleDbDataAdapter ad = new OleDbDataAdapter(sql, con);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            view_hoa_don.DataSource = tb;
            con.Close();
        }

        private void btn_NV_Them_Click_1(object sender, EventArgs e)
        {
            test link_web = new test();
            link_web.ShowDialog();
        }

        private void btn_NV_Luu_Click(object sender, EventArgs e)
        {
            test link_web = new test();
            link_web.ShowDialog();
        }

        private void btn_NV_Xoa_Click(object sender, EventArgs e)
        {
            test link_web = new test();
            link_web.ShowDialog();
        }

        private void xuat_excel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Sheet1";

            //ghi tên cột cho file excel từ dgvChucNang ngoài form trừ cột chọn và sửa
            for (int i = 1; i <= view_hoa_don.Columns.Count; i++)
            {
                worksheet.Cells[1, i] = view_hoa_don.Columns[i - 1].Name;
            }
            //ghi dữ liệu vào file excel trừ cột chọn và sửa
            for (int i = 0; i < view_hoa_don.Rows.Count; i++)
            {
                for (int j = 0; j < view_hoa_don.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = view_hoa_don.Rows[i].Cells[j].Value.ToString();
                }
            }
            //định dạng tên file và đuôi file
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = String.Format("Khach_hang-{0}", DateTime.Now.ToString("dd-MM-yyyy-h-mm-tt"));
            saveFileDialog.DefaultExt = ".xls";
            DialogResult dialog = saveFileDialog.ShowDialog();
            Microsoft.Office.Interop.Excel.XlSaveAsAccessMode AccessMode = Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive;
            //mở quản lý file, nếu ấn ok thì file sẽ được lưu
            if (dialog == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel8, Type.Missing, Type.Missing, Type.Missing, Type.Missing, AccessMode, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                MessageBox.Show("Export thành công!");
            }
        }

        private void xem_tat_ca_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT Khach_hang.ID_khach_hang, ([Khach_hang].[Ho]+' '+[Khach_hang].[Ten]) AS Ten_khach_hang, Khach_hang.Ngay_sinh, Khach_hang.Que_quan, Khach_hang.Dia_chi, Khach_hang.Email, Khach_hang.Dien_thoai FROM Khach_hang", con);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            view_hoa_don.DataSource = tb;
            con.Close();
        }

    }
}
