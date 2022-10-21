$(document).ready(function () {
    GetProvince();
    $('#City').attr('disabled', true);
    $('#Subuurb').attr('disabled', true);

    $('#Province').change(function () {
        $('#City').attr('disabled', false);
        var cityId = $(this).val();
        $('#City').empty();
        $('#City').append('<Option>---Select City---</Option>');
        $.ajax({
            url: '/Cascade/City?CityId=' + id,
            success: function (result) {
                
                $.each(result, function (i, data) {
                    $('#City').append('<Option value=' + data.id + '>' + data.name + '</Option>');
                });
            }
        })
    })
});

function GetProvince() {
    $.ajax({

       
        url: '/Cascade/Province',
       
        success: function (result) {
            $.each(result, function (data) {
                $('#Province').append('<Option value=' + data.ProvinceId + '>' + data.ProvinceName + '</Option>');
            });
        }
    });
}