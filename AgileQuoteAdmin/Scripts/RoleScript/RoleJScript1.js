var notyAlert = null;

$(document).ready(function () {

    $('#RolePopUp_close').click(function () {
        $('#RolePopUp').fadeOut(300);
        $('#mask').fadeOut(300);
    });

    $('#RolePopUp_close_Create').click(function () {
        $('#RolePopUp_Create').fadeOut(300);
        $('#mask').fadeOut(300);
    });

    $("#RoleID").keydown(function (e) {
        if (e.keyCode == 13) {
            $('#EditButton').focus();
        }
    });
    $("#EditButton").click(function () {

        debugger
        var RoleId = $("#RoleID").val();
        var RoleName = $("#RoleName").val();
        var Priority = $("#Priority").val();
        var IsActive = true;

        if ($("#IsActive").prop('checked') === false) {
            IsActive = false;
        }

        var IsDelete = false;

        if ($('#IsDelete').prop('checked') === true) {
            IsDelete = true;
        }

        if (RoleName === "") {
            $("#ErrorMsg").text('*');

        }
        else if (Priority === "") {
            $("#ErrorMsg1").text('*');
        }

        else if (RoleName !== "" && Priority !== "" && IsActive !== "") {

            $.ajax({
                url: '/Role/RoleUpdate?RoleId=' + RoleId + '&RoleName=' + RoleName + '&Priority=' + Priority + '&IsActive=' + IsActive + '&IsDelete=' + IsDelete,
                type: 'post',
                dataType: 'json',
                success: function (data) {
                    if (data.Eresult == "Success") {
                        window.location.replace("/Role/RoleListPartial");
                    }
                    else {
                        $.noty.closeAll();
                        notyAlert = noty({
                            text: "Failed "+data.Eresult,
                            type: 'error',
                            buttons: [{
                                addClass: 'btn btn-primary', text: 'OK', onClick: function ($noty) {
                                    $noty.close();
                                }
                            }]
                        });                        
                    }
                },
                error: function (e) {
                    $.noty.closeAll();
                    notyAlert = noty({
                        text: e,
                        type: 'error',
                        buttons: [{
                            addClass: 'btn btn-primary', text: 'OK', onClick: function ($noty) {
                                $noty.close();
                            }
                        }]
                    });                    
                },
                async: false
            });
        }
    });

    $('#InsertRole').click(function () {
        var RoleName = $('#RoleName_Create').val();
        var Priority = $('#Priority_Create').val();
        if (RoleName !== '' && Priority !== '') {
            if (/^[0-9]+$/.test(Priority)) {
                $('#ErrorMsg_Create').text('');
                $('#ErrorMsg1_Create').text('');
                $.ajax({
                    url: '/Role/CreateRole?RoleName=' + RoleName + '&Priority=' + Priority,
                    type: 'post',
                    dataType: 'json',
                    success: function (result) {
                        if (result.Redirect) {
                            window.location.replace(result.RedirectAction);
                        }
                        else {
                            if (result.Result === 'Success') {
                                window.location.replace('/Role/RoleListPartial');
                            }
                            else {
                                $('#ErrorMsg1_Create').text(result.Result);
                            }
                        }
                    },
                    error: function (e) {
                    },
                    async: false
                });
            }
            else {
                $('#ErrorMsg_Create').text('');
                $('#ErrorMsg1_Create').text('Enter numeric only');
            }
        }
        else {
            if (RoleName === '') {
                $('#ErrorMsg_Create').text('Please enter role name');
            }
            else {
                $('#ErrorMsg_Create').text('');
            }

            if (Priority === '') {
                $('#ErrorMsg1_Create').text('Please enter priority');
            }
            else {
                if (/^[0-9]+$/.test(Priority)) {
                    $('#ErrorMsg1_Create').text('');
                }
                else {
                    $('#ErrorMsg1_Create').text('Enter numeric only');
                }
            }
        }
    });

});


function RoleIDSelect(e) {
    $.noty.closeAll();
    notyAlert = noty({
        text: e.value,
        type: 'error',
        buttons: [{
            addClass: 'btn btn-primary', text: 'OK', onClick: function ($noty) {
                $noty.close();
            }
        }]
    });
}
function RoleEditFunction(data) {
    $.ajax({
        url: '/Role/RoleEdit?RoleId=' + data.id,
        type: 'post',
        dataType: 'json',
        success: function (result) {
            $('#RoleID').val(result.rProperty.RoleId);
            $('#RoleName').val(result.rProperty.RoleName);
            $('#Priority').val(result.rProperty.Priority);
            $('#IsActive').val(result.rProperty.IsVisible);
            $('#IsDelete').val(result.rProperty.IsDelete);
            if ($(result.rProperty.IsVisible === true)) {
                $("#IsActive").attr('checked', 'checked');
            }
            else {
                $("#IsActive").removeAttr('checked');
            }
        }
    });
    var popMargTop = ($('#RolePopUp').height() + 24) / 2;
    var popMargLeft = ($('#RolePopUp').width() + 24) / 2;

    $('#RolePopUp').css({
        'margin-top': -popMargTop,
        'margin-left': -popMargLeft
    });

    // Add the mask to body
    $('body').append('<div id="mask"></div>');
    $('#mask').fadeIn(300);

    //Fade in the Popup
    $('#RolePopUp').fadeIn(300);

}
function RoleDeleteFunction(data) {
    $.ajax(
   {
       url: '/Role/RoleDelete?RoleID=' + data.id,
       type: 'post',
       datatype: 'json',
       success: function (data) {           
           if (data.dObject == "Success") {
               window.location.replace("/Role/RoleListPartial");
           }
           else {
               $.noty.closeAll();
               notyAlert = noty({
                   text: "Failed",
                   type: 'error',
                   buttons: [{
                       addClass: 'btn btn-primary', text: 'OK', onClick: function ($noty) {
                           $noty.close();
                       }
                   }]
               });               
           }
       },
       error: function (e)
       { },
       async: false
   });
}

function NewUser() {

    var popMargTop = ($('#RolePopUp_Create').height() + 24) / 2;
    var popMargLeft = ($('#RolePopUp_Create').width() + 24) / 2;

    $('#RolePopUp_Create').css({
        'margin-top': -popMargTop,
        'margin-left': -popMargLeft
    });

    // Add the mask to body
    $('body').append('<div id="mask"></div>');
    $('#mask').fadeIn(300);

    //Fade in the Popup
    $('#RolePopUp_Create').fadeIn(300);

    //window.location.replace("/Role/RoleList");
}
