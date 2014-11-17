
$(document).ready(function () {
    $('#MaterialID').attr('disabled', 'disabled');
    var warrenty=$('#WarrentyHidden').val();
    $('#Warrenty').val(warrenty);

    $('#MaterialNew input[type=text]').val('');
});

function EditFunction(a) {

  window.location.replace("/Material/EditMaterial?MaterialID="+a.id);

}

function DeleteFuction(a) {    
    $.ajax({
        url: '/Material/DeleteMaterial?MaterialID=' + a.id,
        type: 'post',
        datatype: 'json',
        success: function (data) {

            if (data.obj == 'success') {
                window.location.replace('/Material/MaterialGrid');
            }
        },
        error: function (e) {            
        },
        async: false
    });

}

function NewUser() {
    window.location.replace("/Material/Material");
}

