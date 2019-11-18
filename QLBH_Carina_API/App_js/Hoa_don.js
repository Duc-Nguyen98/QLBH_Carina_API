app.controller('mycontroller', function ($scope) {
    //<----------Xử lý phần hóa đơn ------------>

    // lay thong tin bang hoa don
    $.ajax({
        url: 'api/HoaDon_ChiTiet/BangHoaDon',
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data !== null) {
                $scope.NgBangHoaDon = data;
                //document.getElementById("TongSo").innerHTML = "<b>Total Customer : </b>" + $scope.BangHoangHoa.length;

            }
            else
                document.write("Rỗng");
        }

    });


    // tao moi hóa đơn  chua sử dụng validate
    $scope.Taomoikhnoval = function () {
        var hd = $scope.taomoihoadon.ID_khach_hang;
        swal({
            title: "Bạn chắc chứ?",
            text: "Bạn muốn tạo mới hóa đơn" + " " + hd + "!",
            icon: "info",
            buttons: true,
            dangerMode: true,
        }).then((willCreateNew) => {
            var hd = $scope.taomoihoadon.ID_hoa_don;
            if (willCreateNew) {
                swal("Thành công!", "Bạn đã tạo mới thành công hóa đơn" + " " + kh1 + "!", {
                    icon: "success",
                    timer: 2000,
                }).then(function () {
                    setTimeout(function () {
                        $('#modal_tao_moi_khach_hang').modal('hide'); // close modal 
                        $.ajax({
                            url: "api/HoaDon_ChiTiet/TaoMoiHoaDon",
                            type: "post",
                            dataType: "text",
                            data: $scope.taomoihoadon,
                            success: function (result) {
                                //load lại bảng hóa đơn
                                $.ajax({
                                    url: 'api/HoaDon_ChiTiet/BangHoaDon',
                                    type: "GET",
                                    contentType: 'application/json; charset=utf-8',
                                    dataType: 'json',
                                    async: false,
                                    success: function (data) {
                                        if (data !== null) {
                                            $scope.NgBangHoaDon = data;
                                            $scope.$apply();
                                        }
                                        else
                                            alert('ss')
                                    }
                                });
                            },
                            error: function () {
                                alert('Error occurs!');
                            }
                        });
                    }, 400);
                });
            }
            else {
                var kh1 = $scope.taomoihoadon.ID_hoa_don;
                swal("Thất bại", "Bạn đã hủy tạo mới hóa đơn" + " " + kh1 + "!", "error");
            }
        });
    }

    // tạo mới hóa đơn gọi đến angular khách hàng + hàm validate 
    $scope.TaoMoiHD = function () {
        $("#personal-create-info").validate({
            rules: {
                khachhang: {
                    required: true,

                },
                nhanvien: {
                    required: true,


                },
                diachi: {
                    required: true,

                },
                phuongthuc: {
                    required: true,

                },
                hoadon: {
                    required: true,
                    maxlength: 50

                },

            },
            messages: {

                khachhang: {
                    required: "Bạn hãy chọn khách hàng",

                },
                nhanvien: {
                    required: "Bạn chọn nhân viên",

                },
                diachi: {
                    required: "Bạn vui lòng điền địa chỉ",


                },
                phuongthuc: {
                    required: "Bạn vui lòng chọn phương thức thanh toán",

                },
                hoadon: {
                    required: "Bạn vui lòng chọn tình trạng hóa đơn",

                },
            },
            submitHandler: function (form) {

                $scope.Taomoikhnoval();

            }
        })
    }

    // xóa hoadon
    $scope.XoaHoaDon = function (item) {
        var hdxoa = item.ID_hoa_don;
        swal({
            title: "Bạn chắc chứ?",
            text: "Bạn muốn xóa hóa đơn" + " " + hdxoa + "?!",
            icon: "info",
            buttons: true,
            dangerMode: true,
        }).then((willCreateNew) => {

            if (willCreateNew) {
                var hdxoa = item.ID_hoa_don;
                swal("Thành công!", "Bạn đã xóa thành công hóa đơn" + " " + hdxoa + "!", {
                    icon: "success",
                    timer: 2000,
                }).then(function () {
                    setTimeout(function () {
                        $.ajax({
                            url: "/api/HoaDon_ChiTiet/XoaHoaDon/",
                            type: "delete",
                            dataType: "text",
                            data: item,
                            success: function (result) {
                                //load lại bảng hóa đơn
                                $.ajax({
                                    url: 'api/HoaDon_ChiTiet/BangHoaDon',
                                    type: "GET",
                                    contentType: 'application/json; charset=utf-8',
                                    dataType: 'json',
                                    async: false,
                                    success: function (data) {

                                        if (data !== null) {

                                            $scope.NgBangHoaDon = data;
                                            $scope.$apply();


                                        }
                                        else
                                            alert('ss')
                                    }

                                });
                            }
                        });
                    }, 0);
                });
            }
            else {
                var hdxoa = item.ID_hoa_don;
                swal("Thất bại", "Bạn đã hủy xóa hóa đơn" + " " + hdxoa + "!", "error");
            }
        });
    }



    // cập nhật sản phẩm  chua sử dụng validate
    $scope.Capnhatspnoval = function () {
        var hd1 = $scope.item.ID_hoa_don;
        swal({
            title: "Bạn chắc chứ?",
            text: "Bạn muốn cập nhật hóa đơn" + " " + hd1 + "?",
            icon: "info",
            buttons: true,
            dangerMode: true,
        }).then((willCreateNew) => {
            var hd1 = $scope.item.ID_hoa_don;
            if (willCreateNew) {
                swal("Thành công!", "Bạn đã cập nhật thành công hóa đơn" + " " + hd1 + "!", {
                    icon: "success",
                    timer: 2000,
                }).then(function () {
                    setTimeout(function () {
                        $('.modal_edit_hoa_don_chi_tiet').modal('hide'); // close modal 
                        $.ajax({
                            url: "api/HoaDon_ChiTiet/CapNhatHoaDon/",
                            type: "post",
                            dataType: "text",
                            data: $scope.item,
                            success: function (result) {
                                //load lại bảng hóa đơn
                                $.ajax({
                                    url: 'api/HoaDon_ChiTiet/BangHoaDon',
                                    type: "GET",
                                    contentType: 'application/json; charset=utf-8',
                                    dataType: 'json',
                                    async: false,
                                    success: function (data) {

                                        if (data !== null) {

                                            $scope.NgBangHoaDon = data;
                                            $scope.$apply();


                                        }
                                        else
                                            alert('ss')
                                    }

                                });

                            }

                        });
                    }, 400);
                });
            }
            else {
                var hd1 = $scope.item.ID_hoa_don;
                swal("Thất bại", "Bạn đã hủy cập nhật hóa đơn" + " " + hd1 + "!", "error");
            }
        });
    }

    // cập nhất  sản phẩm gọi đến angular khách hàng + hàm validate 
    $scope.CapNhatHD = function () {
        $("#diachi").validate({
            rules: {
                giaohang: {
                    required: true,

                },



            },
            messages: {

                giaohang: {
                    required: "Vui lòng điền địa chỉ giao hàng",

                },






            },
            submitHandler: function (form) {

                $scope.Capnhatspnoval();

            }
        })
    }








    //lay danh muc nhan vien 
    $.ajax({
        url: 'api/HoaDon_ChiTiet/DanhMucNhanVien',
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data !== null) {
                $scope.DanhMucNhanVienn = data;
                //document.getElementById("TongSo").innerHTML = "<b>Total Customer : </b>" + $scope.BangHoangHoa.length;
            }
            else
                document.write("Rỗng");
        }
    });

    //lay danh muc phuong thuc

    $.ajax({
        url: 'api/HoaDon_ChiTiet/DanhMucPhuongThuc',
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data !== null) {
                $scope.DanhMucPhuongThucc = data;
                //document.getElementById("TongSo").innerHTML = "<b>Total Customer : </b>" + $scope.BangHoangHoa.length;
            }
            else
                document.write("Rỗng");
        }
    });

    //lay danh muc trang thai

    $.ajax({
        url: 'api/HoaDon_ChiTiet/DanhMucTrangThai',
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data !== null) {
                $scope.DanhMucTrangThaii = data;
                //document.getElementById("TongSo").innerHTML = "<b>Total Customer : </b>" + $scope.BangHoangHoa.length;
            }
            else
                document.write("Rỗng");
        }
    });

    // lay danh muc khach hang

    $.ajax({
        url: 'api/HoaDon_ChiTiet/DanhMucKhachHang',
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data !== null) {
                $scope.DanhMucKhachHangg = data;
                //document.getElementById("TongSo").innerHTML = "<b>Total Customer : </b>" + $scope.BangHoangHoa.length;
            }
            else
                document.write("Rỗng");
        }
    });

    // lay danh muc mat hang 

    $.ajax({
        url: 'api/HoaDon_ChiTiet/DanhMucMatHang',
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data !== null) {
                $scope.DanhMucMatHangg = data;
                //document.getElementById("TongSo").innerHTML = "<b>Total Customer : </b>" + $scope.BangHoangHoa.length;
            }
            else
                document.write("Rỗng");
        }
    });

    //lay anh cho trang thai -- phan in hoa don
    function LayINHD() {
        var responsive;
        LayCTHD();
        $.ajax({
            url: 'api/HoaDon_ChiTiet/BangHoaDon',
            type: "GET",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            async: false,
            success: function (data) {
                if (data !== null) {
                    $scope.NgBangHoaDon = data;
                    var xxxx = $scope.item.ID_phuong_thuc;
                    if (xxxx == 5) {
                        var x = document.getElementById("img2");
                        x.style.display = "block";
                        var x = document.getElementById("img1");
                        x.style.display = "none";
                        var x = document.getElementById("img3");
                        x.style.display = "none";
                        var x = document.getElementById("img4");
                        x.style.display = "none";
                        var x = document.getElementById("img5");
                        x.style.display = "none";
                    }
                    if (xxxx == 4) {
                        var x = document.getElementById("img1");
                        x.style.display = "block";
                        var x = document.getElementById("img2");
                        x.style.display = "none";
                        var x = document.getElementById("img3");
                        x.style.display = "none";
                        var x = document.getElementById("img4");
                        x.style.display = "none";
                        var x = document.getElementById("img5");
                        x.style.display = "none";
                    }
                    if (xxxx == 3) {
                        var x = document.getElementById("img3");
                        x.style.display = "block";
                        var x = document.getElementById("img1");
                        x.style.display = "none";
                        var x = document.getElementById("img2");
                        x.style.display = "none";
                        var x = document.getElementById("img4");
                        x.style.display = "none";
                        var x = document.getElementById("img5");
                        x.style.display = "none";
                    }
                    if (xxxx == 2) {
                        var x = document.getElementById("img4");
                        x.style.display = "block";
                        var x = document.getElementById("img1");
                        x.style.display = "none";
                        var x = document.getElementById("img3");
                        x.style.display = "none";
                        var x = document.getElementById("img2");
                        x.style.display = "none";
                        var x = document.getElementById("img5");
                        x.style.display = "none";
                    }
                    if (xxxx == 1) {
                        var x = document.getElementById("img5");
                        x.style.display = "block";
                        var x = document.getElementById("img1");
                        x.style.display = "none";
                        var x = document.getElementById("img3");
                        x.style.display = "none";
                        var x = document.getElementById("img4");
                        x.style.display = "none";
                        var x = document.getElementById("img2");
                        x.style.display = "none";
                    }

                }
                else {
                    document.write("Rỗng");
                }

            }
        });
        return responsive;
    }




    // Lấy thông tin hóa đơn
    $scope.LayThongTinHoaDon = function (item) {
        $scope.item = {}
        angular.copy(item, $scope.item)
        LayCTHD();
        LayTKTotal();
        LayINHD();

    }

    //<----------Hết Xử lý phần hóa đơn ------------>

    //<----------Xử lý phần chi tiết hóa đơn + sweet ------------>
    // tao moi chi tiet hoa don





    // tao moi sản phẩm  chua sử dụng validate
    $scope.Taomoispnoval = function () {
        var hd3 = $scope.item.ID_hoa_don;
        swal({
            title: "Bạn chắc chứ?",
            text: "Bạn muốn tạo thêm mới sản phẩm cho hóa đơn" + " " + hd3 + "?!",
            icon: "info",
            buttons: true,
            dangerMode: true,
        }).then((willCreateNew) => {
            var hd3 = $scope.item.ID_hoa_don;
            if (willCreateNew) {
                swal("Thành công!", "Bạn đã tạo thêm mới sản phẩm thành công" + " " + hd3 + "!", {
                    icon: "success",
                    timer: 2500,
                }).then(function () {
                    setTimeout(function () {
                        $('.modal_con_tao_moi_chi_tiet').modal('hide'); // close modal 
                        $scope.taomoichitiethoadon.ID_hoa_don = $scope.item.ID_hoa_don; // call ajax function
                        $.ajax({
                            url: "api/HoaDon_ChiTiet/TaoMoiChiTietHoaDon",
                            type: "post",
                            dataType: "text",
                            data: $scope.taomoichitiethoadon,
                            success: function (result) {
                                // load lại bảng chi tiết hóa đơn
                                $.ajax({
                                    url: "api/HoaDon_ChiTiet/BangChiTietHoaDon",
                                    type: "post",
                                    data: value = { "ID_hoa_don": $scope.item.ID_hoa_don },
                                    dataType: 'json',
                                    async: false,
                                    success: function (data) {
                                        if (data != null) {
                                            $scope.NgBangChiTiet = data;
                                            $scope.$apply();

                                        } else
                                            alert('ss')
                                    }
                                });
                                // load lại bảng thống kê
                                $.ajax({
                                    url: "api/HoaDon_ChiTiet/ThongKeTotalChiTietHoaDon",
                                    type: "post",
                                    data: value = { "ID_hoa_don": $scope.item.ID_hoa_don },
                                    dataType: 'json',
                                    async: false,
                                    success: function (data) {
                                        if (data != null) {
                                            $scope.NgBangThongKeTotal = data;
                                            $scope.$apply();
                                            //console.log($scope.BangThongKeTotal)
                                        } else
                                            alert('ss')
                                    }
                                });
                            },
                            error: function () {
                                alert('Error occurs!');
                            }
                        });
                    }, 400);
                });
            }
            else {
                var hd3 = $scope.item.ID_hoa_don;
                swal("Thất bại", "Bạn đã hủy tạo mới sản phẩm" + " " + hd3 + "!", "error");
            }
        });
    }

    // tạo mới sản phẩm gọi đến angular khách hàng + hàm validate 
    $scope.TaoMoiCTHD = function () {
        $("#myform-update").validate({
            rules: {
                sanpham: {
                    required: true,

                },
                soluong: {
                    required: true,


                },


            },
            messages: {

                sanpham: {
                    required: "Bạn hãy chọn sản phẩm",

                },
                soluong: {
                    required: "Vui lòng điền số lượng sản phẩm",

                },





            },
            submitHandler: function (form) {

                $scope.Taomoispnoval();

            }
        })
    }







    // câp nhật chi tiết hóa đơn
    $scope.CapNhatCTHD = function () {
        var hd4 = $scope.item.ID_hoa_don;
        swal({
            title: "Bạn chắc chứ?",
            text: "Bạn muốn cập nhật chi tiêt hóa đơn " + " " + hd4 + "?!",
            icon: "info",
            buttons: true,
            dangerMode: true,
        }).then((willCreateNew) => {
            var hd4 = $scope.item.ID_hoa_don;
            if (willCreateNew) {
                swal("Thành công!", "Bạn đã cập nhật thành công chi tiết hóa đơn" + " " + hd4 + "?!", {
                    icon: "success",
                    timer: 2500,
                }).then(function () {
                    setTimeout(function () {
                        $('.modal_con_sua_chi_tiet').modal('hide'); // close modal 
                        $.ajax({
                            url: "api/HoaDon_ChiTiet/CapNhatChiTiet/",
                            type: "post",
                            dataType: "text",
                            data: $scope.item_chitiet,
                            success: function (result) {
                                // load lại bảng chi tiết hóa đơn
                                $.ajax({
                                    url: "api/HoaDon_ChiTiet/BangChiTietHoaDon",
                                    type: "post",
                                    data: value = { "ID_hoa_don": $scope.item.ID_hoa_don },
                                    dataType: 'json',
                                    async: false,
                                    success: function (data) {
                                        if (data != null) {
                                            $scope.NgBangChiTiet = data;
                                            $scope.$apply();

                                        } else
                                            alert('ss')
                                    }
                                });
                                // load lại bảng thống kê
                                $.ajax({
                                    url: "api/HoaDon_ChiTiet/ThongKeTotalChiTietHoaDon",
                                    type: "post",
                                    data: value = { "ID_hoa_don": $scope.item.ID_hoa_don },
                                    dataType: 'json',
                                    async: false,
                                    success: function (data) {
                                        if (data != null) {
                                            $scope.NgBangThongKeTotal = data;
                                            $scope.$apply();
                                            //console.log($scope.BangThongKeTotal)
                                        } else
                                            alert('ss')
                                    }
                                });
                                console.log("hihi")
                            }
                        });
                    }, 400);
                });
            }
            else {
                var hd4 = $scope.item.ID_hoa_don;
                swal("Thất bại", "Bạn đã hủy cập nhật chi tiết hóa đơn" + " " + hd4 + "!", "error");
            }
        });
    }

    // xóa chitiethoadon
    $scope.XoaChiTietHoaDon = function (item) {
        var hd5 = $scope.item.ID_hoa_don;
        swal({
            title: "Bạn chắc chứ?",
            text: "Bạn muốn xóa sản phẩm trong mã hóa đơn" + " " + hd5 + "?!",
            icon: "info",
            buttons: true,
            dangerMode: true,
        }).then((willCreateNew) => {
            var hd5 = $scope.item.ID_hoa_don;
            if (willCreateNew) {
                swal("Thành công!", "Bạn đã xóa thành công hóa đơn" + " " + hd5 + "!", {
                    icon: "success",
                    timer: 2500,
                }).then(function () {
                    setTimeout(function () {
                        $.ajax({
                            url: "api/HoaDon_ChiTiet/XoaChiTietHoaDon",
                            type: "delete",
                            dataType: "text",
                            data: item,
                            success: function (result) {
                                // load lại bảng chi tiết hóa đơn
                                $.ajax({
                                    url: "api/HoaDon_ChiTiet/BangChiTietHoaDon",
                                    type: "post",
                                    data: value = { "ID_hoa_don": $scope.item.ID_hoa_don },
                                    dataType: 'json',
                                    async: false,
                                    success: function (data) {
                                        if (data != null) {
                                            $scope.NgBangChiTiet = data;
                                            $scope.$apply();
                                        } else
                                            alert('ss')
                                    }
                                });
                                // load lại bảng thống kê
                                $.ajax({
                                    url: "api/HoaDon_ChiTiet/ThongKeTotalChiTietHoaDon",
                                    type: "post",
                                    data: value = { "ID_hoa_don": $scope.item.ID_hoa_don },
                                    dataType: 'json',
                                    async: false,
                                    success: function (data) {
                                        if (data != null) {
                                            $scope.NgBangThongKeTotal = data;
                                            $scope.$apply();
                                            //console.log($scope.BangThongKeTotal)
                                        } else
                                            alert('ss')
                                    }
                                });
                            }
                        });
                    }, 0);
                });
            }
            else {
                var hd5 = $scope.item.ID_hoa_don;
                swal("Thất bại", "Bạn đã hủy xóa hóa đơn" + " " + hd5 + "!", "error");
            }
        });
    }

    // lấy chi tiết hóa đơn
    function LayCTHD() {
        var responsive;
        $.ajax({
            url: "api/HoaDon_ChiTiet/BangChiTietHoaDon",
            type: "post",
            data: value = { "ID_hoa_don": $scope.item.ID_hoa_don },
            dataType: 'json',
            async: false,
            success: function (data) {
                if (data != null) {
                    $scope.NgBangChiTiet = data;
                }
            },
            error: function (data) {
                alert('error connectings server' + data);
            }
        });
        return responsive;
    }

    // lấy thống kê total
    function LayTKTotal() {
        var responsive;
        $.ajax({
            url: "api/HoaDon_ChiTiet/ThongKeTotalChiTietHoaDon",
            type: "post",
            data: value = { "ID_hoa_don": $scope.item.ID_hoa_don },
            dataType: 'json',
            async: false,
            success: function (data) {
                if (data != null) {
                    $scope.NgBangThongKeTotal = data;
                    //console.log($scope.BangThongKeTotal)
                }
            },
            error: function (data) {
                alert('error connectings server' + data);
            }
        });
        return responsive;
    }

    // lấy thông tin chi tiết
    $scope.LayThongTinChiTiet = function (item_chitiet) {
        $scope.item_chitiet = {}
        angular.copy(item_chitiet, $scope.item_chitiet);
    }
    //<----------Hết Xử lý phần chi tiết hóa đơn ------------>


});