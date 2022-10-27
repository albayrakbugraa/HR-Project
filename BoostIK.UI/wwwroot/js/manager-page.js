const api = 'https://localhost:44361/'

function GetPersonelCard() {
    $.ajax({
        url: api + "Manager/GetManagerCard",
        type: "GET",
        success: function (response) {
            console.log(response)
            $('#ik-personel-card').html(response);
        }
    })
}

let p_id = "";
function GetPersonelInfo() {
    $('#modal-edit-profile').modal('show');
    var myUrl = api + "Manager/GetPersonelInfo";

    $.ajax({
        url: myUrl,
        type: "GET",
        success: function (response) {
            console.log(response);
            p_id = response.id
            $('#output').attr('src', response.imagePath)
            $('#profilePic').val(response.imagePath);
            $('#adress').val(response.adress);
            $('#city').val(response.city);
            $('#postCode').val(response.postCode);
            $('#mobilePhone').val(response.mobilePhone);
            $('#phoneNumber').val(response.phoneNumber);
            $('#emergencyPerson').val(response.emergencyPerson);
            $('#emergencyPersonPhone').val(response.emergencyPersonPhone);
            $('#bloodGroup').val(response.bloodGroup);
            $('#personelMail').val(response.personelMail);
        }
    })
}


function UpdateMyInfo() {
    var myUrl = api + "Manager/UpdateManager";

    var formData = new FormData();
    formData.append("id", p_id)
    formData.append("ImagePath", $('#profile-picture').attr('src'))
    formData.append("adress", $('#adress').val())
    formData.append("city", $('#city').val())
    formData.append("postCode", $('#postCode').val())
    formData.append("mobilePhone", $('#mobilePhone').val())
    formData.append("phoneNumber", $('#phoneNumber').val())
    formData.append("emergencyPerson", $('#emergencyPerson').val())
    formData.append("emergencyPersonPhone", $('#emergencyPersonPhone').val())
    formData.append("bloodGroup", $('#bloodGroup').val())
    formData.append("personelMail", $('#personelMail').val())
    formData.append("newPhoto", document.querySelector('#newPhoto').files[0])

    $.ajax({
        url: myUrl,
        data: formData,
        type: "POST",
        processData: false,
        contentType: false,
        success: function (response) {
            if (response.result == true) {
                GetPersonelCard();
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