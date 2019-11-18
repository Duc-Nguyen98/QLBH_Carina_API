using buoi_4;
using System.Data;
using System.Web.Http;


namespace QLBH_Carina_API.Controllers
{
    public class ThongKeController : ApiController
    {
        Data_provider data_ = new Data_provider();
        [HttpGet]
        public DataTable BangThongKe()
        {

            var querry = "SELECT TOP 1 (SELECT count(' ID_nhan_vien ') FROM Nhan_vien;) AS Nhan_vien_hien_tai,(SELECT count('ID_khach_hang ') FROM Khach_hang;) AS Khach_hang, (SELECT count('ID_nha_cung_cap ')FROM Nha_cung_cap;) AS Nha_cung_cap, (SELECT COUNT(Mat_hang.ID_Mat_hang) FROM Mat_hang;) AS so_luong_mat_hang, (SELECT Count(*) FROM Hoa_don;) AS Tong_hoa_don, (SELECT Count(*) FROM Hoa_don WHERE ID_trang_thai = 3;) AS Hoa_don_da_xu_ly, (SELECT Count(*) FROM Hoa_don WHERE ID_trang_thai = 1;) AS Hoa_don_chua_xu_ly , (SELECT COUNT(*) FROM Hoa_don WHERE(((Hoa_don.ID_trang_thai) = 2));) AS Hoa_don_dang_cho_xu_ly, (SELECT sum(Mat_hang.So_luong) AS Tong_so_luong_hang_nhap_theo_nam FROM Mat_hang WHERE Format(Mat_hang.Ngay_tao, 'mm/yyyy') = Format(date(), 'mm/yyyy');) AS so_luong_hang_nhap_theo_thang, (SELECT sum(Mat_hang.So_luong) AS so_luong_mat_hang_nhap_theo_nam FROM Mat_hang WHERE Format(Mat_hang.Ngay_tao, 'yyyy') = Format(date(), 'yyyy');) AS so_luong_hang_nhap_theo_nam, (SELECT sum(tmp.Tong_t) AS tong_tien_nam_hien_tai FROM(SELECT t1.*, (select SUM(t3.Gia_hang * t2.So_luong) from Chi_tiet_hoa_don t2 inner join mat_hang t3 on t2.id_mat_hang = t3.id_mat_hang where t2.ID_hoa_don = t1.ID_hoa_don) AS Tong_t, (select SUM(t2.So_luong) from Chi_tiet_hoa_don t2 where t2.ID_hoa_don = t1.ID_hoa_don) AS['TSL'] FROM Hoa_don AS t1) AS tmp WHERE (((Format([tmp].[ngay_tao],'ww'))=Format(Date(),'ww')) AND ((tmp.[ID_trang_thai])=3));) AS Doanh_thu_theo_tuan_hien_tai, (SELECT sum(tmp.Tong_t) AS tong_tien_nam_hien_tai FROM(SELECT t1.*, (select SUM(t3.Gia_hang * t2.So_luong) from Chi_tiet_hoa_don t2 inner join mat_hang t3 on t2.id_mat_hang = t3.id_mat_hang where t2.ID_hoa_don = t1.ID_hoa_don) AS Tong_t, (select SUM(t2.So_luong) from Chi_tiet_hoa_don t2 where t2.ID_hoa_don = t1.ID_hoa_don) AS['TSL'] FROM Hoa_don AS t1) AS tmp WHERE Format(tmp.ngay_tao,'mm/yyyy') = Format(date(), 'mm/yyyy') AND ID_trang_thai = 3;) AS Doanh_thu_theo_thang, (SELECT sum(tmp.Tong_t) AS tong_tien_nam_hien_tai FROM(SELECT t1.*, (select SUM(t3.Gia_hang * t2.So_luong) from Chi_tiet_hoa_don t2 inner join mat_hang t3 on t2.id_mat_hang = t3.id_mat_hang where t2.ID_hoa_don = t1.ID_hoa_don) AS Tong_t, (select SUM(t2.So_luong) from Chi_tiet_hoa_don t2 where t2.ID_hoa_don = t1.ID_hoa_don) AS['TSL'] FROM Hoa_don AS t1) AS tmp WHERE Format(tmp.ngay_tao,'yyyy') = Format(date(), 'yyyy') AND ID_trang_thai = 3;) AS Doanh_thu_theo_nam , (SELECT TOP 1 Sum(Chi_tiet_hoa_don.So_luong*Mat_hang.Gia_hang) AS Tong_tien_trong_ngay FROM Mat_hang INNER JOIN (Hoa_don INNER JOIN Chi_tiet_hoa_don ON Hoa_don.ID_hoa_don = Chi_tiet_hoa_don.ID_hoa_don) ON Mat_hang.ID_mat_hang = Chi_tiet_hoa_don.ID_mat_hang WHERE (((Hoa_don.ID_trang_thai)=3) AND ((Hoa_don.Ngay_tao)=Date())) GROUP BY Hoa_don.Ngay_tao, Hoa_don.ID_trang_thai;) AS Doanh_thu_theo_ngay FROM Nha_cung_cap INNER JOIN Mat_hang ON Nha_cung_cap.ID_nha_cung_cap = Mat_hang.ID_nha_cung_cap, Nhan_vien INNER JOIN(Khach_hang INNER JOIN Hoa_don ON Khach_hang.ID_khach_hang = Hoa_don.ID_khach_hang) ON Nhan_vien.ID_nhan_vien = Hoa_don.ID_nhan_vien;";
            DataTable dt = new DataTable();
            dt = data_.Get(querry).Tables[0];
            if (dt.Rows[0]["so_luong_hang_nhap_theo_thang"].ToString() == "")
            {
                dt.Rows[0]["so_luong_hang_nhap_theo_thang"] = "0";
            }
            if (dt.Rows[0]["so_luong_hang_nhap_theo_nam"].ToString() == "")
            {
                dt.Rows[0]["so_luong_hang_nhap_theo_nam"] = "0";
            }
            if (dt.Rows[0]["Doanh_thu_theo_tuan_hien_tai"].ToString() == "")
            {
                dt.Rows[0]["Doanh_thu_theo_tuan_hien_tai"] = "0";
            }
            if (dt.Rows[0]["Doanh_thu_theo_thang"].ToString() == "")
            {
                dt.Rows[0]["Doanh_thu_theo_thang"] = "0";
            }
            if (dt.Rows[0]["Doanh_thu_theo_nam"].ToString() == "")
            {
                dt.Rows[0]["Doanh_thu_theo_nam"] = "0";
            }
            if (dt.Rows[0]["Doanh_thu_theo_ngay"].ToString() == "")
            {
                dt.Rows[0]["Doanh_thu_theo_ngay"] = "0";
            }

            return dt;
        }

