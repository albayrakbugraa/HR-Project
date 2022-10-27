const api = 'https://localhost:44361/'

const GetAdminCard = () => {
    $.ajax({
        url: api + "Admin/GetAdminCard",
        type: "GET",
        success: function (response) {
            console.log(response)
            $('#ik-personel-card').html(response);
        }
    })
}

let p_id = "";
const getAdminInfo = () => {
    $('#modal-edit-admin').modal('show');
    var myUrl = api + "Admin/GetAdminEditInfo";

    $.ajax({
        url: myUrl,
        type: "GET",
        success: function (response) {
            console.log(response);
            p_id = response.id
            $('#output').attr('src', response.imagePath)
            $('#profilePic').val(response.imagePath);
            $('#FirstName').val(response.firstName);
            $('#LastName').val(response.lastName);
            $('#PhoneNumber').val(response.phoneNumber);
            $('#Email').val(response.email);
        }
    })
}


const UpdateAdminInfo = () => {
    var myUrl = api + "Admin/UpdateAdmin";

    var formData = new FormData();
    formData.append("id", p_id)
    formData.append("ImagePath", $('#profile-picture').attr('src'))
    formData.append("firstName", $('#FirstName').val())
    formData.append("lastName", $('#LastName').val())
    formData.append("phoneNumber", $('#PhoneNumber').val())
    formData.append("email", $('#Email').val())
    formData.append("newPhoto", document.querySelector('#newPhoto').files[0])

    $.ajax({
        url: myUrl,
        data: formData,
        type: "POST",
        processData: false,
        contentType: false,
        success: function (response) {
            console.log(response)
            if (response.result == true) {
                GetAdminCard();
                toastr.success("Bilgileriniz Güncellendi");
                $('#modal-edit-profile').modal('hide')

                // deploy olduğunda burası cacheden dolayı güncellenmiyor. o yüzden manuel olarak güncelliyoruz.
                $('#profile-picture').attr('src', $('#output').attr('src'));
            }
            else {
                const errList = response.reduce((acc, val) => `${acc}<li>${val}</li>`, "")
                toastr.warning("Bilgiler Güncellenirken Hata Oluştu" + "<br>" + errList)
            }
        },
        error: () => toastr.error("Bilinmeyen bir hata oluştu.")
    })

}