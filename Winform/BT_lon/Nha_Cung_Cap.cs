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
using System.Text.RegularExpressions;

namespace BT_lon
{
    public partial class Nha_Cung_Cap : UserControl
    {
        public Nha_Cung_Cap()
        {
            InitializeComponent();
        }

        protected void GetNhacungcap()
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT Nha_cung_cap.ID_nha_cung_cap, Nha_cung_cap.Ten_nha_cung_cap, Nha_cung_cap.Dia_chi, Nha_cung_cap.Email, Nha_cung_cap.Dien_thoai, Nha_cung_cap.Ngay_tao, Nha_cung_cap.Ngay_cap_nhat FROM Nha_cung_cap", con);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                String sdt = tb.Rows[i]["Dien_thoai"].ToString();
            }
            view_nha_cung_cap.DataSource = tb;
            view_nha_cung_cap.Sort(this.view_nha_cung_cap.Columns["Ngay_tao"], ListSortDirection.Ascending);
            con.Close();
        }

        private void Nha_Cung_Cap_Load(object sender, EventArgs e)
        {
            GetNhacungcap();
            ngaycapnhat.Enabled = false;
        }

        private void nhacungcap_rowenter(object sender, DataGridViewCellEventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            string sql = string.Format("SELECT * FROM Nha_cung_cap WHERE ID_nha_cung_cap ='{0}'", view_nha_cung_cap.Rows[e.RowIndex].Cells[0].Value);
            OleDbDataAdapter ad = new OleDbDataAdapter(sql, con);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            idnhacungcap.Text = tb.Rows[0]["ID_nha_cung_cap"].ToString();
            idnhacungcap.Enabled = false;
            diachi.Text = tb.Rows[0]["Dia_chi"].ToString();
            tennhacungcap.Text = tb.Rows[0]["Ten_nha_cung_cap"].ToString();
            gmaill.Text = tb.Rows[0]["Email"].ToString();
            sodienthoai.Text = tb.Rows[0]["Dien_thoai"].ToString();
            con.Close();
        }

        private void sodienthoai_keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void email_leave(object sender, EventArgs e)
        {
            string email = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(gmaill.Text, email))
            {
            }
            else
            {
                MessageBox.Show("Email nhập sai mời nhập lại!");
                return;
            }
        }

        private void xem_tat_ca_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT Nha_cung_cap.ID_nha_cung_cap, Nha_cung_cap.Ten_nha_cung_cap, Nha_cung_cap.Dia_chi, Nha_cung_cap.Email, Nha_cung_cap.Dien_thoai, Nha_cung_cap.Ngay_tao, Nha_cung_cap.Ngay_cap_nhat FROM Nha_cung_cap", con);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            view_nha_cung_cap.DataSource = tb;
            view_nha_cung_cap.Sort(this.view_nha_cung_cap.Columns["Ngay_tao"], ListSortDirection.Ascending);
            con.Close();
        }

        private void btn_NV_Xoa_Click(object sender, EventArgs e)
        {
            if ((tennhacungcap.Text == "") && (diachi.Text == "") && (gmaill.Text == "") && (sodienthoai.Text == ""))
            {
                MessageBox.Show("không có dữ liệu được chọn mời chọn lại !!!");
                return;
            }
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            string sql = string.Format(@"DELETE Nha_cung_cap.* FROM Nha_cung_cap WHERE ID_nha_cung_cap = '" + idnhacungcap.Text + "' ");
            OleDbCommand cmd = new OleDbCommand(sql, con);
            if (MessageBox.Show("Nếu xóa dữ liệu ở bảng này có thể ảnh hướng đến các bạn khác bạn có chắc muốn xóa ???", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                cmd.ExecuteNonQuery();
            GetNhacungcap();
            con.Close();
            xem_tat_ca_Click(sender, e);
        }

        private void btn_NV_Luu_Click(object sender, EventArgs e)
        {
            if (tennhacungcap.Text == "" || diachi.Text == "" || gmaill.Text == "" || sodienthoai.Text == "") MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
            else
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
                con.Open();
                string sql = string.Format("UPDATE Nha_cung_cap set Ten_nha_cung_cap ='" + tennhacungcap.Text + "', Dia_chi ='" + diachi.Text + "', Email ='" + gmaill.Text + "',Dien_thoai ='" + sodienthoai.Text + "', Ngay_cap_nhat ='" + ngaycapnhat.Text + "'WHERE ID_nha_cung_cap ='" + idnhacungcap.Text + "'");
                OleDbCommand cmd = new OleDbCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thông tin trong bảng nhà cung cấp đã được sửa thành công.");
                GetNhacungcap();
            }
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
            for (int i = 1; i <= view_nha_cung_cap.Columns.Count; i++)
            {
                worksheet.Cells[1, i] = view_nha_cung_cap.Columns[i - 1].Name;
            }
            //ghi dữ liệu vào file excel trừ cột chọn và sửa
            for (int i = 0; i < view_nha_cung_cap.Rows.Count; i++)
            {
                for (int j = 0; j < view_nha_cung_cap.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = view_nha_cung_cap.Rows[i].Cells[j].Value.ToString();
                }
            }
            //định dạng tên file và đuôi file
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = String.Format("Nha_cung_cap-{0}", DateTime.Now.ToString("dd-MM-yyyy-h-mm-tt"));
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
            Them_Nha_Cung_Cap nhacungcap = new Them_Nha_Cung_Cap();
            nhacungcap.ShowDialog();
        }

        private void TK_textChanged(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            String sql = "SELECT Nha_cung_cap.ID_nha_cung_cap, Nha_cung_cap.Ten_nha_cung_cap, Nha_cung_cap.Dia_chi, Nha_cung_cap.Email, Nha_cung_cap.Dien_thoai, Nha_cung_cap.Ngay_tao, Nha_cung_cap.Ngay_cap_nhat FROM Nha_cung_cap WHERE ID_nha_cung_cap LIKE '%" + TK.Text + "%' OR Ten_nha_cung_cap LIKE '%" + TK.Text + "%' OR Dia_chi LIKE '%" + TK.Text + "%' OR Email LIKE '%" + TK.Text + "%' OR Dien_thoai LIKE '%" + TK.Text + "%' OR Ngay_tao LIKE '%" + TK.Text + "%' OR Ngay_cap_nhat LIKE '%" + TK.Text + "%'";
            OleDbDataAdapter ad = new OleDbDataAdapter(sql, con);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            view_nha_cung_cap.DataSource = tb;
            view_nha_cung_cap.Sort(this.view_nha_cung_cap.Columns["Ngay_tao"], ListSortDirection.Ascending);
            con.Close();
        }

        private void view_nha_cung_cap_rowenter(object sender, DataGridViewCellEventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["baitaplon"].ToString();
            con.Open();
            string sql = string.Format("SELECT * FROM Nha_cung_cap WHERE ID_nha_cung_cap ='{0}'", view_nha_cung_cap.Rows[e.RowIndex].Cells[0].Value);
            OleDbDataAdapter ad = new OleDbDataAdapter(sql, con);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            idnhacungcap.Text = tb.Rows[0]["ID_nha_cung_cap"].ToString();
            idnhacungcap.Enabled = false;
            diachi.Text = tb.Rows[0]["Dia_chi"].ToString();
            tennhacungcap.Text = tb.Rows[0]["Ten_nha_cung_cap"].ToString();
            gmaill.Text = tb.Rows[0]["Email"].ToString();
            sodienthoai.Text = tb.Rows[0]["Dien_thoai"].ToString();
            con.Close();
        }

    }
}