        [HttpGet]
        public DataTable BangTopPhuongThuc()
        {
            var querry2 = "SELECT Sum(Chi_tiet_hoa_don.So_luong*Mat_hang.Gia_hang) AS Expr1, Puong_thuc_thanh_toan.Ten_phuong_thuc "
            + " FROM Puong_thuc_thanh_toan INNER JOIN(Mat_hang INNER JOIN (Hoa_don INNER JOIN Chi_tiet_hoa_don ON Hoa_don.ID_hoa_don = Chi_tiet_hoa_don.ID_hoa_don) ON Mat_hang.ID_mat_hang = Chi_tiet_hoa_don.ID_mat_hang) ON Puong_thuc_thanh_toan.ID_phuong_thuc = Hoa_don.ID_phuong_thuc "
            + " GROUP BY Puong_thuc_thanh_toan.Ten_phuong_thuc, Hoa_don.ID_phuong_thuc;";

            DataTable dt = new DataTable();
            dt = data_.Get(querry2).Tables[0];
            return dt;
        }

        [HttpGet]
        public DataTable BangThanhToanGan()
        {
            var querry3 = "SELECT Hoa_don.ID_hoa_don, [Ho]+ ' ' +[Ten] AS Ten_khach_hang, Trang_thai.Ten_trang_thai, Puong_thuc_thanh_toan.Ten_phuong_thuc, (Format([Hoa_don].[Ngay_tao],'dd-mm-yyyy')) AS Ngay_tao, [Gia_hang]*[Chi_tiet_hoa_don].[So_luong] AS Thanh_tien "
            + " FROM Mat_hang INNER JOIN((Puong_thuc_thanh_toan INNER JOIN (Trang_thai INNER JOIN (Khach_hang INNER JOIN Hoa_don ON Khach_hang.ID_khach_hang = Hoa_don.ID_khach_hang) ON Trang_thai.ID_trang_thai = Hoa_don.ID_trang_thai) ON Puong_thuc_thanh_toan.ID_phuong_thuc = Hoa_don.ID_phuong_thuc) INNER JOIN Chi_tiet_hoa_don ON Hoa_don.ID_hoa_don = Chi_tiet_hoa_don.ID_hoa_don) ON Mat_hang.ID_mat_hang = Chi_tiet_hoa_don.ID_mat_hang "
            + " WHERE(((Trang_thai.Ten_trang_thai) = 'Đã xử lý')) ORDER BY Hoa_don.ID_hoa_don DESC, Hoa_don.Ngay_tao DESC;";
            DataTable dt = new DataTable();
            dt = data_.Get(querry3).Tables[0];
            return dt;
        }

