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
        $(document).ready(function () {
            //Default data table
            $('.default-datatable').DataTable();

        });
    </script>
    <script src="assets/js/datepicker.min.js"></script>
    <script>
        $(function () {
            $(".datepicker").datepicker({
                dateFormat: 'dd/mm/yy'
            });

        });

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
                            <button type="button" class="btn btn-primary" data-toggle="modal" data-target=".modal_tao_moi_khach_hang" data-ng-click="item={}">
                                Modal Khách Hàng
                            </button>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <table class="default-datatable table table-bordered">
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
                                            <button type="button" class="btn btn-primary" data-toggle="modal" data-ng-click="LayThongTinKhachHang(Bangkhachhang)" data-target=".modal_edit_khach_hang">1</button>
                                            <button type="button" class="btn btn-primary" data-ng-click="XoaKhachHang(Bangkhachhang)">2</button>
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
                                    <label for="input-3">Quê Quán</label>
                                    <input type="text" placeholder="Doãn  Thượng- Xuân Lâm- Thận Thành - Bắc Ninh" name="addess" autocomplete="off" class="form-control form-control-rounded col-12" data-ng-model="taomoikhachhang.Que_quan" data-ng-required="required" maxlength="30">
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
                                    <label for="input-3">Quê Quán</label>
                                    <input type="text" class="form-control form-control-rounded col-12 read-only" id="input-42" readonly placeholder="Ví dụ: Hà Nội" data-ng-model="item.Que_quan" />
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
