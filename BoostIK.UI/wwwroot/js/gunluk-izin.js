// gün ekleyen fonksiyon

function addDays(date, days) {
    var result = new Date(date);
    result.setDate(result.getDate() + days);
    return result;
}

$('#start-date, #end-date').daterangepicker({
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
    minDate: addDays(new Date(), 1)
})

$('#start-date').on('apply.daterangepicker', function (e, picker) {
    var startDate = picker.startDate.format('YYYY-MM-DD');
    $('#StartDate').val(startDate)
    writeDayCount();
});

$('#end-date').on('apply.daterangepicker', function (e, picker) {
    var startDate = picker.startDate.format('YYYY-MM-DD');
    $('#EndDate').val(startDate)
    writeDayCount();
});

function writeDayCount() {
    let startDate = new Date($('#StartDate').val())
    let endDate = new Date($('#EndDate').val())

    let difference = endDate.getTime() - startDate.getTime();
    let TotalDays = Math.ceil(difference / (1000 * 3600 * 24));
    $('#DayCount').val(TotalDays + 1)
}


document.querySelector('#PermissionID').addEventListener("change", (e) => {
    setMaxVal();
    //document.querySelector('#DayCount').setAttribute('max', max)
});

const setMaxVal = () => {
    let max = $('#PermissionID').find(":selected").data("limit");
    $('#DayCount').attr('max', max);
}

setMaxVal();


//$('#start-date').daterangepicker({
//    singleDatePicker: true,
//    showDropdowns: true,
//    minYear: 1901,
//    maxYear: parseInt(moment().format('YYYY'), 10),
//    "locale": {
//        "format": "DD-MM-YYYY",
//        "separator": " - ",
//        "applyLabel": "Uygula",
//        "cancelLabel": "Vazgeç",
//        "fromLabel": "Dan",
//        "toLabel": "a",
//        "customRangeLabel": "Seç",
//        "daysOfWeek": [
//            "Pt",
//            "Sl",
//            "Çr",
//            "Pr",
//            "Cm",
//            "Ct",
//            "Pz"
//        ],
//        "monthNames": [
//            "Ocak",
//            "Şubat",
//            "Mart",
//            "Nisan",
//            "Mayıs",
//            "Haziran",
//            "Temmuz",
//            "Ağustos",
//            "Eylül",
//            "Ekim",
//            "Kasım",
//            "Aralık"
//        ],
//        "firstDay": 0
//    },
//    minDate: addDays(new Date(), 1)
//}).on('apply.daterangepicker', function (e, picker) {
//    var startDate = picker.startDate.format('YYYY-MM-DD');
//    $('#StartDate').val(startDate)
//    writeDayCount();
//    console.log(startDate);
//});

//$('#end-date').daterangepicker({
//    singleDatePicker: true,
//    showDropdowns: true,
//    minYear: 1901,
//    maxYear: parseInt(moment().format('YYYY'), 10),
//    "locale": {
//        "format": "DD-MM-YYYY",
//        "separator": " - ",
//        "applyLabel": "Uygula",
//        "cancelLabel": "Vazgeç",
//        "fromLabel": "Dan",
//        "toLabel": "a",
//        "customRangeLabel": "Seç",
//        "daysOfWeek": [
//            "Pt",
//            "Sl",
//            "Çr",
//            "Pr",
//            "Cm",
//            "Ct",
//            "Pz"
//        ],
//        "monthNames": [
//            "Ocak",
//            "Şubat",
//            "Mart",
//            "Nisan",
//            "Mayıs",
//            "Haziran",
//            "Temmuz",
//            "Ağustos",
//            "Eylül",
//            "Ekim",
//            "Kasım",
//            "Aralık"
//        ],
//        "firstDay": 0
//    },
//    minDate: addDays(new Date(), 1)
//}).on('apply.daterangepicker', function (e, picker) {
//    var startDate = picker.startDate.format('YYYY-MM-DD');
//    $('#EndDate').val(startDate)
//    writeDayCount();
//    console.log(startDate);
//});