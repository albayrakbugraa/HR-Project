$('#spending-date').daterangepicker({
    singleDatePicker: true,
    showDropdowns: true,
    minYear: 1901,
    maxYear: parseInt(moment().format('YYYY'), 10),
    "locale": {
        "format": "DD-MM-YYYY",
        "separator": " - ",
        "applyLabel": "Uygula",
        "cancelLabel": "Vazgeç",
        "fromLabel": "Dan",
        "toLabel": "a",
        "customRangeLabel": "Seç",
        "daysOfWeek": [
            "Pt",
            "Sl",
            "Çr",
            "Pr",
            "Cm",
            "Ct",
            "Pz"
        ],
        "monthNames": [
            "Ocak",
            "Şubat",
            "Mart",
            "Nisan",
            "Mayıs",
            "Haziran",
            "Temmuz",
            "Ağustos",
            "Eylül",
            "Ekim",
            "Kasım",
            "Aralık"
        ],
        "firstDay": 0
    },
    
})

$('#spending-date').on('apply.daterangepicker', function (e, picker) {
    var startDate = picker.startDate.format('YYYY-MM-DD');
    $('#SpendingDate').val(startDate)
});

$('form').validate({
    // other rules and options
});

$("#File").rules("add", {
    required: true,
    messages: {
        required: "Lütfen harcama belgesi ekleyin..."
    }
});






