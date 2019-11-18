app.controller('mycontroller', function ($scope) {

    // xem chi tiet hoa don 
    $.ajax({
        url: 'api/HoaDon_ChiTiet/BangChiTietHoaDon',
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data !== null) {
                console.log(data);
                $scope.BangChiTietHoaDonn = data;
                //document.getElementById("TongSo").innerHTML = "<b>Total Customer : </b>" + $scope.BangHoangHoa.length;
            }
            else
                document.write("Rỗng");
        }
    });

});
