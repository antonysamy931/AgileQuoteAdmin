

function RoleEdit(data) {    
    window.location.replace("/UserRegistration/EditUser?Input=" + data.id);    
    return false;
}



function RoleDelete(data) {

    $.ajax({

        url: '/UserRegistration/DeleteUser?UserId=' + data.id,
        type: 'post',
        datatype: 'json',
        success: function (data) {
            if (data.Result == "Success") {
                window.location.replace("/UserRegistration/PartialUser");
            }
        },
        error: function (e) {
        },
        aysnc: false
    });
}

function NewUser() {
    window.location.replace("/UserRegistration/Registration");
}