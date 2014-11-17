$(document).ready(function () {

    $('#CurrencyCode').val('');
    $('#CurrencyPopUp_close').click(function () {
        $('#CurrencyPopUp').fadeOut(300);
        $('#mask').fadeOut(300);
    });

    $("#UpdateCompany").click(function () {

        var CompanyCode = $("#CompanyCode").val();
        var CompanyName = $("#CompanyName").val();
        var IsActive = true;
        if ($("#IsActive").prop('checked') === false) {
            IsActive = false;
        }

        var IsDelete = false;

        if ($("#IsDelete").prop('checked') === true) {
            IsDelete = true;
        }

        if (CompanyName === "") {
            $("#errorMsg").text("*");
        }
        
        else if (CompanyName !== "") {
            $.ajax({
                url: '/Company/UpdateCompany?CompanyCode=' + CompanyCode + '&CompanyName=' + CompanyName + '&IsActive=' + IsActive + '&IsDelete=' + IsDelete,
                type: 'post',
                datatype: 'json',
                success: function (result) {
                    if (result.Result == "Success") {
                        window.location.replace("/Company/PartialCompany");
                    }
                    else {
                        alert("Failed");
                    }
                },
                error: function () {
                },
                async: false
            });
        }
    });

    $('#CompanyPopUp_close').click(function () {
        $('#CompanyPopUp').fadeOut(300);
        $('#mask').fadeOut(300);
    });

    $('#InsertCompany').click(function () {
        var companyName = $('#CompanyName_Create').val();
        if (companyName !== '') {
            $('#errorMsg_create').text('');
            $.ajax({
                url: '/Company/CreateCompany?CompanyName=' + companyName,
                type: 'post',
                dataType: 'json',
                success: function (result) {
                    if (result.Redirect) {
                        window.location.replace(result.RedirectAction);
                    }
                    else {
                        if (result.Result === 'Success') {
                            window.location.replace('/Company/PartialCompany');
                        }
                        else {
                            $('#errorMsg_create').text(result.Result);                            
                        }
                    }
                },
                error: function (e) {
                },
                async:false
            });
        }
        else {
            $('#errorMsg_create').text('Please enter company name.');
        }
    });
});

function RowSelect(e) {
    alert(e.value);
}


function EditFunction(data) {
    $.ajax({
        url: '/Company/EditCompany?CompanyCode=' + data.id,
        type: 'post',
        datatype: 'json',
        success: function (result) {
            var CompanyCode = null;
            var CompanyName = null;
            var IsActive = null;
            var IsDelete = null;
            $("#CompanyCode").val(result.oCompanyProperty.CompanyCode);
            $("#CompanyName").val(result.oCompanyProperty.CompanyName);
            $("#IsActive").val(result.oCompanyProperty.IsActive);
            $("#IsDelete").val(result.oCompanyProperty.IsDelete);

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

function DeleteFunction(data) {
    $.ajax({
        url: '/Company/DeleteCompany?CompanyCode=' + data.id,
        type: 'post',
        datatype: 'json',
        success: function (data) {
            if (data.Result == "Success") {
                window.location.replace("/Company/PartialCompany");
            }
            else {
                alert("Failed");
            }
        },
        error: function () {
        },
        async: false
    });
}

function NewUser() {

    var popMargTop = ($('#CompanyPopUp').height() + 24) / 2;
    var popMargLeft = ($('#CompanyPopUp').width() + 24) / 2;

    $('#CompanyPopUp').css({
        'margin-top': -popMargTop,
        'margin-left': -popMargLeft
    });

    // Add the mask to body
    $('body').append('<div id="mask"></div>');
    $('#mask').fadeIn(300);

    //Fade in the Popup
    $('#CompanyPopUp').fadeIn(300);

    //window.location.replace("/Company/Company");
}