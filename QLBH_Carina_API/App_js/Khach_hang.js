app.controller('mycontroller', ['$scope', function ($scope) {

    // xem khach hang 
    $.ajax({
        url: 'api/khachhang/bangkhachhang',
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data !== null) {
                console.log(data);
                $scope.NgBangkhachhang = data;
                //document.getElementById("TongSo").innerHTML = "<b>Total Customer : </b>" + $scope.BangHoangHoa.length;
            }
            else
                document.write("Rỗng");
        }
    });


    // tao moi khach hang  chua sử dụng validate
    $scope.Taomoikhnoval = function () {
        swal({
            title: "Bạn chắc chứ?",
            text: "Bạn muốn tạo mới khách hàng ?!",
            icon: "info",
            buttons: true,
            dangerMode: true,
        }).then((willCreateNew) => {
            if (willCreateNew) {
                swal("Thành công!", "Bạn đã tạo thành công khách hàng .", {
                    icon: "success",
                    timer: 2000,
                }).then(function () {
                    setTimeout(function () {
                        $('.modal_tao_moi_khach_hang').modal('hide'); // close modal 
                        $.ajax({
                            url: "api/khachhang/TaoMoiKhachHang",
                            type: "post",
                            dataType: "text",
                            data: $scope.taomoikhachhang,
                            success: function (result) {
                                // xem khach hang 
                                $.ajax({
                                    url: 'api/khachhang/bangkhachhang',
                                    type: "GET",
                                    contentType: 'application/json; charset=utf-8',
                                    dataType: 'json',
                                    async: false,
                                    success: function (data) {
                                        if (data !== null) {
                                            $scope.NgBangkhachhang = data;
                                            $scope.$apply();
                                        }
                                        else
                                            document.write("Rỗng");
                                    }
                                });
                            }
                        });
                    }, 400);
                });
            }
            else {
                swal("Thất bại", "Bạn đã hủy tạo mới khách hàng.", "error");
            }
        });
    }

   
    //cập nhật khách hàng gọi đến angular khách hàng + hàm validate
    $scope.CapnhatKh = function () {
        $("#personal-edit-info").validate({
            rules: {
                edit_email: {
                    required: true,
                    email: true
                },
                edit_address: {
                    required: true,
                    maxlength: 100,

                },
                edit_phone: {
                    required: true,
                    maxlength: 11,
                    number: true
                }
            },
            messages: {

                edit_email: "nhập định dạng email",

                edit_phone: {
                    required: "Bạn hãy nhập số điện thoại",
                    minlength: "trên 10 ký tự"
                },
                edit_address: {
                    required: "Bạn hãy nhập quê quán",
                    minlength: "Trên 10 ký tự",
                }

            },
            submitHandler: function (form) {
                $scope.CapnhatKhnoval();

            }
        })
    }

    // Cập nhật khách hàng
    $scope.CapnhatKhnoval = function () {

        swal({
            title: "Bạn chắc chứ?",
            text: "Bạn muốn cập nhật khách hàng?!",
            icon: "info",
            buttons: true,
            dangerMode: true,
        }).then((willCreateNew) => {
            if (willCreateNew) {
                swal("Thành công!", "Bạn đã cập nhật thành công khách hàng!", {
                    icon: "success",
                    timer: 2000,
                }).then(function () {
                    setTimeout(function () {
                        $('.modal_edit_khach_hang').modal('hide'); // close modal 
                        $.ajax({
                            url: "api/khachhang/CapNhatKhachHang/",
                            type: "post",
                            dataType: "text",
                            data: $scope.item,
                            success: function (result) {
                                // xem khach hang 
                                $.ajax({
                                    url: 'api/khachhang/bangkhachhang',
                                    type: "GET",
                                    contentType: 'application/json; charset=utf-8',
                                    dataType: 'json',
                                    async: false,
                                    success: function (data) {
                                        if (data !== null) {
                                            $scope.NgBangkhachhang = data;
                                            $scope.$apply();
                                        }
                                        else
                                            document.write("Rỗng");
                                    }
                                });
                            }
                        });
                    }, 400);
                });
            }
            else {
                swal("Thất bại", "Bạn đã hủy thành công cập nhật khách hàng" + " " + ngkh1 + "!", "error");
            }
        });
    }

    // Lấy thông tin khách hàng
    $scope.LayThongTinKhachHang = function (item) {

        $scope.item = {}
        angular.copy(item, $scope.item)
        console.log($scope.item)
    }

    // xóa khách hàng
    $scope.XoaKhachHang = function (item) {
        swal({
            title: "Bạn chắc chứ?",
            text: "Bạn muốn xóa dữ liệu khách hàng?!",
            icon: "info",
            buttons: true,
            dangerMode: true,
        }).then((willCreateNew) => {
            if (willCreateNew) {

                swal("Thành công!", "Bạn đã xóa thành công khách hàng!", {
                    icon: "success",
                    timer: 2000,
                }).then(function () {
                    setTimeout(function () {
                        $.ajax({
                            url: "/api/KhachHang/XoaKhachHang/",
                            type: "delete",
                            dataType: "text",
                            data: item,
                            success: function (result) {
                                // xem khach hang 
                                $.ajax({
                                    url: 'api/khachhang/bangkhachhang',
                                    type: "GET",
                                    contentType: 'application/json; charset=utf-8',
                                    dataType: 'json',
                                    async: false,
                                    success: function (data) {
                                        if (data !== null) {
                                            $scope.NgBangkhachhang = data;
                                            $scope.$apply();
                                        }
                                        else
                                            document.write("Rỗng");
                                    }
                                });
                            }
                        });
                    }, 0);
                });
            }
            else {
                swal("Thất bại", "Bạn đã hủy xóa dữ liệu khách hàng!", "error");
            }
        });
    }

}]);