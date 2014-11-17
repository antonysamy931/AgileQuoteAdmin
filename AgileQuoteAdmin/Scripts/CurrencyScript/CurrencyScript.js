var notyAlert = null;

$(document).ready(function () {

    //$('#CurrencyCode').val('');
    $('#CurrencyPopUp_close').click(function () {
        $('#CurrencyPopUp').fadeOut(300);
        $('#mask').fadeOut(300);
    });

    $('#CurrencyPopUp_close_Create').click(function () {
        $('#CurrencyPopUp_Create').fadeOut(300);
        $('#mask').fadeOut(300);
    });

    $("#UpdateCurrency").click(function () {

        var CurrencyId = $("#CurrencyId").val();
        var CurrencyCode = $("#CurrencyCode").val();
        var CurrencyName = $("#CurrencyName").val();
        var Amount = $("#Amount").val();
        var IsActive = false;
        var IsDelete = false;

        if ($('#IsActive').prop('checked') === true) {
            IsActive = true;
        }

        if ($('#IsDelete').prop('checked') === true) {
            IsDelete = true;
        }

        if (CurrencyCode === "") {
            $("#errorMsg").text("*");
        }
        else if (CurrencyName === "") {
            $("#errorMsg1").text("*");
        }
        else if (Amount === "") {
            $("#errorMsg2").text("*");
        }
        else {
            $.ajax({
                url: '/Currency/UpdateCurrencyRecord?CurrencyId=' + CurrencyId + '&CurrencyCode=' + CurrencyCode + '&CurrencyName=' + CurrencyName + '&Amount=' + Amount + '&IsActive=' + IsActive + '&IsDelete=' + IsDelete,
                datatype: 'json',
                type: 'post',
                success: function (result) {

                    if (result.Result == "Success") {

                        window.location.replace("/Currency/PartialCurrency");
                    }
                    else {
                        $.noty.closeAll();
                        notyAlert = noty({
                            text: "Failed - " + result.Result,
                            type: 'error',
                            buttons: [{
                                addClass: 'btn btn-primary', text: 'OK', onClick: function ($noty) {
                                    $noty.close();
                                }
                            }]
                        });
                    }
                },
                error: function () {
                },
                async: false
            });
        }
    });
    $('#CreateCurrency').click(function () {
        var CurrencyCode = $('#CurrencyCode_Create').val();
        var CurrencyName = $('#CurrencyName_Create').val();
        var Amount = $('#Amount_Create').val();
        if (CurrencyCode !== '' && CurrencyName !== '' && Amount !== '') {
            if (/^[0-9]+$/.test(Amount)) {
                $('#errorMsg_Create').text('');
                $('#errorMsg1_Create').text('');
                $('#errorMsg2_Create').text('');
                $.ajax({
                    url: '/Currency/CreateCurrency?CurrencyCode=' + CurrencyCode + '&CurrencyName=' + CurrencyName + '&Amount=' + Amount,
                    type: 'post',
                    dataType: 'json',
                    success: function (result) {
                        if (result.Redirect) {
                            window.location.replace(result.RedirectAction);
                        }
                        else {
                            if (result.Result === 'Success') {
                                window.location.replace('/Currency/PartialCurrency');
                            }
                            else {
                                $('#errorMsg2_Create').text(result.Result);
                            }
                        }
                    },
                    error: function (e) {
                    },
                    async: false
                });
            }
            else {
                $('#errorMsg_Create').text('');
                $('#errorMsg1_Create').text('');
                $('#errorMsg2_Create').text('Please enter valid amount');
            }
        }
        else {
            if (CurrencyCode === '') {
                $('#errorMsg_Create').text('Please enter currency code.');
            }
            else {
                $('#errorMsg_Create').text('');
            }

            if (CurrencyName === '') {
                $('#errorMsg1_Create').text('Please enter currenty name');
            }
            else {
                $('#errorMsg1_Create').text('');
            }

            if (Amount === '') {
                $('#errorMsg2_Create').text('Please enter amount');
            }
            else {
                if (/^[0-9]+$/.test(Amount)) {
                    $('#errorMsg2_Create').text('');
                }
                else {
                    $('#errorMsg2_Create').text('Please enter valid amount');
                }
            }
        }
    });
});

function EditFunction(data) {
    $.ajax({

        url: '/Currency/EditCurrencyRecord?CurrencyId=' + data.id,
        datatype: 'json',
        type: 'post',
        success: function (result) {
            var CurrencyId = null;
            var CurrencyCode = null;
            var CurrencyName = null;
            var Amount = null;
            var IsActive = null;
            var IsDelete = null;
            $("#CurrencyId").val(result.oCurrencyProperty.CurrencyId);
            $("#CurrencyCode").val(result.oCurrencyProperty.CurrencyCode);
            $("#CurrencyName").val(result.oCurrencyProperty.CurrencyName);
            $("#Amount").val(result.oCurrencyProperty.Amount);
            if (result.oCurrencyProperty.IsActive == true) {
                $("#IsActive").attr('checked', 'checked');
            }
            else {
                $("#IsActive").removeAttr('checked');
            }
            if (result.oCurrencyProperty.IsDelete == true) {
                $("#IsDelete").attr('checked', 'checked');
            }
            else {
                $("#IsDelete").removeAttr('checked');
            }

        },
        error: function () {
        },
        async: false
    });
    var popMargTop = ($('#CurrencyPopUp').height() + 24) / 2;
    var popMargLeft = ($('#CurrencyPopUp').width() + 24) / 2;

    $('#CurrencyPopUp').css({
        'margin-top': -popMargTop,
        'margin-left': -popMargLeft
    });

    // Add the mask to body
    $('body').append('<div id="mask"></div>');
    $('#mask').fadeIn(300);

    //Fade in the Popup
    $('#CurrencyPopUp').fadeIn(300);

    //window.location.replace('/Currency/EditCurrency?CurrencyId=' +data.id );

}


function DeleteFunction(data) {
    $.ajax({
        url: '/Currency/DeleteCurrency?CurrencyId=' + data.id,
        type: 'post',
        datatype: 'json',
        success: function (data) {
            if (data.Result == "Success") {

                window.location.replace("/Currency/PartialCurrency");
            }
        },
        error: function (e) {
        },
        aysnc: false
    });
}

function NewUser() {

    var popMargTop = ($('#CurrencyPopUp_Create').height() + 24) / 2;
    var popMargLeft = ($('#CurrencyPopUp_Create').width() + 24) / 2;

    $('#CurrencyPopUp_Create').css({
        'margin-top': -popMargTop,
        'margin-left': -popMargLeft
    });

    // Add the mask to body
    $('body').append('<div id="mask"></div>');
    $('#mask').fadeIn(300);

    //Fade in the Popup
    $('#CurrencyPopUp_Create').fadeIn(300);

    //window.location.replace("/Currency/Currency");
}