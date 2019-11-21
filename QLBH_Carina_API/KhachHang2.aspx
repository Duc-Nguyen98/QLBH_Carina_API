<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="KhachHang2.aspx.cs" Inherits="QLBH_Carina_API.KhachHang2" %>

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

    <script>
        $(document).ready(function () { $("#table-khach-hang").DataTable({ language: { sProcessing: "Đang xử lý...", sLengthMenu: "Xem _MENU_ mục", sZeroRecords: "Không tìm thấy dòng nào phù hợp", sInfo: "Đang xem  _START_ đến _END_ trong tổng số _TOTAL_ mục", sInfoEmpty: "Đang xem 0 đến 0 trong tổng số 0 mục", sInfoFiltered: "(được lọc từ _MAX_ mục)", sInfoPostFix: "", sSearch: "Tìm:", sUrl: "", oPaginate: { sFirst: "Đầu", sPrevious: "Trước", sNext: "Tiếp", sLast: "Cuối" } } }), $("#example").DataTable({ language: { sProcessing: "Đang xử lý...", sLengthMenu: "Xem MENU mục", sZeroRecords: "Không tìm thấy dòng nào phù hợp", sInfo: "Đang xem  _START_ đến _END_ trong tổng số _TOTAL_ mục", sInfoEmpty: "Đang xem 0 đến 0 trong tổng số 0 mục", sInfoFiltered: "(được lọc từ _MAX_ mục)", sInfoPostFix: "", sSearch: "Tìm:", sUrl: "", oPaginate: { sFirst: "Đầu", sPrevious: "Trước", sNext: "Tiếp", sLast: "Cuối" } }, lengthChange: !1, buttons: ["copy", "excel", "pdf", "print", "colvis"] }).buttons().container().appendTo("#example_wrapper .col-md-6:eq(0)") });
    </script>
    <script src="assets/js/datepicker.min.js"></script>
    <script>
        $(function () { $(".datepicker").datepicker({ dateFormat: "dd/mm/yy" }) });
    </script>
    <script src="App_js/Khach_hang.js"></script>

    <div data-ng-controller="mycontroller">

        <div class="row">
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-header">
                        <div class="col-6 float-left">
                            <i class="fa fa-table"></i>Bảng Dữ Liệu Khách Hàng
                        </div>
                        <div class="col-6 float-right text-right">
                            <!-- Button Modal Khach Hang-->
                            <button type="button" class="btn btn-primary" data-toggle="modal" data-target=".modal_tao_moi_khach_hang" data-ng-click="item={}"><i class="fas fa-plus-circle"></i> Tạo Mới  </button>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <table id="table-khach-hang" class="default-datatable table table-bordered">
                                <thead>
                                    <tr>
                                        <th>Mã Khách Hàng</th>
                                        <th>Họ và Tên</th>
                                        <th>Ngày Sinh</th>
                                        <th>Địa Chỉ</th>
                                        <th>Email</th>
                                        <th>Thao Tác</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr data-ng-repeat="Bangkhachhang in NgBangkhachhang">
                                        <td>
                                            <p class="default-datatable-truncate" data-placement="bottom" title="{{Bangkhachhang.ID_khach_hang}}">{{Bangkhachhang.ID_khach_hang}}</p>
                                        </td>

                                        <td>
                                            <p class="default-datatable-truncate" data-placement="bottom" title="{{Bangkhachhang.Expr1}}">{{Bangkhachhang.Expr1}}</p>
                                        </td>

                                        <td>
                                            <p class="default-datatable-truncate" data-placement="bottom" title="{{Bangkhachhang.Ngay_sinh}}">{{Bangkhachhang.Ngay_sinh}}</p>
                                        </td>

                                        <td>
                                            <p class="default-datatable-truncate" data-placement="bottom" title="{{Bangkhachhang.Dia_chi}}">{{Bangkhachhang.Dia_chi}}</p>
                                        </td>

                                        <td>
                                            <p class="default-datatable-truncate" data-placement="bottom" title="{{Bangkhachhang.Email}}">{{Bangkhachhang.Email}}</p>
                                        </td>

                                        <td>
                                            <button type="button" class="btn btn-primary" data-toggle="modal" data-ng-click="LayThongTinKhachHang(Bangkhachhang)" data-target=".modal_edit_khach_hang"><i class="fas fa-eraser"></i></button>
                                            <button type="button" class="btn btn-primary" data-ng-click="XoaKhachHang(Bangkhachhang)"><i class="fas fa-trash"></i></button>
                                        </td>
                                    </tr>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th>Mã Khách Hàng</th>
                                        <th>Họ và Tên</th>
                                        <th>Ngày Sinh</th>
                                        <th>Địa Chỉ</th>
                                        <th>Email</th>
                                        <th>Thao Tác</th>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%-- End Row--%>
        <div class="row">
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-header"><i class="fa fa-table"></i>Xuất dữ liệu bảng khách hàng</div>

                    <div class="card-body">
                        <div class="table-responsive">
                            <table id="example" class="table table-bordered">

                                <thead>
                                    <tr>
                                        <th>Mã Khách Hàng</th>
                                        <th>Họ và Tên</th>
                                        <th>Ngày Sinh</th>
                                        <th>Quê Quán</th>
                                        <th>Địa Chỉ</th>
                                        <th>Email</th>
                                        <th>Số Điện Thoại</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr data-ng-repeat="Bangkhachhang in NgBangkhachhang ">
                                        <td>
                                            <p class="default-datatable-truncate" data-placement="bottom" title="{{Bangkhachhang.ID_khach_hang}}">{{Bangkhachhang.ID_khach_hang}}</p>
                                        </td>

                                        <td>
                                            <p class="default-datatable-truncate" data-placement="bottom" title="{{Bangkhachhang.Expr1}}">{{Bangkhachhang.Expr1}}</p>
                                        </td>

                                        <td>
                                            <p class="default-datatable-truncate" data-placement="bottom" title="{{Bangkhachhang.Ngay_sinh}}">{{Bangkhachhang.Ngay_sinh}}</p>
                                        </td>

                                        <td>
                                            <p class="default-datatable-truncate" data-placement="bottom" title="{{Bangkhachhang.Que_quan}}">{{Bangkhachhang.Que_quan}}</p>
                                        </td>

                                        <td>
                                            <p class="default-datatable-truncate" data-placement="bottom" title="{{Bangkhachhang.Dia_chi}}">{{Bangkhachhang.Dia_chi}}</p>
                                        </td>

                                        <td>
                                            <p class="default-datatable-truncate" data-placement="bottom" title="{{Bangkhachhang.Email}}">{{Bangkhachhang.Email}}</p>
                                        </td>

                                        <td>
                                            <p class="default-datatable-truncate" data-placement="bottom" title="{{Bangkhachhang.Dien_thoai}}">{{Bangkhachhang.Dien_thoai}}</p>
                                        </td>
                                    </tr>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th>Mã Khách Hàng</th>
                                        <th>Họ và Tên</th>
                                        <th>Ngày Sinh</th>
                                        <th>Quê Quán</th>
                                        <th>Địa Chỉ</th>
                                        <th>Email</th>
                                        <th>Số Điện Thoại</th>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%-- End Row--%>
        <!-- Modal Create new Khach Hang-->
        <div class="modal fade bd-example-modal-xl modal_tao_moi_khach_hang" tabindex="-1" role="dialog" aria-labelledby="myHugeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Tạo mới khách hàng</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <form id="personal-create-info-kh">

                            <div class="row">
                                <div class="col-sm-6">
                                    <label for="input-2">Họ</label>
                                    <input type="text" class="form-control form-control-rounded col-12" autocomplete="off" name="firtname" placeholder="Ví dụ: Tiến Lý" data-ng-model="taomoikhachhang.Ho" data-ng-required="required" maxlength="30">
                                </div>

                                <div class="col-sm-6">
                                    <label for="input-4">Tên</label>
                                    <input type="text" class="form-control form-control-rounded col-12" autocomplete="off" name="name" placeholder="Ví dụ: Hà Nội" data-ng-model="taomoikhachhang.Ten" data-ng-required="required" maxlength="30">
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <label for="input-3">Ngày Sinh</label>
                                    <input type="text" placeholder="dd/mm/yyyy" class="form-control form-control-rounded col-12 datepicker" autocomplete="off" name="date" data-ng-model="taomoikhachhang.Ngay_sinh" data-ng-required="required">
                                </div>

                                <div class="col-sm-6">
                                    <label for="input-3">Chọn Quê quán</label>
                                    <select class="form-control form-control-rounded col-12 " data-ng-model="taomoikhachhang.Que_quan" data-ng-required="required">
                                        <option value="" disabled="disabled" selected>Vui lòng chọn quên quán</option><option value="Bà Rịa - Vũng Tàu">Bà Rịa - Vũng Tàu</option><option value="Bắc Giang">Bắc Giang</option><option value="Bắc Kạn">Bắc Kạn</option><option value="Bạc Liêu">Bạc Liêu</option><option value="Bắc Ninh">Bắc Ninh</option><option value="Bến Tre">Bến Tre</option><option value="Bình Định">Bình Định</option><option value="Bình Dương">Bình Dương</option><option value="Bình Phước">Bình Phước</option><option value="Bình Thuận">Bình Thuận</option><option value="Cà Mau">Cà Mau</option><option value="Cao Bằng">Cao Bằng</option><option value="Đắk Lắk">Đắk Lắk</option><option value="Đắk Nông">Đắk Nông</option><option value="Điện Biên">Điện Biên</option><option value="Đồng Nai">Đồng Nai</option><option value="Đồng Tháp">Đồng Tháp</option><option value="Gia Lai">Gia Lai</option><option value="Hà Giang">Hà Giang</option><option value="Hà Nam">Hà Nam</option><option value="Hà Tĩnh">Hà Tĩnh</option><option value="Hải Dương">Hải Dương</option><option value="Hậu Giang">Hậu Giang</option><option value="Hòa Bình">Hòa Bình</option><option value="Hưng Yên">Hưng Yên</option><option value="Khánh Hòa">Khánh Hòa</option><option value="Kiên Giang">Kiên Giang</option><option value="Kon Tum">Kon Tum</option><option value="Lai Châu">Lai Châu</option><option value="Lâm Đồng">Lâm Đồng</option><option value="Lạng Sơn">Lạng Sơn</option><option value="Lào Cai">Lào Cai</option><option value="Long An">Long An</option><option value="Nam Định">Nam Định</option><option value="Nghệ An">Nghệ An</option><option value="Ninh Bình">Ninh Bình</option><option value="Ninh Thuận">Ninh Thuận</option><option value="Phú Thọ">Phú Thọ</option><option value="Quảng Bình">Quảng Bình</option><option value="Quảng Ngãi">Quảng Ngãi</option><option value="Quảng Ninh">Quảng Ninh</option><option value="Quảng Trị">Quảng Trị</option><option value="Sóc Trăng">Sóc Trăng</option><option value="Sơn La">Sơn La</option><option value="Tây Ninh">Tây Ninh</option><option value="Thái Bình">Thái Bình</option><option value="Thái Nguyên">Thái Nguyên</option><option value="Thanh Hóa">Thanh Hóa</option><option value="Thừa Thiên Huế">Thừa Thiên Huế</option><option value="Tiền Giang">Tiền Giang</option><option value="Trà Vinh">Trà Vinh</option><option value="Tuyên Quang">Tuyên Quang</option><option value="Vĩnh Long">Vĩnh Long</option><option value="Vĩnh Phúc">Vĩnh Phúc</option><option value="Yên Bái">Yên Bái</option><option value="Phú Yên">Phú Yên</option><option value="Tp.Cần Thơ">Tp.Cần Thơ</option><option value="Tp.Đà Nẵng">Tp.Đà Nẵng</option><option value="Tp.Hải Phòng">Tp.Hải Phòng</option><option value="Tp.Hà Nội">Tp.Hà Nội</option><option value="TP HCM">TP HCM</option>
                                    </select>
                                    </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <label for="input-3">Email</label>
                                    <input type="text" class="form-control form-control-rounded col-12" name="email" autocomplete="off" placeholder="Ví dụ: Hà Nội" data-ng-model="taomoikhachhang.Email" data-ng-required="required" maxlength="50">
                                </div>
                                <div class="col-sm-6">
                                    <label for="input-4">Điện Thoại</label>
                                    <input type="text" class="form-control form-control-rounded col-12" name="phone" autocomplete="off" placeholder="Ví dụ: Hà Nội" data-ng-model="taomoikhachhang.Dien_thoai" data-ng-required="required" maxlength="11">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <label for="input-5">Địa Chỉ</label>
                                    <input type="text" class="form-control form-control-rounded col-12" name="addess1" autocomplete="off" maxlength="100" placeholder="Ví dụ: Số 9 Nguyễn Văn Huyên , Cầu Giấy , Hà Nội" data-ng-model="taomoikhachhang.Dia_chi" data-ng-required="required" maxlength="60">
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Đóng</button>
                                <button type="button" class="btn btn-primary" data-ng-click="Taomoikhnoval()">Lưu Thay Đổi</button>
                            </div>
                        </form>

                    </div>
                </div>
            </div>
        </div>
        <!-- Modal Edit info Khach Hang-->
        <div class="modal fade bd-example-modal-xl modal_edit_khach_hang" tabindex="-1" role="dialog" aria-labelledby="myHugeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Thông tin khách hàng {{item.ID_khach_hang}}</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <form id="personal-edit-info">
                            <div class="row">
                                <div class="col-sm-6">
                                    <label for="input-2">Họ</label>
                                    <input type="text" class="form-control form-control-rounded col-12 read-only" readonly id="input-2" placeholder="Ví dụ: Tiến Lý" data-ng-model="item.Ho" />
                                </div>

                                <div class="col-sm-6">
                                    <label for="input-4">Tên</label>
                                    <input type="text" class="form-control form-control-rounded col-12 read-only" id="input-44" readonly placeholder="Ví dụ: Hà Nội" data-ng-model="item.Ten" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <label for="input-3">Ngày Sinh</label>
                                    <input type="text" class="form-control form-control-rounded col-12  read-only" readonly id="input-33" data-ng-model="item.Ngay_sinh" />
                                </div>
                                <div class="col-sm-6">
                                    <label for="input-3">Chọn Quê quán</label>
                                    <select class="form-control form-control-rounded col-12 " data-ng-model="item.Que_quan">
                                         <option value="{{item.Que_quan}}" disabled="disabled" selected>{{item.Que_quan}}</option><option value="Bà Rịa - Vũng Tàu">Bà Rịa - Vũng Tàu</option><option value="Bắc Giang">Bắc Giang</option><option value="Bắc Kạn">Bắc Kạn</option><option value="Bạc Liêu">Bạc Liêu</option><option value="Bắc Ninh">Bắc Ninh</option><option value="Bến Tre">Bến Tre</option><option value="Bình Định">Bình Định</option><option value="Bình Dương">Bình Dương</option><option value="Bình Phước">Bình Phước</option><option value="Bình Thuận">Bình Thuận</option><option value="Cà Mau">Cà Mau</option><option value="Cao Bằng">Cao Bằng</option><option value="Đắk Lắk">Đắk Lắk</option><option value="Đắk Nông">Đắk Nông</option><option value="Điện Biên">Điện Biên</option><option value="Đồng Nai">Đồng Nai</option><option value="Đồng Tháp">Đồng Tháp</option><option value="Gia Lai">Gia Lai</option><option value="Hà Giang">Hà Giang</option><option value="Hà Nam">Hà Nam</option><option value="Hà Tĩnh">Hà Tĩnh</option><option value="Hải Dương">Hải Dương</option><option value="Hậu Giang">Hậu Giang</option><option value="Hòa Bình">Hòa Bình</option><option value="Hưng Yên">Hưng Yên</option><option value="Khánh Hòa">Khánh Hòa</option><option value="Kiên Giang">Kiên Giang</option><option value="Kon Tum">Kon Tum</option><option value="Lai Châu">Lai Châu</option><option value="Lâm Đồng">Lâm Đồng</option><option value="Lạng Sơn">Lạng Sơn</option><option value="Lào Cai">Lào Cai</option><option value="Long An">Long An</option><option value="Nam Định">Nam Định</option><option value="Nghệ An">Nghệ An</option><option value="Ninh Bình">Ninh Bình</option><option value="Ninh Thuận">Ninh Thuận</option><option value="Phú Thọ">Phú Thọ</option><option value="Quảng Bình">Quảng Bình</option><option value="Quảng Ngãi">Quảng Ngãi</option><option value="Quảng Ninh">Quảng Ninh</option><option value="Quảng Trị">Quảng Trị</option><option value="Sóc Trăng">Sóc Trăng</option><option value="Sơn La">Sơn La</option><option value="Tây Ninh">Tây Ninh</option><option value="Thái Bình">Thái Bình</option><option value="Thái Nguyên">Thái Nguyên</option><option value="Thanh Hóa">Thanh Hóa</option><option value="Thừa Thiên Huế">Thừa Thiên Huế</option><option value="Tiền Giang">Tiền Giang</option><option value="Trà Vinh">Trà Vinh</option><option value="Tuyên Quang">Tuyên Quang</option><option value="Vĩnh Long">Vĩnh Long</option><option value="Vĩnh Phúc">Vĩnh Phúc</option><option value="Yên Bái">Yên Bái</option><option value="Phú Yên">Phú Yên</option><option value="Tp.Cần Thơ">Tp.Cần Thơ</option><option value="Tp.Đà Nẵng">Tp.Đà Nẵng</option><option value="Tp.Hải Phòng">Tp.Hải Phòng</option><option value="Tp.Hà Nội">Tp.Hà Nội</option><option value="TP HCM">TP HCM</option>
                                    </select>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm-6">
                                    <label for="input-3">Email</label>
                                    <input type="text" class="form-control form-control-rounded col-12" name="edit_email" autocomplete="off" placeholder="Ví dụ: Hà Nội" maxlength="50" data-ng-model="item.Email" data-ng-required="required" />
                                </div>
                                <div class="col-sm-6">
                                    <label for="input-4">Điện Thoại</label>
                                    <input type="text" class="form-control form-control-rounded col-12" name="edit_phone" autocomplete="off" placeholder="Ví dụ: Hà Nội" maxlength="11" data-ng-model="item.Dien_thoai" data-ng-required="required" />
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm-12">
                                    <label for="input-5">Địa Chỉ</label>
                                    <input type="text" class="form-control form-control-rounded col-12" name="edit_address" autocomplete="off" maxlength="100" placeholder="Ví dụ: Số 9 Nguyễn Văn Huyên , Cầu Giấy , Hà Nội" data-ng-model="item.Dia_chi" data-ng-required="required" />
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm-6">
                                    <label for="input-3">Ngày Tạo</label>
                                    <input type="text" class="form-control form-control-rounded col-12 read-only" readonly id="input-62" data-ng-model="item.Ngay_tao" />
                                </div>
                                <div class="col-sm-6">
                                    <label for="input-4">Ngày Cập Nhật</label>
                                    <input type="text" class="form-control form-control-rounded col-12 read-only" readonly id="input-63" data-ng-model="item.Ngay_cap_nhat" />
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Đóng</button>
                                <button class="btn btn-primary" data-ng-click="CapnhatKh()">Lưu Thay đổi</button>
                            </div>
                        </form>
                    </div>

                </div>
            </div>
        </div>

    </div>
    <!-- End mycontroller-->
</asp:Content>
