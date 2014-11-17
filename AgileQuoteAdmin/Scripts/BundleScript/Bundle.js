
$(document).ready(function () {   
    var input = 0;
    var catagory = null;
    $(':checkbox').change(function () {
        if ($(this).is(':checked')) {
            ++input;
            catagory = $(this).parents('div').prev().text();
            catagory = catagory.split(' ')[0];
        }
        else {
            --input;
        }


        if (input === 0) {
            $('input').parents('div').prev().siblings('h3').show();
        }
        else {
            $('input').parents('div').prev().siblings('h3').hide();
        }
        //$(this).parents('div').find('.MaterialCheckClass').css('background-color', 'red');
    });


    var queryArr;
    $("#AddBundle").click(function () {
        var popMargTop = ($('.light-popup').height() + 24) / 2;
        var popMargLeft = ($('.light-popup').width() + 24) / 2;

        $('.light-popup').css({
            'margin-top': -popMargTop,
            'margin-left': -popMargLeft
        });

        // Add the mask to body
        $('body').append('<div id="mask"></div>');
        $('#mask').fadeIn(300);

        //Fade in the Popup
        $('.light-popup').fadeIn(300);

    });
    $("#UpdateBundle").click(function () {
        $('.light-popup').fadeOut(300);
        var x = [];
        var BundleID = $("#BundleID").val();
        var BundleName = $("#BundleName").val();
        var BundleType = $("#BundleType").val();
        var UnitPrice = $("#UnitPrice").val();
        var Discount = $("#Discount").val();
        var Catagory = $("#BundleCatagory").val();

        $(".grid > tbody  > tr > td> input:checked").each(function () {
            x.push($(this).val());
        });

        $.ajax({
            url: '/Bundle/BundleUpdate?BundleID=' + BundleID + '&BundleName=' + BundleName + '&BundleType=' + BundleType + '&BundleCatagory=' + Catagory + '&UnitPrice=' + UnitPrice + '&Discount=' + Discount + '&MaterialIDList=' + x,
            type: 'post',
            datatype: 'json',
            success: function (msg) {
                input = 0;
                if (msg.result == 'Success') {

                    window.location.replace('/Bundle/BundleUpdateEdit?BundleID=' + msg.ID + "&Catagory=" + msg.Catagory);
                }
                else
                    alert("failed");
            },
            error: function (e) {
                alert(e);
            },
            async: false
        });

    });


    $('#MaterialID').attr('disabled', 'disabled');
    $("#BundleCreate").click(function () {
        window.location.replace("/Bundle/Bundle");
    });

    

    $("#CreateBundle").click(function () {
        alert("hai");
        var x = [];
        var name = $("#BundleName").val();
        $(".grid > tbody  > tr > td> input:checked").each(function () {
            x.push($(this).val());
        });

        $.ajax({
            url: '/Bundle/Bundle?BundleName=' + name + '&MaterialIDList=' + x + '&Catagory=' + catagory,
            type: 'post',
            datatype: 'json',
            success: function (data) {
                input = 0;
                //       alert(data.obj);
                if (data.obj == 'success') {
                    window.location.replace('/Bundle/bundleupdate');
                }
                else
                    alert("failed");
            },
            error: function (e) {
                alert(e);
            },
            async: false
        });

    });






});

function RowSelect(a) {
  
  
}

function EditFunction(a) {
    var str = a.id;
    var n = str.split(" ");

    window.location.replace("/Bundle/BundleUpdateEdit?BundleID=" + n[0] + "&Catagory="+n[1]);    
}


function DeleteFuction(a) {
    alert("hai");
    $.ajax({
        url: '/Bundle/BundleUpdate?BundleID=' + a.id,
        type: 'post',
        datatype: 'json',
        success: function (data) {

            if (data.obj == 'success') {
                window.location.replace('/Bundle/BundleUpdate');
            }
        },
        error: function (e) {
            alert(e);
        },
        async: false
    });
      
}

