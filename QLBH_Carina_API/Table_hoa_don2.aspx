<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Table_hoa_don2.aspx.cs" Inherits="QLBH_Carina_API.Table_hoa_don2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Data Tables -->
    <link href="assets/plugins/bootstrap-datatable/css/dataTables.bootstrap4.min.css" rel="stylesheet" type="text/css">
    <link href="assets/plugins/bootstrap-datatable/css/buttons.bootstrap4.min.css" rel="stylesheet" type="text/css">
    <!--Data Tables js-->
    <script src="assets/plugins/bootstrap-datatable/js/jquery.dataTables.min.js"></script>
    <script src="assets/plugins/bootstrap-datatable/js/dataTables.bootstrap4.min.js"></script>
    <script src="assets/plugins/bootstrap-datatable/js/dataTables.buttons.min.js"></script>
    <script src="assets/plugins/bootstrap-datatable/js/buttons.bootstrap4.min.js"></script>
    <script src="assets/plugins/bootstrap-datatable/js/jszip.min.js"></script>
    <script src="assets/plugins/bootstrap-datatable/js/pdfmake.min.js"></script>
    <script src="assets/plugins/bootstrap-datatable/js/vfs_fonts.js"></script>
    <script src="assets/plugins/bootstrap-datatable/js/buttons.html5.min.js"></script>
    <script src="assets/plugins/bootstrap-datatable/js/buttons.print.min.js"></script>
    <script src="assets/plugins/bootstrap-datatable/js/buttons.colVis.min.js"></script>
    <style>
        .input_for_mail{
            border: none!important;
            background: transparent!important;
            width: 50%!important;
            display: inline-flex!important;
            font-size: 1em!important;
        }
    </style>
    <script>
        $(document).ready(function () { $("#default-datatable").DataTable({ language: { sProcessing: "Đang xử lý...", sLengthMenu: "Xem _MENU_ mục", sZeroRecords: "Không tìm thấy dòng nào phù hợp", sInfo: "Đang xem _START_ đến _END_ trong tổng số _TOTAL_ mục", sInfoEmpty: "Đang xem 0 đến 0 trong tổng số 0 mục", sInfoFiltered: "(được lọc từ _MAX_ mục)", sInfoPostFix: "", sSearch: "Tìm:", sUrl: "", oPaginate: { sFirst: "Đầu", sPrevious: "Trước", sNext: "Tiếp", sLast: "Cuối" } } }), $("#example").DataTable({ language: { sProcessing: "Đang xử lý...", sLengthMenu: "Xem MENU mục", sZeroRecords: "Không tìm thấy dòng nào phù hợp", sInfo: "Đang xem  _START_ đến _END_ trong tổng số _TOTAL_ mục", sInfoEmpty: "Đang xem 0 đến 0 trong tổng số 0 mục", sInfoFiltered: "(được lọc từ _MAX_ mục)", sInfoPostFix: "", sSearch: "Tìm:", sUrl: "", oPaginate: { sFirst: "Đầu", sPrevious: "Trước", sNext: "Tiếp", sLast: "Cuối" } }, lengthChange: !1, buttons: ["copy", "excel", "pdf", "print", "colvis"] }).buttons().container().appendTo("#example_wrapper .col-md-6:eq(0)") });
    </script>
    <script>
        function sendmail() {
            swal("Thành Công!", "Đã gửi yêu cầu thanh toán qua mail của khách hàng.", "success")
        }
    </script>
    <script src="App_js/Hoa_don.js"></script>
    <div data-ng-controller="mycontroller">
        <!-- view hoa don  -->
        <div class="row">
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-header">
                        <div class="col-6 float-left">
                            <i class="fa fa-table"></i>Bảng Dữ Liệu Hóa Đơn & Chi Tiết Hóa Đơn
                        </div>
                        <div class="col-6 float-right text-right">
                            <!-- Button Modal Hoa Don & Chi tiet -->
                            <button type="button" class="btn btn-primary" data-toggle="modal" data-target=".modal_hoa_don_chi_tiet" data-ng-click="item={}"><i class="fas fa-plus-circle"></i> Tạo Mới</button>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <table id="default-datatable" class="table table-bordered">
                                <thead>
                                    <tr>
                                        <th>Mã Hóa Đơn</th>
                                        <th>Tên Khách Hàng</th>
                                        <th>Địa Chỉ Giao Hàng</th>
                                        <th>Phương Thức</th>
                                        <th>Trạng Thái</th>
                                        <th>Chức Năng</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr data-ng-repeat="BangHoaDon in NgBangHoaDon">
                                        <td>{{BangHoaDon.ID_hoa_don}}

                                        </td>
                                        <td>
                                            <p class="default-datatable-truncate" data-placement="bottom" title="{{BangHoaDon.Ten_khach_hang}}">{{BangHoaDon.Ten_khach_hang}}</p>

                                        </td>
                                        <td>
                                            <p class="default-datatable-truncate" data-placement="bottom" title="{{BangHoaDon.Dia_chi_giao_hang}}">{{BangHoaDon.Dia_chi_giao_hang}}</p>
                                        </td>
                                        <td>
                                            <p class="default-datatable-truncate" data-placement="bottom" title="{{BangHoaDon.Ten_phuong_thuc}}">{{BangHoaDon.Ten_phuong_thuc}}</p>
                                        </td>
                                        <td>
                                            <p class="default-datatable-truncate" data-placement="bottom" title="{{BangHoaDon.Ten_trang_thai}}">{{BangHoaDon.Ten_trang_thai}}</p>
                                            <td>

                                                <button type="button" class="button btn btn-primary" data-placement="bottom" title="Xuất Nhập Hóa Đơn" data-ng-click="LayThongTinHoaDon(BangHoaDon)" data-toggle="modal" data-target=".bd-example-modal-xl"><i class="fas fa-info-circle"></i></button>
                                                <button type="button" class="btn btn-primary" data-toggle="modal" data-target=".modal_edit_hoa_don_chi_tiet" data-placement="bottom" title="Sửa Thông Tin Hóa Đơn" data-ng-click="LayThongTinHoaDon(BangHoaDon)"><i class="fas fa-eraser"></i></button>
                                                <button type="button" class="btn btn-primary" data-placement="bottom" title="Xóa Thông Tin Hóa Đơn" data-ng-click="XoaHoaDon(BangHoaDon)"><i class="fas fa-trash"></i></button>
                                            </td>
                                    </tr>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th>Mã Hóa Đơn</th>
                                        <th>Tên Khách Hàng</th>
                                        <th>Địa Chỉ Giao Hàng</th>
                                        <th>Phương Thức</th>
                                        <th>Trạng Thái</th>
                                        <th>Chức Năng</th>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%-- End Row--%>
        <!-- view hoa don  -->
        <div class="row">
            <div class="col-lg-12">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header"><i class="fa fa-table"></i> Data Exporting</div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <table id="example" class="table table-bordered">
                                    <thead>
                                        <tr>
                                            <th>Mã Hóa Đơn</th>
                                            <th>Tên Khách Hàng</th>
                                            <th>Giá Nhân Viên</th>
                                            <th>Địa Chỉ Giao Hàng</th>
                                            <th>Tên Phương Thức</th>
                                            <th>Tên Trạng Thái</th>
                                            <th>Ngày Tạo</th>
                                            <th>Ngày Cập Nhật</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr data-ng-repeat="BangHoaDon in NgBangHoaDon">
                                            <td>
                                                <p class="default-datatable-truncate" data-placement="bottom" title="{{BangHoaDon.ID_hoa_don}}">{{BangHoaDon.ID_hoa_don}}</p>
                                            </td>
                                            <td>
                                                <p class="default-datatable-truncate" data-placement="bottom" title="{{BangHoaDon.Ten_khach_hang}}">{{BangHoaDon.Ten_khach_hang}}</p>
                                            </td>
                                            <td>
                                                <p class="default-datatable-truncate" data-placement="bottom" title="{{BangHoaDon.Ten_nhan_vien}}">{{BangHoaDon.Ten_nhan_vien}}</p>
                                            </td>
                                            <td>
                                                <p class="default-datatable-truncate" data-placement="bottom" title="{{BangHoaDon.Dia_chi_giao_hang}}">{{BangHoaDon.Dia_chi_giao_hang}}</p>
                                            </td>
                                            <td>
                                                <p class="default-datatable-truncate" data-placement="bottom" title="{{BangHoaDon.Ten_phuong_thuc}}">{{BangHoaDon.Ten_phuong_thuc}}</p>
                                            </td>
                                            <td>
                                                <p class="default-datatable-truncate" data-placement="bottom" title="{{BangHoaDon.Ten_trang_thai}}">{{BangHoaDon.Ten_trang_thai}}</p>
                                            </td>
                                            <td>
                                                <p class="default-datatable-truncate" data-placement="bottom" title="   {{BangHoaDon.Ngay_tao }}">{{BangHoaDon.Ngay_tao | date : format : "dd.MM.y" }}</p>
                                            </td>
                                            <td>
                                                <p class="default-datatable-truncate" data-placement="bottom" title="{{BangHoaDon.Ngay_cap_nhat}}">{{BangHoaDon.Ngay_cap_nhat}}</p>
                                            </td>
                                        </tr>
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <th>Mã Hóa Đơn</th>
                                            <th>Tên Khách Hàng</th>
                                            <th>Giá Nhân Viên</th>
                                            <th>Địa Chỉ Giao Hàng</th>
                                            <th>Tên Phương Thức</th>
                                            <th>Tên Trạng Thái</th>
                                            <th>Ngày Tạo</th>
                                            <th>Ngày Cập Nhật</th>
                                        </tr>
                                    </tfoot>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%-- End Row--%>
        <!-- Modal Create New Hoa Don -->
        <div class="modal fade modal_hoa_don_chi_tiet" role="dialog">
            <div class="modal-dialog modal-xl">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Tạo mới hóa đơn</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <form id="taomoi">

                            <div class="row">
                                <div class="col-sm-6">
                                    <label for="input-3">Chọn khách hàng</label>
                                    <select class="form-control form-control-rounded" data-ng-model="taomoihoadon.ID_khach_hang" name="khachhang" data-ng-options="data.ID_khach_hang as data.Ten_khach_hang for data in DanhMucKhachHangg" data-ng-required="required">
                                        <option selected="" disabled="" value="">Vui lòng chọn khách hàng</option>
                                    </select>
                                </div>

                                <div class="col-sm-6">
                                    <label for="input-4">Chọn nhân viên</label>
                                    <select class="form-control form-control-rounded" data-ng-model="taomoihoadon.ID_nhan_vien" name="nhanvien" data-ng-options="data.ID_nhan_vien as data.Ten_nhan_vien for data in DanhMucNhanVienn" data-ng-required="required">
                                        <option selected="" disabled="" value="">Vui lòng chọn nhân viên</option>
                                    </select>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <label for="input-4">Địa Chỉ Giao Hàng</label>
                                    <input type="text" class="form-control form-control-rounded col-12" name="diachi" placeholder="Ví dụ: dịa chỉ" autocomplete="off" data-ng-model="taomoihoadon.Dia_chi_giao_hang" data-ng-required="required">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <label for="input-5">Phương Thức Thanh Toán</label>
                                    <select class="form-control form-control-rounded" id="basic-select3" data-ng-model="taomoihoadon.ID_phuong_thuc" name="phuongthuc" data-ng-options="data.ID_phuong_thuc as data.Ten_phuong_thuc for data in DanhMucPhuongThucc" data-ng-required="required">
                                        <option selected="" disabled="" value="">Vui Lòng Chọn Phương Thức Thanh Toán</option>
                                    </select>

                                </div>
                                <div class="col-sm-6">
                                    <label for="input-3">Tình Trạng Hóa Đơn</label>
                                    <select class="form-control form-control-rounded" id="basic-select" data-ng-model="taomoihoadon.ID_trang_thai" name="trangthai" data-ng-options="data.ID_trang_thai as data.Ten_trang_thai for data in DanhMucTrangThaii" data-ng-required="required">
                                        <option selected="" value="" disabled="">Vui Lòng Chọn Tình Trạng Hóa Đơn</option>
                                    </select>
                                </div>
                            </div>

                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Đóng</button>
                                <button type="button" class="btn btn-primary" data-ng-click="Taomoikhnoval()">Tạo mới</button>

                            </div>

                        </form>
                    </div>

                </div>
            </div>
        </div>
        <!-- End Modal Create New Hoa Don= -->

        <!--Modal In Hoa Don-->
        <div class="modal fade bd-example-modal-xl" tabindex="-1" role="dialog" aria-labelledby="myHugeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-xl">
                <div class="modal-content">
                    <div class="card">
                        <div class="card-body">
                            <!-- Content Header (Page header) -->
                            <%-- Main bill--%>
                            <div class="main_bill" id="div_table">
                                <section class="content-header">
                                    <h4><i class="fa fa-globe"></i>Quản lý Thông Tin Hóa Đơn Carina</h4>
                                </section>

                                <!-- Main content -->
                                <section class="invoice">
                                    <!-- title row -->

                                    <div class="row mt-3">
                                        <div class="col-lg-6">
