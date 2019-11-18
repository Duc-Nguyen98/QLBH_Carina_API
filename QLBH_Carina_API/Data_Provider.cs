using System;
using System.Configuration;
using System.Data;
// khai báo
using System.Data.OleDb;

namespace buoi_4
{
    class Data_provider
    {
        OleDbConnection cnn;
        OleDbDataAdapter da;
        DataSet ds;
        OleDbCommand cmd;
        // Phương thức kết nối
        public void Connect()
        {
            // gọi chuỗi kết nối từ appconfig(wìnform) và webconfig(web phờ rom :)))
            string connectionString = ConfigurationManager.ConnectionStrings["QLBH_Carina"].ToString();
            // kiểm tra có connection chư nếu chưa thì khở tạo
            if (cnn == null)
            {
                cnn = new OleDbConnection();
                cnn.ConnectionString = connectionString;
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
            }
            else
            {
                cnn.ConnectionString = connectionString;
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
            }

        }
        // Phương thức đóng kết nối
        public void Disconnect()
        {

            // Kiểm tra tổn tại connection và trạng thái của nó nếu là open thì đóng
            if (cnn != null && cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
        }
        // hàm lấy dữ liệu
        public DataSet Get(string sql)
        {
            Connect();
            da = new OleDbDataAdapter(sql, cnn);
            ds = new DataSet();
            da.Fill(ds);
            Disconnect();
            return ds;
        }

        // hàm sửa xóa
        public Boolean ExeCuteNonQuery(string sql)
        {
            try
            {
                Connect();
                cmd = new OleDbCommand(sql, cnn);
                //cnn.Open();
                cmd.ExecuteNonQuery();
                Disconnect();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }


    }
}
