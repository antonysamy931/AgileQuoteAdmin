
$(document).ready(function () {
    $('#DataTable').dataTable({
        "aaData": [
        /* Reduced data set */
                ["Trident", "Internet Explorer 4.0", "Win 95+", 4, "X"],
                ["Trident", "Internet Explorer 5.0", "Win 95+", 5, "C"],
                ["Trident", "Internet Explorer 5.5", "Win 95+", 5.5, "A"],
                ["Trident", "Internet Explorer 6.0", "Win 98+", 6, "A"],
                ["Trident", "Internet Explorer 7.0", "Win XP SP2+", 7, "A"],
                ["Gecko", "Firefox 1.5", "Win 98+ / OSX.2+", 1.8, "A"],
                ["Gecko", "Firefox 2", "Win 98+ / OSX.2+", 1.8, "A"],
                ["Gecko", "Firefox 3", "Win 2k+ / OSX.3+", 1.9, "A"],
                ["Webkit", "Safari 1.2", "OSX.3", 125.5, "A"],
                ["Webkit", "Safari 1.3", "OSX.3", 312.8, "A"],
                ["Webkit", "Safari 2.0", "OSX.4+", 419.3, "A"],
                ["Webkit", "Safari 3.0", "OSX.4+", 522.1, "A"]
                ],
        "bServerSide": true,
        "sAjaxSource": "/RentalProducts/RentalProductsGrid",
        "bProcessing": true,
        "sPaginationType": "full_numbers",
        //"iDisplayLength": 1,
        "aoColumns": [
        //                            {
        //                                "sTitle": "S No",
        //                                "sName": "Sno",
        //                                "bSearchable": false,
        //                                "bSortable": false
        //                            },
                            {"sTitle": "RentalProductsID", "sName": "RentalProductsID" },
                            { "sTitle": "RentalProductsName", "sName": "RentalProductsName" },
                            { "sTitle": "Description", "sName": "Description" },
                               { "sTitle": "Warrenty", "sName": "Warrenty" },
                            { "sTitle": "UnitPrice", "sName": "UnitPrice" },
                            { "sTitle": "Discount", "sName": "Discount" },
                            { "sTitle": "NetPrice", "sName": "NetPrice" },

                            {
                                "sTitle": "Action",
                                "sName": "RentalProductsID",
                                "bSearchable": false,
                                "bSortable": false,
                                "fnRender": function (obj) {
                                    // return '<a href="Images/bullet.png" id=' + obj.aData[0] +   ' onclick="javascript:EditFunction(this)" style="float:left"><div class="edit" title="EDIT"></div></a>Edit<a href="#" id=' + obj.aData[1]   + ' onclick="javascript:EditFunction(this)" style="float:left"><div class="delete" title="DELETE"></div></a>'
                                    return '<a href="#"><img id=' + obj.aData[0] + ' src="../../Images/edit.png" alt="img1" onclick="javascript:EditFunction(this)" /></a> <a href="#"><img id=' + obj.aData[0] + ' src="../../Images/error.png" alt="img1" onclick="javascript:DeleteFunction(this)" /></a><a href="#"><img  src="../../Images/tick.png" alt="img1"/></a></div>'
                                }
                            }
                ]
    });





    //    $('#RentalProductsName').attr('disabled', 'disabled');
});

function RowSelect(a) {

    alert(a.value);
}

function EditFunction(a) {
   
    window.location.replace("/RentalProducts/EditRentalProducts?RentalProductsID=" + a.id);

}
$("#CreateBundle").click(function () {
    alert("hari");
});

function DeleteFunction(a) {

    $.ajax({
        url: '/RentalProducts/DeleteRentalProducts?RentalProductsID=' + a.id,
        type: 'post',
        datatype: 'json',
        success: function (data) {

            if (data.obj == 'success') {
                window.location.replace('/RentalProducts/RentalProducts');
            }
        },
        error: function (e) {
            alert(e);
        },
        async: false
    });

}

function NewUser() {
    window.location.replace("/RentalProducts/RentalProducts");
}
