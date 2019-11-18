app.controller('mycontroller', function ($scope) {

    $.ajax({
        url: '/QLBH_Carina_API/Table_nhan_vien/Bangnhanvien',
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data !== null) {
                $scope.BangNhanVien = data;
                //document.getElementById("TongSo").innerHTML = "<b>Total Customer : </b>" + $scope.BangHoangHoa.length;
            }
            else
                document.write("Rỗng");
        }
    });
});