<%--                                            <h5>Mã Hóa Đơn - <input type="text" class="form-control form-control-rounded col-12 read-only" style="border: none;background: transparent;" readonly  data-ng-model="item.ID_hoa_don">  </h5>--%>
                                           <h5> Mã Hóa Đơn - <asp:TextBox ID="ID_hoa_don_mail" class="form-control form-control-rounded col-12 read-only input_for_mail" runat="server" ReadOnly="true"  data-ng-model="item.ID_hoa_don"></asp:TextBox> </h5>
          <%--                                  <small>{{item.ID_hoa_don}}</small>--%>
                                          
                                        </div>
                                        <div class="col-lg-6">
                                            <h5 class="float-sm-right">Ngày Tạo: <small>{{item.Ngay_tao  | date : format : "dd.MM.y" }}</small></h5>
                                        </div>
                                    </div>

                                    <hr>
                                    <div class="row invoice-info">
                                        <div class="col-sm-6 invoice-col">
                                            <address>
                                                <p><strong>Tên Khách Hàng:</strong> {{item.Ten_khach_hang}}</p>
                                                <p><strong>Địa Chỉ Nhận Hàng:</strong>{{item.Dia_chi_giao_hang}} </p>
                                                <p><strong>Số Điện Thoại:</strong> {{item.Dien_thoai}}</p>
                                                <p><strong>Địa Chỉ Email:</strong> {{item.Email}} </p>
                                                <p><strong>Tên Phương thức:</strong> {{item.Ten_phuong_thuc}} </p>
                                                <p><strong>Trạng Thái:</strong> {{item.Ten_trang_thai}} </p>
                                            </address>
                                        </div>
                                        <!-- /.col -->

                                        <div class="col-lg-6 payment-icons">
                                            <p class="lead">Phương Thức Thanh Toán:</p>
                                            <img id="img1" class="dis" src="assets/images/payment-icons/visa-dark.png" alt="Visa">
                                            <img id="img2" class="dis" src="assets/images/payment-icons/mastro-dark.png" alt="Mastercard">
                                            <img id="img3" class="dis" src="assets/images/payment-icons/momo.png" alt="American Express">
                                            <img id="img4" class="dis" src="assets/images/payment-icons/paypal-dark.png" alt="Paypal">
                                            <img id="img5" class="dis" src="assets/images/payment-icons/onlinecarina.png" alt="Paypal">
                                        </div>
                                        <!-- /.col -->
                                    </div>
                                    <!-- /.row -->

                                    <!-- Table row -->
                                    <div class="row">
                                        <div class="col-lg-7 table-responsive">
                                            <table class="table table-striped">
                                                <thead>
                                                    <tr>
                                                        <th>Số Lượng</th>
                                                        <th>Tên Mặt Hàng</th>
                                                        <th>Tên Phân Loại</th>
                                                        <th>Giá hàng </th>

                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr data-ng-repeat="BangChiTiett in NgBangChiTiet ">
                                                        <td>{{BangChiTiett.So_luong}}</td>
                                                        <td>{{BangChiTiett.Ten_hang}}</td>
                                                        <td>{{BangChiTiett.Ten_phan_loai}}</td>
                                                        <td>{{BangChiTiett.Gia_hang | currency}}</td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        <!-- /.col -->
                                        <div class="col-lg-5">
                                            <p class="lead">Thống Kê</p>
                                            <div class="table-responsive">
                                                <table class="table">
                                                    <tbody data-ng-repeat="BangThongKeTotall in NgBangThongKeTotal">
                                                        <tr>
                                                            <th>Số sản phẩm trong hóa đơn:</th>
                                                            <td>{{BangThongKeTotall.So_luong_mat_hang_now}}</td>
                                                        </tr>
                                                        <tr>
                                                            <th>Tổng sản phẩm</th>
                                                            <td>{{BangThongKeTotall.so_luong_now}}</td>
                                                        </tr>
                                                        <tr>
                                                            <th>Tổng tiền:</th>
                                                            <td>{{BangThongKeTotall.Tong_tien_now | currency}}</td>
                                                        </tr>

                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                        <!-- /.col -->
                                    </div>
                                    <!-- /.row -->
                                </section>
                            </div>
                            <%--end main bill--%>

                            <!-- this row will not appear when printing -->
                            <hr>
                            <div class="row no-print">
                                <div class="col-lg-3">
                                    <a id="div_print" class="btn btn-light m-1"><i class="fa fa-print"></i>In Hóa Đơn</a>
                                </div>
                                <div class="col-lg-9">
                                    <div class="float-sm-right">
                                        <%--<asp:LinkButton ID="Sendmail" CssClass="btn btn-success m-1" OnClick="SendMail_Click" runat="server"><i class="fa fa-credit-card"></i>Gửi Yêu Cầu Thanh Toán</asp:LinkButton>--%>
                                        <button Class="btn btn-success m-1" type="button" data-ng-click="GuiYeuCauThanhToan()"><i class="fa fa-credit-card"></i>Gửi Yêu Cầu Thanh Toán</button>
                                    </div>
                                </div>
                            <!-- /.content -->
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--Modal In Hoa Don-->

        <!-- Modal Edit Hoa Don =-->
        <div class="modal fade modal_edit_hoa_don_chi_tiet" role="dialog">
            <div class="modal-dialog modal-xl">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Thông tin chi tiết của hóa đơn {{item.ID_hoa_don}}</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <form id="diachi">

                            <div class="row">
                                <div class="col-sm-6">
                                    <label for="input-1">Tên Khách Hàng</label>
                                    <input type="text" class="form-control form-control-rounded col-12 read-only" readonly id="input-21" data-ng-model="item.Ten_khach_hang">
                                </div>
                                <div class="col-sm-6">
                                    <label for="input-3">Tên Nhân Viên</label>
                                    <select class="form-control form-control-rounded" data-ng-model="item.ID_nhan_vien" data-ng-options="data.ID_nhan_vien as data.Ten_nhan_vien for data in DanhMucNhanVienn">
                                    </select>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <label for="input-4">Địa Chỉ Giao Hàng</label>
                                    <input type="text" class="form-control form-control-rounded col-12" id="input-44" data-ng-model="item.Dia_chi_giao_hang" name="giaohang" autocomplete="off" data-ng-required="required">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <label for="input-5">Phương Thức Thanh Toán</label>
                                    <select class="form-control form-control-rounded" data-ng-model="item.ID_phuong_thuc" data-ng-options="data.ID_phuong_thuc as data.Ten_phuong_thuc for data in DanhMucPhuongThucc">
                                    </select>
                                </div>
                                <div class="col-sm-6">
                                    <label for="input-3">Tình Trạng Hóa Đơn</label>
                                    <select class="form-control form-control-rounded" data-ng-model="item.ID_trang_thai" data-ng-options="data.ID_trang_thai as data.Ten_trang_thai for data in DanhMucTrangThaii">
                                    </select>
                                </div>
                            </div>
                            <!-- Danh sách mặt hàng -->
                            <div class="card mb-0">
                                <div class="card-header"></div>
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-6 ">
                                            <h5 class="py-2">Danh sách các Sản Phẩm</h5>
                                        </div>
                                        <div class="col-6">
                                            <button type="button" class="btn btn-primary float-right" data-toggle="modal" data-target=".modal_con_tao_moi_chi_tiet" data-ng-click="item_chitiet={}">
                                                Thêm Mới Sản Phẩm
                                            </button>
                                        </div>
                                        <div class="table-responsive text-left">
                                            <table id="" class="table table-bordered">
                                                <thead>
                                                    <tr>
                                                        <th>Tên Mặt Hàng</th>
                                                        <th>Tên Phân Loại</th>
                                                        <th>Giá Bán</th>
                                                        <th>Số Lượng</th>
                                                        <th>Chức Năng</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr data-ng-repeat="BangChiTiett in NgBangChiTiet ">
                                                        <%--<td>{{s.ID_hoa_don}}</td>--%>
                                                        <td>{{BangChiTiett.Ten_hang}}</td>
                                                        <td>{{BangChiTiett.Ten_phan_loai}}</td>
                                                        <td>{{BangChiTiett.Gia_hang | currency}}</td>
                                                        <%--<td>{{BangChiTiett.ID_chi_tiet}}</td>--%>
                                                        <td>{{BangChiTiett.So_luong}}</td>
                                                        <td>
                                                            <button type="button" class="btn btn-primary" data-toggle="modal" data-target=".modal_con_sua_chi_tiet" data-placement="bottom" title="Sửa Thông Tin Sản Phẩm" data-ng-click="LayThongTinChiTiet(BangChiTiett)"><i class="fas fa-eraser"></i></button>
                                                            <button type="button" class="btn btn-primary" data-placement="bottom" title="Xóa Thông Tin Sản Phẩm" data-ng-click="XoaChiTietHoaDon(BangChiTiett)"><i class="fas fa-trash"></i></button>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                                <tfoot>
                                                    <tr>
                                                        <th>Tên Mặt Hàng</th>
                                                        <th>Tên Phân Loại</th>
                                                        <th>Giá Bán</th>
                                                        <th>Số Lượng</th>
                                                        <th>Chức Năng</th>
                                                        <%-- <th>Chức Năng</th>--%>
                                                    </tr>
                                                </tfoot>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- Thông kê cho hóa đơn -->
                            <div class="col-12 text-right" data-ng-repeat="BangThongKeTotall in NgBangThongKeTotal">
                                <h5>Số sản phẩm hiện có trong hóa đơn: {{BangThongKeTotall.So_luong_mat_hang_now}}</h5>
                                <h5>Tổng số lượng sản phẩm: {{BangThongKeTotall.so_luong_now}}</h5>
                                <h5>Tổng tiền: {{BangThongKeTotall.Tong_tien_now | currency}}</h5>
                            </div>
                            <!--</div>-->
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Đóng</button>
                                <button class="btn btn-primary" data-ng-click="CapNhatHD()">Lưu Thay Đổi</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Modal Edit Hoa Don =-->
        <!-- Modal Con Edit  Chi Tiet-->
        <div class="modal fade modal_con_sua_chi_tiet" role="dialog">
            <div class="modal-dialog modal-lg">
                <!-- Modal content-->
                <div class="modal-content modal_top">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModal7Label2">Chi tiết sản phẩm</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-sm-6">
                                <label for="input-4">Tên Sản Phẩm</label>
                                <input type="text" class="form-control form-control-rounded read-only" data-placement="bottom" title="Bạn chỉ có thể thay đổi thông tin của ô số lượng" readonly="readonly" id="input-75" data-ng-model="item_chitiet.Ten_hang">
                            </div>
                            <div class="col-sm-6">
                                <label for="input-4">Số Lượng</label>
                                <input type="number" class="form-control form-control-rounded col-12" value="{{item_chitiet.So_luong}}" id="input-45" min="0" max="50" data-ng-model="item_chitiet.So_luong" autocomplete="off">
                            </div>
                            <div class="col-sm-6">
                                <label for="input-4">Giá Bán</label>
                                <input type="text" class="form-control form-control-rounded col-12 read-only" readonly="readonly" data-placement="bottom" title="Bạn chỉ có thể thay đổi thông tin của ô số lượng" id="input-46" data-ng-model="item_chitiet.Gia_hang">
                            </div>
                            <div class="col-sm-6">
                                <label for="input-4">Thành Tiền</label>
                                <input type="text" class="form-control form-control-rounded col-12 read-only" readonly="readonly" data-placement="bottom" title="Bạn chỉ có thể thay đổi thông tin của ô số lượng" id="input-47" value="{{item_chitiet.So_luong * item_chitiet.Gia_hang | currency}}">
                            </div>
                            <div class="col-sm-12">
                                <label for="input-4">Tên Nhà Cung Cấp</label>
                                <input type="text" class="form-control form-control-rounded col-12 read-only" readonly="readonly" data-placement="bottom" title="Bạn chỉ có thể thay đổi thông tin của ô số lượng" id="input-48" data-ng-model="item_chitiet.Ten_nha_cung_cap">
                            </div>

                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Thoát</button>
                        <button type="button" class="btn btn-primary" data-ng-click="CapNhatCTHD()">Lưu Thay Đổi</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Modal Con Edit Chi Tiet-->
        <!-- Modal Con Create New  Chi Tiet-->
        <div class="modal fade modal_con_tao_moi_chi_tiet" role="dialog">
            <div class="modal-dialog modal-lg">
                <!-- Modal content-->
                <div class="modal-content modal_top">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModal7Label22">Tạo thêm mới sản phẩm</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <form id="myform-update">

                            <div class="row">
                                <div class="col-sm-6">
                                    <label for="input-4">Chọn Sản Phẩm</label>
                                    <select class="form-control form-control-rounded" id="basic-select5" data-ng-model="taomoichitiethoadon.ID_mat_hang" data-ng-options="data.ID_mat_hang as data.Ten_hang for data in DanhMucMatHangg" name="sanpham" data-ng-required="required">
                                        <option selected="" disabled="" value="">Vui Lòng Chọn Mặt Hàng</option>
                                    </select>
                                </div>

                                <div class="col-sm-6">
                                    <label for="input-4">Số Lượng</label>
                                    <input type="number" class="form-control form-control-rounded col-12" value="1" min="0" max="50" data-ng-model="taomoichitiethoadon.So_luong" autocomplete="off" name="soluong" data-ng-required="required">
                                </div>

                            </div>

                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Đóng</button>
                                <button class="btn btn-primary" data-ng-click="TaoMoiCTHD()">Tạo mới</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="https://printjs-4de6.kxcdn.com/print.min.js"></script>
    <script>
        document.getElementById('div_print').addEventListener("click", print)
        function print() {
            printJS({
                printable: 'div_table',
                type: 'html',
                targetStyles: ['*'],
            })
        }
    </script>
        </div>
    <%--End mycontroller--%>
</asp:Content>
