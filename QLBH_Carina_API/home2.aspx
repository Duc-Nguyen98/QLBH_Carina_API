<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="home2.aspx.cs" Inherits="QLBH_Carina_API.home2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .border-left {
            border-left: 2px solid #fff !important;
        }
    </style>
    <!-- Script thống kê -->
    <script>
        $(function () {
            //Default data table
            $('#default-datatable').DataTable({
                columnDefs: [
                    {
                        targets: 1,
                        render: $.fn.dataTable.render.ellipsis(14, true)
                    },
                    {
                        targets: 2,
                        render: $.fn.dataTable.render.ellipsis(14, true)
                    }
                ]
            });
        });
    </script>
    <!--Data Tables -->
    <link href="assets/plugins/bootstrap-datatable/css/dataTables.bootstrap4.min.css" rel="stylesheet" type="text/css">
    <link href="assets/plugins/bootstrap-datatable/css/buttons.bootstrap4.min.css" rel="stylesheet" type="text/css">
    <!--Data Tables js-->
    <script src="assets/plugins/bootstrap-datatable/js/jquery.dataTables.min.js"></script>
    <script src="assets/plugins/bootstrap-datatable/js/dataTables.bootstrap4.min.js"></script>
    <script src="assets/plugins/bootstrap-datatable/js/dataTables.buttons.min.js"></script>
    <script src="assets/plugins/bootstrap-datatable/js/datatables.dataRender.js"></script>



    <script src="App_js/Thong_ke.js"></script>
    <div data-ng-controller="mycontroller">
        <div data-ng-repeat="BangThongKe in BangThongKee">
            <div class="card mt-3" data-ng-repeat="Thongkephantram in Thongkephantramm">
                <div class="card-content">
                    <div class="row row-group m-0">
                        <div class="col-12 col-lg-6 col-xl-3 border-light">
                            <div class="card-body">
                                <!--arena change value-->
                                <div class="row">
                                    <asp:Label class="text-white mb-0 col-6 text-left" runat="server">Hiện tại: {{BangThongKe.Nhan_vien_hien_tai}}</asp:Label>
                                    <asp:Label class="text-white mb-0 col-6 text-right border-left" runat="server">Chỉ tiêu: 150</asp:Label>
                                </div>
                                <!--arena change value-->
                                <div class="progress my-3" style="height: 3px;">
                                    <div class="progress-bar" style="width: {{Thongkephantram.Tang_nhan_vien}}%"></div>
                                </div>

                                <p class="mb-0 text-white small-font">
                                    Nhân Viên Hiện Tại<span class="float-right">+{{Thongkephantram.Tang_nhan_vien}}% <i class="zmdi zmdi-long-arrow-up"></i></span>
                                </p>
                            </div>
                        </div>
                        <div class="col-12 col-lg-6 col-xl-3 border-light">
                            <div class="card-body">
                                <!--arena change value-->

                                <div class="row">
                                    <asp:Label class="text-white mb-0 col-6 text-left" runat="server">Hiện tại: {{BangThongKe.so_luong_mat_hang}}</asp:Label>
                                    <asp:Label class="text-white mb-0 col-6 text-right border-left" runat="server">Chỉ tiêu: 350</asp:Label>
                                </div>
                                <!--arena change value-->
                                <div class="progress my-3" style="height: 3px;">
                                    <div class="progress-bar" style="width: {{Thongkephantram.Tang_mat_hang}}%"></div>
                                </div>
                                <p class="mb-0 text-white small-font">Mặt Hàng Hiện Tại <span class="float-right">+{{Thongkephantram.Tang_mat_hang}}% <i class="zmdi zmdi-long-arrow-up"></i></span></p>
                            </div>
                        </div>
                        <div class="col-12 col-lg-6 col-xl-3 border-light">
                            <div class="card-body">
                                <!--arena change value-->

                                <div class="row">
                                    <asp:Label class="text-white mb-0 col-6 text-left" runat="server">Hiện tại: {{BangThongKe.Khach_hang}}</asp:Label>
                                    <asp:Label class="text-white mb-0 col-6 text-right border-left" runat="server">Chỉ tiêu: 700</asp:Label>
                                </div>
                                <!--arena change value-->
                                <div class="progress my-3" style="height: 3px;">
                                    <div class="progress-bar" style="width: {{Thongkephantram.Tang_khach_hang}}%"></div>
                                </div>
                                <p class="mb-0 text-white small-font">Khách Hàng Hiện Tại <span class="float-right">+{{Thongkephantram.Tang_khach_hang}}% <i class="zmdi zmdi-long-arrow-up"></i></span></p>
                            </div>
                        </div>
                        <div class="col-12 col-lg-6 col-xl-3 border-light">
                            <div class="card-body">
                                <!--arena change value-->
                                <div class="row">
                                    <asp:Label class="text-white mb-0 col-6 text-left" runat="server">Hiện tại: {{BangThongKe.Nha_cung_cap}}</asp:Label>
                                    <asp:Label class="text-white mb-0 col-6 text-right border-left" runat="server">Chỉ tiêu: 200</asp:Label>
                                </div>
                                <!--arena change value-->
                                <div class="progress my-3" style="height: 3px;">
                                    <div class="progress-bar" style="width: {{Thongkephantram.Tang_nha_cung_cap}}%"></div>
                                </div>
                                <p class="mb-0 text-white small-font">Nhà Cung Cấp Hiện Tại<span class="float-right">+{{Thongkephantram.Tang_nha_cung_cap}}% <i class="zmdi zmdi-long-arrow-up"></i></span></p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--arena change value-->
            <div class="row mt-3">
                <div class="col-12 col-lg-12 col-xl-8">
                    <div class="card">
                        <div class="card-body">
                            <div class="row row-group align-items-center">
                                <div class="col-12 col-lg-6 text-left p-4">
                                    <h5 class="pb-3 pt-2">Tổng Số Lượng Hóa Đơn Hiện Tại</h5>
                                    <!--arena change value-->

                                    <div class="row pt-3 py-4">
                                        <h4>
                                            <asp:Label CssClass="mb-0  col-6 text-left " runat="server">Hiện tại: {{BangThongKe.Tong_hoa_don}}</asp:Label></h4>
                                        <h4>
                                            <asp:Label CssClass="mb-0  border-left  col-6 text-right " runat="server">Chỉ tiêu: 500</asp:Label></h4>
                                    </div>
                                    <!--arena change value-->
                                </div>
                                <div class="col-12 col-lg-6 text-left p-4">
                                    <ul>
                                        <li class=" mb-0">
                                            <!--arena change value-->
                                            <h5>Số Lượng Hóa Đơn Đã Xử Lý:
                                                <asp:Label CssClass="mb-0 py-3" runat="server">{{BangThongKe.Hoa_don_da_xu_ly}}</asp:Label></h5>
                                            <!--arena change value-->
                                        </li>
                                        <li class="py-2 mb-0">
                                            <!--arena change value-->
                                            <h5>Số Lượng Hóa Đơn Đang Chờ Xử Lý:
                                                <asp:Label CssClass="mb-0 py-3" runat="server">{{BangThongKe.Hoa_don_dang_cho_xu_ly}}</asp:Label></h5>
                                            <!--arena change value-->
                                        </li>
                                        <li class="mb-0">
                                            <!--arena change value-->
                                            <h5>Số Lượng Hóa Đơn Chưa Xử Lý:
                                                <asp:Label CssClass="mb-0 py-3" runat="server">{{BangThongKe.Hoa_don_chua_xu_ly}}</asp:Label></h5>
                                            <!--arena change value-->
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card">
                        <div class="card-body">
                            <div class="row row-group align-items-center">
                                <div class="col-12 col-lg-6 text-left p-4">
                                    <p>Tổng Số Lượng Hàng Nhập Theo Tháng</p>
                                    <!--arena change value-->
                                    <h2>
                                        <asp:Label class="mb-0 py-3" runat="server">{{BangThongKe.so_luong_hang_nhap_theo_thang}}</asp:Label></h2>
                                    <!--arena change value-->
                                </div>
                                <div class="col-12 col-lg-6 text-left p-4">
                                    <p>Tổng Số Lượng Hàng Nhập Theo Năm</p>
                                    <!--arena change value-->
                                    <h2>
                                        <asp:Label class="mb-0 py-3" runat="server">{{BangThongKe.so_luong_hang_nhap_theo_nam}}</asp:Label></h2>
                                    <!--arena change value-->
                                </div>

                            </div>
                        </div>
                    </div>


                </div>
                <div class="col-12 col-lg-12 col-xl-4">
                    <div class="card">
                        <div class="card-header" style="padding: 1.5rem; font-size: 1rem;">
                            <div class="row">
                                <div class="col-6 text-left">
                                    Hình Thức Thanh Toán
                                </div>
                                <div class="col-6 text-right">
                                    Tổng Tiền Thu Nhập
                                </div>
                            </div>
                        </div>
                        <div class="table-responsive">
                            <table class="table align-items-center" data-ng-repeat="BangPhuongThuc in BangPhuongThucc">
                                <tbody>
                                    <tr style="padding: 1.3rem; font-size: .9rem;">
                                        <td class="col-6"><i class="fa fa-circle text-white mr-2"></i>{{BangPhuongThuc.Ten_phuong_thuc}}</td>
                                        <td class="col-6">{{BangPhuongThuc.Expr1 | currency}}</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div class="col-12">
                        <div class="card">
                            <div class="card-body">
                                <p class="text-white mb-0">Doanh Thu Của Ngày Hiện Tại <span class="float-right badge badge-light">Ngày</span></p>
                                <div class="">
                                    <!--arena change value-->
                                    <h4 class="mb-0 py-3">
                                        <asp:Label runat="server">{{BangThongKe.Doanh_thu_theo_ngay | currency}} / 25000</asp:Label><span class="float-right"><i class="fa fa-share-alt"></i></span></h4>
                                    <!--arena change value-->
                                </div>
                                <div class="progress-wrapper">
                                    <div class="progress" style="height: 5px;">
                                        <div class="progress-bar" style="width: {{Thongkephantram.Tang_doanh_thu_tuan}}%"></div>
                                    </div>
                                </div>
                                <p class="mb-0 mt-2 text-white small-font">Tăng trưởng phần trăm theo ngày <span class="float-right">+{{Thongkephantram.Tang_doanh_thu_tuan}}% <i class="fa fa-long-arrow-up"></i></span></p>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <!--End  Hoa Don -->
            <div class="row" data-ng-repeat="Thongkephantram in Thongkephantramm">
                <div class="col-12 col-lg-12 col-xl-12">
                    <div class="row">
                        <div class="col-12 col-lg-6 col-xl-4">
                            <div class="card">
                                <div class="card-body">
                                    <p class="text-white mb-0">Doanh Thu Của Tuần Hiện Tại <span class="float-right badge badge-light">Tuần</span></p>
                                    <div class="">
                                        <!--arena change value-->
                                        <h4 class="mb-0 py-3">
                                            <asp:Label runat="server">{{BangThongKe.Doanh_thu_theo_tuan_hien_tai | currency}} / 150000</asp:Label><span class="float-right"><i class="fa fa-share-alt"></i></span></h4>
                                        <!--arena change value-->
                                    </div>
                                    <div class="progress-wrapper">
                                        <div class="progress" style="height: 5px;">
                                            <div class="progress-bar" style="width: {{Thongkephantram.Tang_doanh_thu_tuan}}%"></div>
                                        </div>
                                    </div>
                                    <p class="mb-0 mt-2 text-white small-font">Tăng trưởng phần trăm theo tuần <span class="float-right">+{{Thongkephantram.Tang_doanh_thu_tuan}}% <i class="fa fa-long-arrow-up"></i></span></p>
                                </div>
                            </div>
                        </div>

                        <div class="col-12 col-lg-6 col-xl-4">
                            <div class="card">
                                <div class="card-body">
                                    <p class="text-white mb-0">Doanh Thu Của Tháng Hiện Tại <span class="float-right badge badge-light">Tháng</span></p>
                                    <div class="">
                                        <!--arena change value-->
                                        <h4 class="mb-0 py-3">
                                            <asp:Label runat="server">{{BangThongKe.Doanh_thu_theo_thang | currency}} / 600000</asp:Label><span class="float-right"><i class="fa fa-share-alt"></i></span></h4>
                                        <!--arena change value-->
                                    </div>
                                    <div class="progress-wrapper">
                                        <div class="progress" style="height: 5px;">
                                            <div class="progress-bar" style="width: {{Thongkephantram.Tang_doanh_thu_thang}}%"></div>
                                        </div>
                                    </div>
                                    <p class="mb-0 mt-2 text-white small-font">Tăng trưởng phần trăm theo tháng <span class="float-right">+{{Thongkephantram.Tang_doanh_thu_thang}}% <i class="fa fa-long-arrow-up"></i></span></p>
                                </div>
                            </div>
                        </div>

                        <div class="col-12 col-lg-6 col-xl-4">
                            <div class="card">
                                <div class="card-body">
                                    <p class="text-white mb-0">Doanh Thu Của Năm Hiện Tại <span class="float-right badge badge-light">Năm</span></p>
                                    <div class="">
                                        <!--arena change value-->
                                        <h4 class="mb-0 py-3">
                                            <asp:Label runat="server" Text="Label">{{BangThongKe.Doanh_thu_theo_nam | currency}} / 7200000</asp:Label><span class="float-right"><i class="fa fa-share-alt"></i></span></h4>
                                        <!--arena change value-->
                                    </div>
                                    <div class="progress-wrapper">
                                        <div class="progress" style="height: 5px;">
                                            <div class="progress-bar" style="width: {{Thongkephantram.Tang_doanh_thu_nam}}%"></div>
                                        </div>
                                    </div>
                                    <p class="mb-0 mt-2 text-white small-font">Tăng trưởng phần trăm theo năm <span class="float-right">+{{Thongkephantram.Tang_doanh_thu_nam}}% <i class="fa fa-long-arrow-up"></i></span></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <!--End thong ke doanh thu theo tuan , thang va nam Row-->
        </div>
        <!--BangThongKe in BangThongKee-->

        <div class="row">
            <div class="col-12 col-lg-12 col-xl-12">
                <div class="card">
                    <div class="card-header mb-3 row">
                        <div class="col-8">
                            Danh Sách Hóa Đơn Đã Được Thanh Toán Gần Đây
                        </div>

                        <div class="col-2 ">
                            <p>
                                Từ Ngày
                                <input type="text" class="form-control form-control-rounded  datepicker" id="StartDate" autocomplete="off" name="date">
                            </p>
                        </div>
                        <div class="col-2 ">
                            <p>
                                Đến
                                <input type="text" class="form-control form-control-rounded datepicker" id="EndDate" autocomplete="off" name="date">
                            </p>

                        </div>
                    </div>
                    <div class="table-responsive">
                        <table class="table align-items-center table-flush table-borderless" id="default-datatable">
                            <thead>
                                <tr>
                                    <th>Mã Hóa Đơn</th>
                                    <th>Tên Khách Hàng</th>
                                    <th>Phương Thức</th>
                                    <th>Thành Tiền</th>
                                    <th>Ngày Tạo</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr data-ng-repeat="BangHoaDonThanhToan in BangHoaDonThanhToanGanDay">
                                    <td>{{BangHoaDonThanhToan.ID_hoa_don}}</td>
                                    <td>{{BangHoaDonThanhToan.Ten_khach_hang}}</td>
                                    <td>{{BangHoaDonThanhToan.Ten_phuong_thuc}}</td>
                                    <td>{{BangHoaDonThanhToan.Thanh_tien | currency}}</td>
                                    <td>{{BangHoaDonThanhToan.Ngay_tao}}</td>
                                </tr>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>Mã Hóa Đơn</th>
                                    <th>Tên Khách Hàng</th>
                                    <th>Phương Thức</th>
                                    <th>Thành Tiền</th>
                                    <th>Ngày Tạo</th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <!--End Row-->
    </div>
    <!--- End mycontroller -->
</asp:Content>
