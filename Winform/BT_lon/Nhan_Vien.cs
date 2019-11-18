using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace BT_lon
{
    public partial class Nhan_Vien : UserControl
    {
        public Nhan_Vien()
        {
            InitializeComponent();
        }

        private void btn_NV_Them_Click(object sender, EventArgs e)
        {
            Them_NV f3x = new Them_NV();
            f3x.ShowDialog();
        }
        protected void GetNhanvien()
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT Nhan_vien.ID_nhan_vien, Phan_quyen.Ten_quyen, Nhan_vien.Ho, Nhan_vien.Ten, Nhan_vien.Ngay_sinh, Nhan_vien.Que_quan, Nhan_vien.Trang_thai_lam_viec, Nhan_vien.Dia_chi, Nhan_vien.Dien_thoai, Nhan_vien.Ten_dang_nhap, Nhan_vien.Mat_khau, Nhan_vien.Ngay_tao, Nhan_vien.Ngay_cap_nhat FROM Phan_quyen INNER JOIN Nhan_vien ON Phan_quyen.ID_quyen = Nhan_vien.ID_quyen", con);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                String sdt = tb.Rows[i]["Dien_thoai"].ToString();
            }
            view_nhan_vien.DataSource = tb;
            con.Close();
        }

        private void Nhan_Vien_Load(object sender, EventArgs e)
        {

            GetNhanvien();
            ngaycapnhat.Enabled = false;
        }

        private void TK_TEN(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            String sql = "SELECT Nhan_vien.ID_nhan_vien, Phan_quyen.Ten_quyen, Nhan_vien.Ho, Nhan_vien.Ten, Nhan_vien.Ngay_sinh, Nhan_vien.Que_quan, Nhan_vien.Trang_thai_lam_viec, Nhan_vien.Dia_chi, Nhan_vien.Dien_thoai, Nhan_vien.Ten_dang_nhap, Nhan_vien.Mat_khau, Nhan_vien.Ngay_tao, Nhan_vien.Ngay_cap_nhat FROM Phan_quyen INNER JOIN Nhan_vien ON Phan_quyen.ID_quyen = Nhan_vien.ID_quyen WHERE Nhan_vien.ID_nhan_vien LIKE '%" + TK.Text + "%' OR Nhan_vien.Ho LIKE '%" + TK.Text + "%' OR Nhan_vien.Ten LIKE '%" + TK.Text + "%' OR Nhan_vien.Ngay_sinh LIKE '%" + TK.Text + "%' OR Nhan_vien.Que_quan LIKE '%" + TK.Text + "%' OR Nhan_vien.Trang_thai_lam_viec LIKE '%" + TK.Text + "%' OR Nhan_vien.Dia_chi LIKE '%" + TK.Text + "%' OR Nhan_vien.Dien_thoai LIKE '%" + TK.Text + "%' OR Phan_quyen.Ten_quyen LIKE '%" + TK.Text + "%' OR Nhan_vien.Ten_dang_nhap LIKE '%" + TK.Text + "%' OR Nhan_vien.Ngay_tao LIKE '%" + TK.Text + "%' OR Nhan_vien.Ngay_cap_nhat LIKE '%" + TK.Text + "%'";
            OleDbDataAdapter ad = new OleDbDataAdapter(sql, con);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            view_nhan_vien.DataSource = tb;
            con.Close();
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
            for (int i = 1; i <= view_nhan_vien.Columns.Count; i++)
            {
                worksheet.Cells[1, i] = view_nhan_vien.Columns[i - 1].Name;
            }
            //ghi dữ liệu vào file excel trừ cột chọn và sửa
            for (int i = 0; i < view_nhan_vien.Rows.Count; i++)
            {
                for (int j = 0; j < view_nhan_vien.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = view_nhan_vien.Rows[i].Cells[j].Value.ToString();
                }
            }
            //định dạng tên file và đuôi file
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = String.Format("Nhan_vien-{0}", DateTime.Now.ToString("dd-MM-yyyy-h-mm-tt"));
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
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT Nhan_vien.ID_nhan_vien, Phan_quyen.Ten_quyen, Nhan_vien.Ho, Nhan_vien.Ten, Nhan_vien.Ngay_sinh, Nhan_vien.Que_quan, Nhan_vien.Trang_thai_lam_viec, Nhan_vien.Dia_chi, Nhan_vien.Dien_thoai, Nhan_vien.Ten_dang_nhap, Nhan_vien.Mat_khau, Nhan_vien.Ngay_tao, Nhan_vien.Ngay_cap_nhat FROM Phan_quyen INNER JOIN Nhan_vien ON Phan_quyen.ID_quyen = Nhan_vien.ID_quyen", con);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            view_nhan_vien.DataSource = tb;
            con.Close();
        }

        private void view_nhan_vien_row_enter(object sender, DataGridViewCellEventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            string sql = string.Format("SELECT Nhan_vien.ID_nhan_vien, Phan_quyen.Ten_quyen, Nhan_vien.Ho, Nhan_vien.Ten, Nhan_vien.Ngay_sinh, Nhan_vien.Que_quan, Nhan_vien.Trang_thai_lam_viec, Nhan_vien.Dia_chi, Nhan_vien.Dien_thoai, Nhan_vien.Ten_dang_nhap, Nhan_vien.Mat_khau, Nhan_vien.Ngay_tao, Nhan_vien.Ngay_cap_nhat FROM Phan_quyen INNER JOIN Nhan_vien ON Phan_quyen.ID_quyen = Nhan_vien.ID_quyen WHERE ID_nhan_vien ='{0}'", view_nhan_vien.Rows[e.RowIndex].Cells[0].Value);
            OleDbDataAdapter ad = new OleDbDataAdapter(sql, con);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            id.Text = tb.Rows[0]["ID_nhan_vien"].ToString();
            id.Enabled = false;

            if (tb.Rows[0]["Ten_quyen"].ToString().Equals("Quản lý"))
            {
                quanly.Checked = true;
            }
            else if (tb.Rows[0]["Ten_quyen"].ToString().Equals("Nhân viên"))
            {
                nhanvien.Checked = true;
            }

            ho.Text = tb.Rows[0]["Ho"].ToString();
            tenn.Text = tb.Rows[0]["Ten"].ToString();
            ngaysinh.Text = tb.Rows[0]["Ngay_sinh"].ToString();
            quequan.Text = tb.Rows[0]["Que_quan"].ToString();

            if (tb.Rows[0]["Trang_thai_lam_viec"].ToString().Equals("Đang Làm Việc"))
            {
                danglamviec.Checked = true;
            }
            else if (tb.Rows[0]["Trang_thai_lam_viec"].ToString().Equals("Nghỉ Việc"))
            {
                nghiviec.Checked = true;
            }


            diachi.Text = tb.Rows[0]["Dia_chi"].ToString();
            sodienthoai.Text = tb.Rows[0]["Dien_thoai"].ToString();
            tendangnhap.Text = tb.Rows[0]["Ten_dang_nhap"].ToString();
            matkhau.Text = tb.Rows[0]["Mat_khau"].ToString();
            con.Close();

        }

        string trangthailamviec = string.Empty;

        string phanquyen = string.Empty;

        private void quanly_CheckedChanged(object sender, EventArgs e)
        {
            phanquyen = "1";
        }

        private void nhanvien_CheckedChanged(object sender, EventArgs e)
        {
            phanquyen = "2";
        }

        private void danglamviec_CheckedChanged(object sender, EventArgs e)
        {
            trangthailamviec = "Đang Làm Việc";
        }

        private void nghiviec_CheckedChanged(object sender, EventArgs e)
        {
            trangthailamviec = "Nghỉ Việc";
        }

        private void so_dien_thoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_NV_Xoa_Click_1(object sender, EventArgs e)
        {
            if ((ho.Text == "") && (tenn.Text == "") && (quequan.Text == "") && (diachi.Text == "") && (sodienthoai.Text == "") && (tendangnhap.Text == "") && (matkhau.Text == ""))
            {
                MessageBox.Show("không có dữ liệu được chọn mời chọn lại !!!");
                return;
            }
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            string sql = string.Format(@"DELETE Nhan_vien.* FROM Nhan_vien WHERE ID_nhan_vien = '" + id.Text + "' ");
            OleDbCommand cmd = new OleDbCommand(sql, con);
            if (MessageBox.Show("Nếu xóa dữ liệu ở bảng này có thể ảnh hướng đến các bạn khác bạn có chắc muốn xóa ???", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                cmd.ExecuteNonQuery();
            GetNhanvien();
            con.Close();
            xem_tat_ca_Click(sender, e);
        }

        private void btn_NV_Luu_Click(object sender, EventArgs e)
        {
            if (ho.Text == "" || tenn.Text == "" || quequan.Text == "" || diachi.Text == "" || sodienthoai.Text == "" || tendangnhap.Text == "" || matkhau.Text == "") MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
            else
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
                con.Open();
                string sql = string.Format("UPDATE Nhan_vien set ID_quyen ='" + phanquyen + "', Ho ='" + ho.Text + "', Ten ='" + tenn.Text + "', Ngay_sinh ='" + ngaysinh.Text + "', Que_quan ='" + quequan.Text + "',Trang_thai_lam_viec ='" + trangthailamviec + "',Dia_chi ='" + diachi.Text + "',Dien_thoai ='" + sodienthoai.Text + "', Ten_dang_nhap ='" + tendangnhap.Text + "', Mat_khau ='" + matkhau.Text + "', Ngay_cap_nhat ='" + ngaycapnhat.Text + "'WHERE ID_nhan_vien ='" + id.Text + "'");
                OleDbCommand cmd = new OleDbCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thông tin trong bảng nhân viên đã được sửa thành công.");
                GetNhanvien();
            }
        }
    }
}
