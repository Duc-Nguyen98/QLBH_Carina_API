AJAXGET = function (Url, data) {
    var Data;
    $.ajax({
        url: Url,
        type: "GET",
        data: data,
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {
            Data = data.Data;
        }
    });
    return Data;
};