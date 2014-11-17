var notyAlert = null;

$(document).ready(function () {

    $('#CurrencyCode').val('');

    $('#CurrencyPopUp_close').click(function () {
        $('#CurrencyPopUp').fadeOut(300);
        $('#mask').fadeOut(300);
    });

    $('#CurrencyPopUp_close_Create').click(function () {
        $('#CurrencyPopUp_Create').fadeOut(300);
        $('#mask').fadeOut(300);
    });


    $("#UpdateSales").click(function () {

        var SalesOrgCode = $("#SalesOrgCode").val();
        var SalesOrgName = $("#SalesOrgName").val();
        var ReferenceCustomerCode = $("#ReferenceCustomerCode").val();
        var IsActive = true;

        if ($("#IsActive").prop('checked') === false) {
            IsActive = false;
        }

        var IsDelete = false;

        if ($("#IsDelete").prop('checked') === true) {
            IsDelete = true;
        }

        if (SalesOrgName === "") {
            $("#errorMsg").text("*");
        }
        else if (ReferenceCustomerCode === "") {
            $("#errorMsg1").text("*");
        }
        else {
            $.ajax({

                url: '/SalesOrganization/UpdateSalesRecord?SalesOrgCode=' + SalesOrgCode + '&SalesOrgName=' + SalesOrgName + '&ReferenceCustomerCode=' + ReferenceCustomerCode + '&IsActive=' + IsActive + '&IsDelete=' + IsDelete,
                type: 'post',
                datatype: 'json',
                success: function (result) {
                    if (result.Result == "Success") {

                        window.location.replace("/SalesOrganization/SalesOrganizationPartial");
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
                error: function () {
                },
                async: false
            });
        }
    });

    $('#InsertSales').click(function () {
        var SalesName = $('#SalesOrgName_Create').val();
        var CustomerReferenceCode = $('#ReferenceCustomerCode_Create').val();

        if (SalesName !== '' && CustomerReferenceCode !== '') {
            $('#errorMsg_Create').text('');
            $('#errorMsg1_Create').text('');

            $.ajax({
                url: '/SalesOrganization/CreateSalesOrganization?SalesName=' + SalesName + '&ReferenceCode=' + CustomerReferenceCode,
                type: 'post',
                dataType: 'json',
                success: function (result) {
                    if (result.Redirect) {
                        window.location.replace(result.RedirectAction);
                    }
                    else {
                        if (result.Result === 'Success') {
                            window.location.replace('/SalesOrganization/SalesOrganizationPartial');
                        }
                        else {
                            $('#errorMsg1_Create').text(result.Result);
                        }
                    }
                },
                error: function (e) {
                },
                async: false
            });            
        }
        else {
            if (SalesName !== '') {
                $('#errorMsg_Create').text('');
            }
            else {
                $('#errorMsg_Create').text('Please enter sales name');
            }

            if (CustomerReferenceCode !== '') {
                $('#errorMsg1_Create').text('');
            }
            else {
                $('#errorMsg1_Create').text('Please enter customer reference code');
            }
        }
    });

});
function SelectRow(e) {
    $.noty.closeAll();
    notyAlert = noty({
        text: e.id,
        type: 'error',
        buttons: [{
            addClass: 'btn btn-primary', text: 'OK', onClick: function ($noty) {
                $noty.close();
            }
        }]
    });    
}

function EditFunction(Data) {

    $.ajax({
        url: '/SalesOrganization/EditSalesRecord?SalesOrgCode=' + Data.id,
        type: 'post',
        datatype: 'json',
        success: function (result) {
            var SalesOrgCode = null;
            var SalesOrgName = null;
            var ReferenceCustomerCode = null;
            var IsActive = null;
            var IsDelete = null;
            $("#SalesOrgCode").val(result.oSalesProperty.SalesOrgCode);
            $("#SalesOrgName").val(result.oSalesProperty.SalesOrgName);
            $("#ReferenceCustomerCode").val(result.oSalesProperty.ReferenceCustomerCode);
            if (result.oSalesProperty.IsActive == true) {
                $("#IsActive").attr('checked', 'checked');
            }
            else {
                $("#IsActive").removeAttr('checked');
            }
            if (result.oSalesProperty.IsDelete == true) {
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

}

function DeleteFunction(Data) {

    $.ajax({
        url: '/SalesOrganization/DeleteRecord?SalesOrgCode=' + Data.id,
        type: 'post',
        datatype: 'json',
        success: function (data) {            
            if (data.result == 'Success') {
                window.location.replace('/SalesOrganization/SalesOrganizationPartial');
            }
        },
        error: function (e) {
        },
        async: false
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

    //window.location.replace("/SalesOrganization/SalesOrganization");
}
