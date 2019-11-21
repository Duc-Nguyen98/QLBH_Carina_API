using buoi_4;
using System;
using System.Data;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Mail;

namespace QLBH_Carina_API.Controllers
{
    public class HoaDon_ChiTietController : ApiController
    {
        Data_provider data_ = new Data_provider();

        public object ID_hoa_don_mail { get; private set; }

        //<---------- Xử lý phần hóa đơn ------------>

        // Xem Hoa  Don
        [HttpGet]
        // view bang hoa don
        public DataTable BangHoaDon()
        {
            string querry = "SELECT Hoa_don.ID_hoa_don, Hoa_don.ID_khach_hang, Hoa_don.ID_nhan_vien, Hoa_don.Dia_chi_giao_hang,(Format([Hoa_don].[Ngay_tao],'dd-mm-yyyy')) AS Ngay_tao, (Format([Hoa_don].[Ngay_cap_nhat],'dd-mm-yyyy')) AS Ngay_cap_nhat, Hoa_don.ID_trang_thai, Hoa_don.ID_phuong_thuc, (Nhan_vien.Ho+' '+Nhan_vien.Ten) AS Ten_nhan_vien, (Khach_hang.Ho+' '+Khach_hang.Ten) AS Ten_khach_hang, Puong_thuc_thanh_toan.Ten_phuong_thuc, Trang_thai.Ten_trang_thai, Khach_hang.Dien_thoai, Khach_hang.Email FROM Trang_thai INNER JOIN (Puong_thuc_thanh_toan INNER JOIN (Nhan_vien INNER JOIN (Khach_hang INNER JOIN Hoa_don ON Khach_hang.ID_khach_hang = Hoa_don.ID_khach_hang) ON Nhan_vien.ID_nhan_vien = Hoa_don.ID_nhan_vien) ON Puong_thuc_thanh_toan.ID_phuong_thuc = Hoa_don.ID_phuong_thuc) ON Trang_thai.ID_trang_thai = Hoa_don.ID_trang_thai ORDER BY Hoa_don.ID_hoa_don; ";
            DataTable dt = new DataTable();
            dt = data_.Get(querry).Tables[0];
            return dt;
        }

