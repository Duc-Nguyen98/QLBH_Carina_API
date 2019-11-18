using buoi_4;
using System;
using System.Data;
using System.Web;
using System.Web.Http;

namespace QLBH_Carina_API.Controllers
{
    public class KhachHangController : ApiController
    {
        Data_provider data_ = new Data_provider();
        // Xem khách hàng
        [HttpGet]
        public DataTable BangKhachHang()
        {

            string querry = ("SELECT Khach_hang.ID_khach_hang,Khach_hang.Ho,Khach_hang.Ten, [Ho]+ ' '  +[Ten] AS Expr1, (Format([Khach_hang].[Ngay_sinh],'dd-mm-yyyy')) AS Ngay_sinh  , Khach_hang.Que_quan, Khach_hang.Dia_chi, Khach_hang.Email, Khach_hang.Dien_thoai, (Format([Khach_hang].[Ngay_tao],'dd-mm-yyyy')) AS Ngay_tao,  (Format([Khach_hang].[Ngay_cap_nhat],'dd- mm-yyyy')) AS Ngay_cap_nhat  FROM Khach_hang; ");
            DataTable dt = new DataTable();
            dt = data_.Get(querry).Tables[0];
            return dt;
        }


        // them khach hang
        [HttpPost]
        public Boolean TaoMoiKhachHang()
        {

            try
            {

                string ID_khach_hang = GenerateCustomerCode();
                string Ho = HttpContext.Current.Request.Form["Ho"];
                string Ten = HttpContext.Current.Request.Form["Ten"];
                string Ngay_sinh = HttpContext.Current.Request.Form["Ngay_sinh"];
                string Que_quan = HttpContext.Current.Request.Form["Que_quan"];
                string Dia_chi = HttpContext.Current.Request.Form["Dia_chi"];
                string Email = HttpContext.Current.Request.Form["Email"];
                string Dien_thoai = HttpContext.Current.Request.Form["Dien_thoai"];
                string querry2 = "INSERT INTO Khach_hang (ID_khach_hang, Ho, Ten, Ngay_sinh, Que_quan, Dia_chi, Email,  Dien_thoai)VALUES ('" + ID_khach_hang + "', '" + Ho + "','" + Ten + "','" + Ngay_sinh + "' , '" + Dia_chi + "', '" + Que_quan + "', '" + Email + "', '" + Dien_thoai + "')";
                Boolean check = data_.ExeCuteNonQuery(querry2);
                if (check)
                {
                    return true;
                }
                else
                { return false; }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        // mã tự sinh
        private String GenerateCustomerCode()
        {
            string returnString = "MKH";
            try

            {

                string querry3 = ("SELECT Max(Khach_hang.ID_khach_hang) AS ExtractString FROM Khach_hang;");

                DataTable dt = new DataTable();
                dt = data_.Get(querry3).Tables[0];
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

        //Xoa khach hang
        [HttpDelete]
        public Boolean XoaKhachHang()
        {

            try
            {
                // thuc hien lenh tren nay
                string ID_khach_hang = HttpContext.Current.Request.Form["ID_khach_hang"];


                string querry3 = "DELETE Khach_hang.* FROM Khach_hang WHERE ID_khach_hang = '" + ID_khach_hang + "' ";
                Boolean check2 = data_.ExeCuteNonQuery(querry3);
                if (check2)
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

        //Cap nhat khach hang
        [HttpPost]
        public Boolean CapNhatKhachHang()
        {
            try
            {
                string ID_khach_hang = HttpContext.Current.Request.Form["ID_khach_hang"]; // where theo id 
                string Ho = HttpContext.Current.Request.Form["Ho"];
                string Ten = HttpContext.Current.Request.Form["Ten"];
                string Ngay_sinh = HttpContext.Current.Request.Form["Ngay_sinh"];
                string Que_quan = HttpContext.Current.Request.Form["Que_quan"];
                string Dia_chi = HttpContext.Current.Request.Form["Dia_chi"];
                string Email = HttpContext.Current.Request.Form["Email"];
                string Dien_thoai = HttpContext.Current.Request.Form["Dien_thoai"];

                string querry4 = "UPDATE Khach_hang SET  Ho = '" + Ho + "' , Ten = '" + Ten + "' , Ngay_sinh = '" + Ngay_sinh + "' , Que_quan = '" + Que_quan + "' , Dia_chi = '" + Dia_chi + "' , Email = '" + Email + "' , Dien_thoai = '" + Dien_thoai + "' , Ngay_cap_nhat = Date()  WHERE ID_khach_hang = '" + ID_khach_hang + "';";


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
    }
}