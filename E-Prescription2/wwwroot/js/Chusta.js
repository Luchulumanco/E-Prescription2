$(document).ready(function () {
    GetProvince();
});

function GetProvince() {
    $.ajax({
        url: '/Cascade/Province',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#Province').append('<Option value=' + data.id + '>' + data.name + '</Option>');
            });
        }
    });
}