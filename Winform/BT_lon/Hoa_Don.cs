using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace BT_lon
{
    public partial class Hoa_Don : UserControl
    {
        public Hoa_Don()
        {
            InitializeComponent();
        }

        protected void Gethoadon()
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT Hoa_don.ID_hoa_don, ([Khach_hang].[Ho]+' '+[Khach_hang].[Ten]) AS Ten_khach_hang, ([Nhan_vien].[Ho]+' '+[Nhan_vien].[Ten]) AS Ten_nhan_vien, Hoa_don.Dia_chi_giao_hang, Puong_thuc_thanh_toan.Ten_phuong_thuc, Trang_thai.Ten_trang_thai, (Format([Hoa_don].[Ngay_tao],'dd-mm-yyyy')) AS Ngay_tao, (Format([Hoa_don].[Ngay_cap_nhat],'dd-mm-yyyy')) AS Ngay_cap_nhat FROM Trang_thai INNER JOIN (Puong_thuc_thanh_toan INNER JOIN (Nhan_vien INNER JOIN (Khach_hang INNER JOIN Hoa_don ON Khach_hang.ID_khach_hang = Hoa_don.ID_khach_hang) ON Nhan_vien.ID_nhan_vien = Hoa_don.ID_nhan_vien) ON Puong_thuc_thanh_toan.ID_phuong_thuc = Hoa_don.ID_phuong_thuc) ON Trang_thai.ID_trang_thai = Hoa_don.ID_trang_thai", con);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            view_hoa_don.DataSource = tb;
            con.Close();
        }

        private void Hoa_Don_Load(object sender, EventArgs e)
        {
            Gethoadon();
        }


        private void xem_tat_ca_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT Hoa_don.ID_hoa_don, ([Khach_hang].[Ho]+' '+[Khach_hang].[Ten]) AS Ten_khach_hang, ([Nhan_vien].[Ho]+' '+[Nhan_vien].[Ten]) AS Ten_nhan_vien, Hoa_don.Dia_chi_giao_hang, Puong_thuc_thanh_toan.Ten_phuong_thuc, Trang_thai.Ten_trang_thai, (Format([Hoa_don].[Ngay_tao],'dd-mm-yyyy')) AS Ngay_tao, (Format([Hoa_don].[Ngay_cap_nhat],'dd-mm-yyyy')) AS Ngay_cap_nhat FROM Trang_thai INNER JOIN (Puong_thuc_thanh_toan INNER JOIN (Nhan_vien INNER JOIN (Khach_hang INNER JOIN Hoa_don ON Khach_hang.ID_khach_hang = Hoa_don.ID_khach_hang) ON Nhan_vien.ID_nhan_vien = Hoa_don.ID_nhan_vien) ON Puong_thuc_thanh_toan.ID_phuong_thuc = Hoa_don.ID_phuong_thuc) ON Trang_thai.ID_trang_thai = Hoa_don.ID_trang_thai", con);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            view_hoa_don.DataSource = tb;
            con.Close();
        }

        private void xuat_excel_Click_1(object sender, EventArgs e)
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
            saveFileDialog.FileName = String.Format("Hoa_don-{0}", DateTime.Now.ToString("dd-MM-yyyy-h-mm-tt"));
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

        private void btn_NV_Them_Click(object sender, EventArgs e)
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

        private void TK_Hoa_Don(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            String sql = "SELECT Hoa_don.ID_hoa_don, ([Khach_hang].[Ho]+' '+[Khach_hang].[Ten]) AS Ten_khach_hang, ([Nhan_vien].[Ho]+' '+[Nhan_vien].[Ten]) AS Ten_nhan_vien, Hoa_don.Dia_chi_giao_hang, Puong_thuc_thanh_toan.Ten_phuong_thuc, Trang_thai.Ten_trang_thai, (Format([Hoa_don].[Ngay_tao],'dd-mm-yyyy')) AS Ngay_tao, (Format([Hoa_don].[Ngay_cap_nhat],'dd-mm-yyyy')) AS Ngay_cap_nhat FROM Trang_thai INNER JOIN (Puong_thuc_thanh_toan INNER JOIN (Nhan_vien INNER JOIN (Khach_hang INNER JOIN Hoa_don ON Khach_hang.ID_khach_hang = Hoa_don.ID_khach_hang) ON Nhan_vien.ID_nhan_vien = Hoa_don.ID_nhan_vien) ON Puong_thuc_thanh_toan.ID_phuong_thuc = Hoa_don.ID_phuong_thuc) ON Trang_thai.ID_trang_thai = Hoa_don.ID_trang_thai WHERE Hoa_don.ID_hoa_don LIKE '%" + TK.Text + "%' OR Khach_hang.Ho LIKE '%" + TK.Text + "%' OR Khach_hang.Ten LIKE '%" + TK.Text + "%' OR Nhan_vien.Ho LIKE '%" + TK.Text + "%' OR Nhan_vien.Ten LIKE '%" + TK.Text + "%' OR Hoa_don.Dia_chi_giao_hang LIKE '%" + TK.Text + "%' OR Puong_thuc_thanh_toan.Ten_phuong_thuc LIKE '%" + TK.Text + "%' OR Trang_thai.Ten_trang_thai LIKE '%" + TK.Text + "%' OR Hoa_don.Ngay_tao LIKE '%" + TK.Text + "%' OR Hoa_don.Ngay_cap_nhat LIKE '%" + TK.Text + "%'";
            OleDbDataAdapter ad = new OleDbDataAdapter(sql, con);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            view_hoa_don.DataSource = tb;
            con.Close();
        }
    }
}
