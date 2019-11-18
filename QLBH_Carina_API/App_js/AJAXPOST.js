function AJAXPOST(url, data) {
    var responsive;
    $.ajax({
        url: url,
        type: "Post",
        data: data,
        dataType: 'json',
        async: false,
        success: function (data) {
            responsive = data;
        },
        error: function (data) {
            alert('error connectings server' + data);
        }
    });
    return responsive;
}