        [HttpGet]
        public DataTable Thongkephantram()
        {
            var querry4 = "SELECT TOP 1 (SELECT TOP 1 ROUND(((Count(Khach_hang.ID_khach_hang)/700)*100),2) FROM Khach_hang) AS Tang_khach_hang, (SELECT TOP 1 ROUND(((COUNT(Nha_cung_cap.ID_nha_cung_cap)/200)*100),2) FROM Nha_cung_cap;) AS Tang_nha_cung_cap, (SELECT TOP 1 ROUND(((COUNT(Mat_hang.ID_mat_hang) / 350) * 100), 2) FROM Mat_hang;) AS Tang_mat_hang, (SELECT TOP 1 ROUND(((COUNT(Nhan_vien.ID_nhan_vien) / 150) * 100), 2) FROM Nhan_vien;) AS Tang_nhan_vien, (SELECT TOP 1 ROUND((((SELECT sum(tmp.Tong_t) AS tong_tien_nam_hien_tai FROM(SELECT t1.*, (select SUM(t3.Gia_hang * t2.So_luong) from Chi_tiet_hoa_don t2 inner join mat_hang t3 on t2.id_mat_hang = t3.id_mat_hang where t2.ID_hoa_don = t1.ID_hoa_don) AS Tong_t, (select SUM(t2.So_luong) from Chi_tiet_hoa_don t2 where t2.ID_hoa_don = t1.ID_hoa_don) AS['TSL'] FROM Hoa_don AS t1) AS tmp WHERE Format(tmp.ngay_tao,'ww') = Format(date(), 'ww') AND ID_trang_thai = 3;)/ 150000)*100),2) AS Tang_doanh_thu_tuan FROM Hoa_don;) AS Tang_doanh_thu_tuan, (SELECT TOP 1 ROUND((((SELECT sum(tmp.Tong_t) AS tong_tien_nam_hien_tai FROM(SELECT t1.*, (select SUM(t3.Gia_hang * t2.So_luong) from Chi_tiet_hoa_don t2 inner join mat_hang t3 on t2.id_mat_hang = t3.id_mat_hang where t2.ID_hoa_don = t1.ID_hoa_don) AS Tong_t, (select SUM(t2.So_luong) from Chi_tiet_hoa_don t2 where t2.ID_hoa_don = t1.ID_hoa_don) AS['TSL'] FROM Hoa_don AS t1 ) AS tmp WHERE Format(tmp.ngay_tao,'mm/yyyy') = Format(date(), 'mm/yyyy') AND ID_trang_thai = 3;)/ (150000 * 4))*100),2) AS Tang_doanh_thu_thang FROM Hoa_don;) AS Tang_doanh_thu_thang, (SELECT TOP 1 ROUND((((SELECT sum(tmp.Tong_t) AS tong_tien_nam_hien_tai FROM(SELECT t1.*, (select SUM(t3.Gia_hang * t2.So_luong) from Chi_tiet_hoa_don t2 inner join mat_hang t3 on t2.id_mat_hang = t3.id_mat_hang where t2.ID_hoa_don = t1.ID_hoa_don) AS Tong_t, (select SUM(t2.So_luong) from Chi_tiet_hoa_don t2 where t2.ID_hoa_don = t1.ID_hoa_don) AS['TSL'] FROM Hoa_don AS t1 ) AS tmp WHERE Format(tmp.ngay_tao,'mm/yyyy') = Format(date(), 'mm/yyyy') AND ID_trang_thai = 3;)/ ((150000 * 4) * 12))*100), 2) AS Tang_doanh_thu_nam FROM Hoa_don;) AS Tang_doanh_thu_nam , (SELECT TOP 1 Round((((SELECT sum(tmp.Tong_t) AS tong_tien_nam_hien_tai FROM (SELECT t1.*, (select SUM(t3.Gia_hang * t2.So_luong) from Chi_tiet_hoa_don t2 inner join mat_hang t3 on t2.id_mat_hang = t3.id_mat_hang where t2.ID_hoa_don = t1.ID_hoa_don) AS Tong_t, (select SUM(t2.So_luong) from Chi_tiet_hoa_don t2 where t2.ID_hoa_don = t1.ID_hoa_don) AS ['TSL'] FROM Hoa_don AS t1 ) AS tmp WHERE Format (tmp.ngay_tao) = Format (date()) AND ID_trang_thai = 3; )/25000)*100),2) AS Tang_doanh_thu_ngay FROM Hoa_don; ) AS Tang_doanh_thu_ngay FROM Khach_hang;";
            DataTable dt = new DataTable();
            dt = data_.Get(querry4).Tables[0];
            if (dt.Rows[0]["Tang_doanh_thu_ngay"].ToString() == "")
            {
                dt.Rows[0]["Tang_doanh_thu_ngay"] = "0";
            }
            if (dt.Rows[0]["Tang_doanh_thu_tuan"].ToString() == "")
            {
                dt.Rows[0]["Tang_doanh_thu_tuan"] = "0";
            }
            if (dt.Rows[0]["Tang_doanh_thu_thang"].ToString() == "")
            {
                dt.Rows[0]["Tang_doanh_thu_thang"] = "0";
            }
            if (dt.Rows[0]["Tang_doanh_thu_nam"].ToString() == "")
            {
                dt.Rows[0]["Tang_doanh_thu_nam"] = "0";
            }

            return dt;
        }

    }
}