$(document).ready(function () {


    $('#RentalDataTable').dataTable({
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
        "sAjaxSource": "/RentalSpars/GetRentalSparsList",
        "bProcessing": true,
        "sPaginationType": "full_numbers",
        //"iDisplayLength": 1,
        "aoColumns": [
                            {
                                "sTitle": "RentalSparsId",
                                "sName": "RentalSparsId",
                                "bSearchable": false,
                                "bSortable": false
                            },

                            { "sTitle": "RentalSparsName", "sName": "RentalSparsName" },
                            { "sTitle": "Description", "sName": "Description" },
                            { "sTitle": "Warrenty", "sName": "Warrenty" },
                            { "sTitle": "Unit Price", "sName": "UnitPrice" },
                            { "sTitle": "Discount", "sName": "Discount" },
                            { "sTitle": "NetPrice", "sName": "NetPrice" },


			    {
			        "sTitle": "Action",
			        "sName": "RentalSparsId",
			        "bSearchable": false,
			        "bSortable": false,
			        "fnRender": function (obj) {
			            return '<div style="float:left"><a href="#"><img id=' + obj.aData[0] + ' src="../../Images/edit.png" alt="img1" onclick="javascript:RentalSparsEditFunction(this)" /></a> <a href="#"><img id=' + obj.aData[0] + ' src="../../Images/error.png" alt="img1" onclick="javascript:RentalSparsDeleteFuction(this)" /></a></div>'
			        }
			    }
                ]
    });

});

function RentalSparsEditFunction(data) {
   
    window.location.replace("/RentalSpars/EditRentalSpars?RentalSparsId=" + data.id);
}

function RentalSparsDeleteFuction(data) {
    
    $.ajax({
    
        url: '/RentalSpars/DeleteRentalSpars?RentalSparsId=' + data.id,
        type: 'post',
        datatype: 'json',
        success: function (data) {
            if (data.Result =="Success") {
                window.location.replace("/RentalSpars/PartialRentalSpars");
            }
        },
        error: function (e) {
        },
        aysnc: false
    });
}

function NewUser() {
    window.location.replace("/RentalSpars/RentalSpars");
}
