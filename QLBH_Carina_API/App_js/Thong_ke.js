
app.controller('mycontroller', ['$scope', function ($scope) {

    // lay thong tin home
    $.ajax({
        url: 'api/ThongKe/BangThongKe',
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data !== null) {
                console.log(data);
                $scope.BangThongKee = data;
                //document.getElementById("TongSo").innerHTML = "<b>Total Customer : </b>" + $scope.BangHoangHoa.length;
            }
            else
                document.write("Rỗng");
        }
    });

    // lay thong tin top phuong thuc
    $.ajax({
        url: 'api/ThongKe/BangTopPhuongThuc',
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data !== null) {
                console.log(data);
                $scope.BangPhuongThucc = data;
                //document.getElementById("TongSo").innerHTML = "<b>Total Customer : </b>" + $scope.BangHoangHoa.length;
            }
            else
                document.write("Rỗng");
        }
    });


    // lay thong tin hoa don thanh toan gan day
    $.ajax({
        url: 'api/ThongKe/BangThanhToanGan',
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data !== null) {
                console.log(data);
                $scope.BangHoaDonThanhToanGanDay = data;
                //document.getElementById("TongSo").innerHTML = "<b>Total Customer : </b>" + $scope.BangHoangHoa.length;
            }
            else
                document.write("Rỗng");
        }
    });

    // lay thong tin tinh phan tram tang truong
    $.ajax({
        url: 'api/ThongKe/Thongkephantram',
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data !== null) {
                console.log(data);
                $scope.Thongkephantramm = data;
                //document.getElementById("TongSo").innerHTML = "<b>Total Customer : </b>" + $scope.BangHoangHoa.length;
            }
            else
                document.write("Rỗng");
        }
    });
}]);