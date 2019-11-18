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
    public partial class San_Pham : UserControl
    {
        public San_Pham()
        {
            InitializeComponent();
        }
        protected void Getsanpham()
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT Mat_hang.ID_mat_hang, Phan_loai.Ten_phan_loai, Nha_cung_cap.Ten_nha_cung_cap, Mat_hang.Ten_hang, Mat_hang.So_luong, Mat_hang.Don_vi_tinh, Mat_hang.Gia_hang, Mat_hang.Ngay_tao, Mat_hang.Ngay_cap_nhat FROM Nha_cung_cap INNER JOIN (Phan_loai INNER JOIN Mat_hang ON Phan_loai.ID_phan_loai = Mat_hang.ID_phan_loai) ON Nha_cung_cap.ID_nha_cung_cap = Mat_hang.ID_nha_cung_cap", con);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            view_san_pham.DataSource = tb;
            con.Close();
        }
        private void San_Pham_Load(object sender, EventArgs e)
        {
            Getsanpham();

            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT Nha_cung_cap.ID_nha_cung_cap, Ten_nha_cung_cap FROM Nha_cung_cap", con);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            tennhacungcap.ValueMember = "ID_nha_cung_cap";
            tennhacungcap.DisplayMember = "Ten_nha_cung_cap";
            tennhacungcap.DataSource = tb;
            //tennhacungcap.AutoCompleteMode = AutoCompleteMode.Suggest;
            //tennhacungcap.AutoCompleteSource = AutoCompleteSource.ListItems;
            OleDbDataAdapter add = new OleDbDataAdapter("SELECT Phan_loai.ID_phan_loai,Ten_phan_loai FROM Phan_loai", con);
            DataTable tbb = new DataTable();
            add.Fill(tbb);
            tenphanloai.ValueMember = "ID_phan_loai";
            tenphanloai.DisplayMember = "Ten_phan_loai";
            tenphanloai.DataSource = tbb;
            //tenphanloai.AutoCompleteMode = AutoCompleteMode.Suggest;
            //tenphanloai.AutoCompleteSource = AutoCompleteSource.ListItems;
            ngaycapnhat.Enabled = false;
            con.Close();

        }

        private void xem_tat_ca_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT Mat_hang.ID_mat_hang, Phan_loai.Ten_phan_loai, Nha_cung_cap.Ten_nha_cung_cap, Mat_hang.Ten_hang, Mat_hang.So_luong, Mat_hang.Don_vi_tinh, Mat_hang.Gia_hang, Mat_hang.Ngay_tao, Mat_hang.Ngay_cap_nhat FROM Nha_cung_cap INNER JOIN (Phan_loai INNER JOIN Mat_hang ON Phan_loai.ID_phan_loai = Mat_hang.ID_phan_loai) ON Nha_cung_cap.ID_nha_cung_cap = Mat_hang.ID_nha_cung_cap", con);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            view_san_pham.DataSource = tb;
            con.Close();
        }

        private void view_san_pham_row_enter(object sender, DataGridViewCellEventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            string sql = string.Format("SELECT Mat_hang.ID_mat_hang, Phan_loai.Ten_phan_loai, Nha_cung_cap.Ten_nha_cung_cap, Mat_hang.Ten_hang, Mat_hang.So_luong, Mat_hang.Don_vi_tinh, Mat_hang.Gia_hang, Mat_hang.Ngay_tao, Mat_hang.Ngay_cap_nhat FROM Nha_cung_cap INNER JOIN (Phan_loai INNER JOIN Mat_hang ON Phan_loai.ID_phan_loai = Mat_hang.ID_phan_loai) ON Nha_cung_cap.ID_nha_cung_cap = Mat_hang.ID_nha_cung_cap WHERE ID_mat_hang ='{0}'", view_san_pham.Rows[e.RowIndex].Cells[0].Value);
            OleDbDataAdapter ad = new OleDbDataAdapter(sql, con);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            idmathang.Text = tb.Rows[0]["ID_mat_hang"].ToString();
            idmathang.Enabled = false;
            tenphanloai.Text = tb.Rows[0]["Ten_phan_loai"].ToString();
            tennhacungcap.Text = tb.Rows[0]["Ten_nha_cung_cap"].ToString();
            tenhang.Text = tb.Rows[0]["Ten_hang"].ToString();
            soluong.Text = tb.Rows[0]["So_luong"].ToString();
            donvitinh.Text = tb.Rows[0]["Don_vi_tinh"].ToString();
            giaban.Text = tb.Rows[0]["Gia_hang"].ToString();
            con.Close();
        }

        private void btn_NV_Xoa_Click(object sender, EventArgs e)
        {
            if ((tenphanloai.Text == "") && (tennhacungcap.Text == "") && (tenhang.Text == "") && (soluong.Text == "") && (donvitinh.Text == "") && (giaban.Text == ""))
            {
                MessageBox.Show("không có dữ liệu được chọn mời chọn lại !!!");
                return;
            }
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            string sql = string.Format(@"DELETE Nhan_vien.* FROM Mat_hang WHERE ID_mat_hang = '" + idmathang.Text + "' ");
            OleDbCommand cmd = new OleDbCommand(sql, con);
            if (MessageBox.Show("Nếu Xóa Dữ liệu ở bảng này có thể ảnh hướng đến các bạn khác bạn có chắc muốn xóa ???", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                cmd.ExecuteNonQuery();
            Getsanpham();
            con.Close();
            xem_tat_ca_Click(sender, e);
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
            for (int i = 1; i <= view_san_pham.Columns.Count; i++)
            {
                worksheet.Cells[1, i] = view_san_pham.Columns[i - 1].Name;
            }
            //ghi dữ liệu vào file excel trừ cột chọn và sửa
            for (int i = 0; i < view_san_pham.Rows.Count; i++)
            {
                for (int j = 0; j < view_san_pham.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = view_san_pham.Rows[i].Cells[j].Value.ToString();
                }
            }
            //định dạng tên file và đuôi file
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = String.Format("San_pham-{0}", DateTime.Now.ToString("dd-MM-yyyy-h-mm-tt"));
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

        private void btn_NV_Luu_Click(object sender, EventArgs e)
        {
            if (tenphanloai.Text == "" || tennhacungcap.Text == "" || tenhang.Text == "" || soluong.Text == "" || donvitinh.Text == "" || giaban.Text == "") MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
            else
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
                con.Open();
                string sql = string.Format(@"update Mat_hang set ID_phan_loai ='" + tenphanloai.SelectedValue + "', ID_nha_cung_cap ='" + tennhacungcap.SelectedValue + "', Ten_hang ='" + tenhang.Text + "', So_luong ='" + soluong.Text + "', Don_vi_tinh ='" + donvitinh.Text + "',Gia_hang ='" + giaban.Text + "',Ngay_cap_nhat ='" + ngaycapnhat.Text + "'WHERE ID_mat_hang ='" + idmathang.Text + "'");
                OleDbCommand cmd = new OleDbCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thông tin trong bảng sản phẩm đã được sửa thành công.");
                Getsanpham();
            }
        }

        private void soluong_press(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void giaban_keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_NV_Them_Click(object sender, EventArgs e)
        {
            Them_SP themsanpham =new Them_SP();
            themsanpham.ShowDialog();
        }

        private void TK_san_pham(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            String sql = "SELECT Mat_hang.ID_mat_hang, Phan_loai.Ten_phan_loai, Nha_cung_cap.Ten_nha_cung_cap, Mat_hang.Ten_hang, Mat_hang.So_luong, Mat_hang.Don_vi_tinh, Mat_hang.Gia_hang, Mat_hang.Ngay_tao, Mat_hang.Ngay_cap_nhat FROM Nha_cung_cap INNER JOIN (Phan_loai INNER JOIN Mat_hang ON Phan_loai.ID_phan_loai = Mat_hang.ID_phan_loai) ON Nha_cung_cap.ID_nha_cung_cap = Mat_hang.ID_nha_cung_cap WHERE Mat_hang.ID_mat_hang LIKE '%" + TK.Text + "%' OR Phan_loai.Ten_phan_loai LIKE '%" + TK.Text + "%' OR Nha_cung_cap.Ten_nha_cung_cap LIKE '%" + TK.Text + "%' OR Mat_hang.Ten_hang LIKE '%" + TK.Text + "%' OR Mat_hang.So_luong LIKE '%" + TK.Text + "%' OR Mat_hang.Don_vi_tinh LIKE '%" + TK.Text + "%' OR Mat_hang.Gia_hang LIKE '%" + TK.Text + "%' OR Mat_hang.Ngay_tao LIKE '%" + TK.Text + "%' OR Mat_hang.Ngay_cap_nhat LIKE '%" + TK.Text + "%'";
            OleDbDataAdapter ad = new OleDbDataAdapter(sql, con);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            view_san_pham.DataSource = tb;
            con.Close();
        }
    }
}