        // them hoa don
        [HttpPost]
        public Boolean TaoMoiHoaDon()
        {

            try
            {

                string ID_hoa_don = GenerateBillCode();
                string ID_khach_hang = HttpContext.Current.Request.Form["ID_khach_hang"];
                string ID_nhan_vien = HttpContext.Current.Request.Form["ID_nhan_vien"];
                string Dia_chi_giao_hang = HttpContext.Current.Request.Form["Dia_chi_giao_hang"];
                string ID_phuong_thuc = HttpContext.Current.Request.Form["ID_phuong_thuc"];
                string ID_trang_thai = HttpContext.Current.Request.Form["ID_trang_thai"];

                string querry2 = "INSERT INTO Hoa_don ( ID_hoa_don, ID_khach_hang, ID_nhan_vien, Dia_chi_giao_hang, ID_phuong_thuc, ID_trang_thai )  VALUES('" + ID_hoa_don + "', '" + ID_khach_hang + "', '" + ID_nhan_vien + "' , '" + Dia_chi_giao_hang + "', " + ID_phuong_thuc + ", " + ID_trang_thai + ");";
                Boolean check = data_.ExeCuteNonQuery(querry2);
                if (check)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        // mã tự sinh 
        private String GenerateBillCode()
        {
            string returnString = "MHD";
            try

            {

                string querry4 = ("SELECT max(Hoa_don.ID_hoa_don) AS ExtractString FROM Hoa_don;");

                DataTable dt = new DataTable();
                dt = data_.Get(querry4).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    string ExtractString = row["ExtractString"].ToString().Substring(3);
                    int Convert_string = Convert.ToInt32(ExtractString);
                    returnString = returnString + (Convert_string + (1));
                    return returnString;
                }
                else
                {
                    return returnString;
                }
            }
            catch (Exception ex)
            {

                return returnString + "001";
                throw ex;
            }
        }

        // danh muc nhan vien 
        [HttpGet]
        public DataTable DanhMucNhanVien()
        {

            string querry6 = ("SELECT Nhan_vien.ID_nhan_vien, [Ho]+' '+[Ten] AS Ten_nhan_vien FROM Nhan_vien;");

            DataTable dt = new DataTable();
            dt = data_.Get(querry6).Tables[0];
            return dt;
        }

        // danh muc khach hang
        [HttpGet]
        public DataTable DanhMucKhachHang()
        {
            string querry5 = ("SELECT Khach_hang.ID_khach_hang, [Ho]+ ' ' +[Ten] AS Ten_khach_hang FROM Khach_hang;");
            DataTable dt = new DataTable();
            dt = data_.Get(querry5).Tables[0];
            return dt;
        }

        // danh muc phuong thuc
        [HttpGet]
        public DataTable DanhMucPhuongThuc()
        {
            string querry7 = ("SELECT Puong_thuc_thanh_toan.ID_phuong_thuc, Puong_thuc_thanh_toan.Ten_phuong_thuc FROM Puong_thuc_thanh_toan;");
            DataTable dt = new DataTable();
            dt = data_.Get(querry7).Tables[0];
            return dt;
        }

        // danh muc trang thai
        [HttpGet]
        public DataTable DanhMucTrangThai()
        {
            string querry8 = ("SELECT Trang_thai.ID_trang_thai, Trang_thai.Ten_trang_thai FROM Trang_thai;");
            DataTable dt = new DataTable();
            dt = data_.Get(querry8).Tables[0];
            return dt;
        }


        //Cap nhat khach hang
        [HttpPost]
        public Boolean CapNhatHoaDon()
        {
            try
            {
                string ID_hoa_don = HttpContext.Current.Request.Form["ID_hoa_don"]; // where theo id 
                string ID_nhan_vien = HttpContext.Current.Request.Form["ID_nhan_vien"];
                string Dia_chi_giao_hang = HttpContext.Current.Request.Form["Dia_chi_giao_hang"];
                string ID_trang_thai = HttpContext.Current.Request.Form["ID_trang_thai"];
                string ID_phuong_thuc = HttpContext.Current.Request.Form["ID_phuong_thuc"];

                string querry4 = "UPDATE Hoa_don SET Hoa_don.ID_nhan_vien = '" + ID_nhan_vien + "', Hoa_don.Dia_chi_giao_hang = '" + Dia_chi_giao_hang + "', Hoa_don.ID_trang_thai = '" + ID_trang_thai + "', Hoa_don.ID_phuong_thuc = '" + ID_phuong_thuc + "' , Hoa_don.Ngay_cap_nhat = Date() WHERE(((Hoa_don.ID_hoa_don) = '" + ID_hoa_don + "'));";


                Boolean check4 = data_.ExeCuteNonQuery(querry4);
                if (check4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        //Xoa hoa don
        [HttpDelete]
        public Boolean XoaHoaDon()
        {

            try
            {
                // thuc hien lenh tren nay
                string ID_hoa_don = HttpContext.Current.Request.Form["ID_hoa_don"];


                string querry3 = "DELETE Hoa_don.*FROM Hoa_don WHERE ID_hoa_don = '" + ID_hoa_don + "'";
                Boolean check3 = data_.ExeCuteNonQuery(querry3);
                if (check3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
                throw;
            }
        }

        //<----------Hết Xử lý phần hóa đơn ------------>

        //<---------- Xử lý phần Chi Tiết hóa đơn ------------>

        // them chi tiet hoa don
        [HttpPost]
        public Boolean TaoMoiChiTietHoaDon()
        {

            try
            {

                string ID_hoa_don = HttpContext.Current.Request.Form["ID_hoa_don"];
                string ID_mat_hang = HttpContext.Current.Request.Form["ID_mat_hang"];
                string So_luong = HttpContext.Current.Request.Form["So_luong"];

                string querry16 = "INSERT INTO Chi_tiet_hoa_don( ID_hoa_don, ID_mat_hang, So_luong) SELECT '" + ID_hoa_don + "', '" + ID_mat_hang + "', " + So_luong + " FROM Hoa_don WHERE ID_hoa_don = '" + ID_hoa_don + "';";
                Boolean check = data_.ExeCuteNonQuery(querry16);
                if (check)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        // Xem Chi tiết Hoa Don
        [HttpPost]
        // view bang hoa don
        public DataTable BangChiTietHoaDon()
        {

            string ID_hoa_don = HttpContext.Current.Request.Form["ID_hoa_don"]; // where theo id 

            string querry10 = ("SELECT Chi_tiet_hoa_don.ID_hoa_don, Mat_hang.Ten_hang, Chi_tiet_hoa_don.So_luong, Mat_hang.Gia_hang, Sum(Chi_tiet_hoa_don.So_luong*Mat_hang.Gia_hang) AS Thanh_tien, Phan_loai.Ten_phan_loai, Mat_hang.ID_mat_hang, Phan_loai.ID_phan_loai, Chi_tiet_hoa_don.ID_chi_tiet, Nha_cung_cap.Ten_nha_cung_cap, Nha_cung_cap.ID_nha_cung_cap FROM Phan_loai INNER JOIN(Nha_cung_cap INNER JOIN (Mat_hang INNER JOIN Chi_tiet_hoa_don ON Mat_hang.ID_mat_hang = Chi_tiet_hoa_don.ID_mat_hang) ON Nha_cung_cap.ID_nha_cung_cap = Mat_hang.ID_nha_cung_cap) ON Phan_loai.ID_phan_loai = Mat_hang.ID_phan_loai GROUP BY Chi_tiet_hoa_don.ID_hoa_don, Mat_hang.Ten_hang, Chi_tiet_hoa_don.So_luong, Mat_hang.Gia_hang, Phan_loai.Ten_phan_loai, Mat_hang.ID_mat_hang, Phan_loai.ID_phan_loai, Chi_tiet_hoa_don.ID_chi_tiet, Nha_cung_cap.Ten_nha_cung_cap, Nha_cung_cap.ID_nha_cung_cap HAVING (((Chi_tiet_hoa_don.ID_hoa_don)='" + ID_hoa_don + "')); ");
            DataTable dt = new DataTable();
            dt = data_.Get(querry10).Tables[0];
            return dt;
        }

        // cap nhat chi tiet
        [HttpPost]
        public Boolean CapNhatChiTiet()
        {
            try
            {
                string ID_hoa_don = HttpContext.Current.Request.Form["ID_hoa_don"]; // where theo id hoa don
                string ID_mat_hang = HttpContext.Current.Request.Form["ID_mat_hang"]; // where theo id mat hang 
                string So_luong = HttpContext.Current.Request.Form["So_luong"];


                string querry11 = "UPDATE Chi_tiet_hoa_don SET  So_luong = '" + So_luong + "' WHERE ID_hoa_don = '" + ID_hoa_don + "' AND ID_mat_hang = '" + ID_mat_hang + "';";


                Boolean check11 = data_.ExeCuteNonQuery(querry11);
                if (check11)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        // view thong ke chi tiet total
        [HttpPost]
        public DataTable ThongKeTotalChiTietHoaDon()
        {
            string ID_hoa_don = HttpContext.Current.Request.Form["ID_hoa_don"]; // where theo id 
            string querry12 = ("SELECT COUNT(Chi_tiet_hoa_don.ID_mat_hang) AS So_luong_mat_hang_now, SUM(Chi_tiet_hoa_don.So_luong) AS so_luong_now , SUM(Chi_tiet_hoa_don.So_luong*Mat_hang.Gia_hang) AS Tong_tien_now" +
                " FROM Mat_hang INNER JOIN(Hoa_don INNER JOIN Chi_tiet_hoa_don ON Hoa_don.ID_hoa_don = Chi_tiet_hoa_don.ID_hoa_don) ON Mat_hang.ID_mat_hang = Chi_tiet_hoa_don.ID_mat_hang WHERE (((Hoa_don.ID_hoa_don)='" + ID_hoa_don + "')); ");
            DataTable dt = new DataTable();
            dt = data_.Get(querry12).Tables[0];
            if (dt.Rows[0]["So_luong_mat_hang_now"].ToString() == "")
            {
                dt.Rows[0]["So_luong_mat_hang_now"] = "0";
            }
            if (dt.Rows[0]["so_luong_now"].ToString() == "")
            {
                dt.Rows[0]["so_luong_now"] = "0";
            }
            if (dt.Rows[0]["Tong_tien_now"].ToString() == "")
            {
                dt.Rows[0]["Tong_tien_now"] = "0";
            }
            return dt;
        }

        //Xoa hoa don
        [HttpDelete]
        public Boolean XoaChiTietHoaDon()
        {

            try
            {
                // thuc hien lenh tren nay
                string ID_chi_tiet = HttpContext.Current.Request.Form["ID_chi_tiet"]; // where theo id 


                string querry14 = ("DELETE Chi_tiet_hoa_don.* FROM Chi_tiet_hoa_don WHERE Chi_tiet_hoa_don.ID_chi_tiet = " + ID_chi_tiet + "");
                Boolean check14 = data_.ExeCuteNonQuery(querry14);
                if (check14)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
                throw;
            }
        }

        [HttpGet]
        public DataTable DanhMucMatHang()
        {
            string querry15 = ("SELECT Mat_hang.ID_mat_hang, Mat_hang.ID_phan_loai, Mat_hang.Ten_hang, Mat_hang.Gia_hang, Nha_cung_cap.Ten_nha_cung_cap, Phan_loai.Ten_phan_loai, Nha_cung_cap.ID_nha_cung_cap FROM Phan_loai INNER JOIN(Nha_cung_cap INNER JOIN Mat_hang ON Nha_cung_cap.ID_nha_cung_cap = Mat_hang.ID_nha_cung_cap) ON Phan_loai.ID_phan_loai = Mat_hang.ID_phan_loai; ");
            DataTable dt = new DataTable();
            dt = data_.Get(querry15).Tables[0];
            return dt;
        }


        //<---------- Hết phần Chi Tiết hóa đơn ------------>

        [HttpPost]
        public DataTable SendMail()
        {
            string ID_hoa_don = HttpContext.Current.Request.Form["ID_hoa_don"]; // where theo id 
            string querry12 = ("SELECT DISTINCT Hoa_don.ID_hoa_don, Hoa_don.ID_khach_hang, Hoa_don.ID_nhan_vien, Hoa_don.Dia_chi_giao_hang, (Format([Hoa_don].[Ngay_tao],'dd-mm-yyyy')) AS Ngay_tao, (Format([Hoa_don].[Ngay_cap_nhat],'dd-mm-yyyy')) AS Ngay_cap_nhat, Hoa_don.ID_trang_thai, Hoa_don.ID_phuong_thuc, (Nhan_vien.Ho+' '+Nhan_vien.Ten) AS Ten_nhan_vien, (Khach_hang.Ho+' '+Khach_hang.Ten) AS Ten_khach_hang, Puong_thuc_thanh_toan.Ten_phuong_thuc, Trang_thai.Ten_trang_thai, Khach_hang.Dien_thoai, Khach_hang.Email FROM Mat_hang INNER JOIN((Trang_thai INNER JOIN (Puong_thuc_thanh_toan INNER JOIN (Nhan_vien INNER JOIN (Khach_hang INNER JOIN Hoa_don ON Khach_hang.ID_khach_hang = Hoa_don.ID_khach_hang) ON Nhan_vien.ID_nhan_vien = Hoa_don.ID_nhan_vien) ON Puong_thuc_thanh_toan.ID_phuong_thuc = Hoa_don.ID_phuong_thuc) ON Trang_thai.ID_trang_thai = Hoa_don.ID_trang_thai) INNER JOIN Chi_tiet_hoa_don ON Hoa_don.ID_hoa_don = Chi_tiet_hoa_don.ID_hoa_don) ON Mat_hang.ID_mat_hang = Chi_tiet_hoa_don.ID_mat_hang WHERE(((Hoa_don.ID_hoa_don) = '"+ID_hoa_don+"')) ORDER BY Hoa_don.ID_hoa_don;");
            DataTable dt = new DataTable();
            dt = data_.Get(querry12).Tables[0];



            var fromAddress = new MailAddress("banhangcarina@gmail.com", "From Name");
            var toAddress = new MailAddress("ducnin1998@gmail.com", "To Name");
            const string fromPassword = "carina1234";
            const string subject = "Yêu Cầu Thanh Toán Hóa Đơn Của Carina";
            const string body = "nooi dung mail ";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
            return dt;
        }

    }
}