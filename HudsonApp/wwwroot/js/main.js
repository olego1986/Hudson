//const myModal = document.getElementById('myModal');
//const myInput = document.getElementById('myInput');

//myModal.addEventListener('shown.bs.modal', () => {
//        myInput.focus();
//    });

$(document).ready(function () {
    // Відкрити modal
    //function showPopup() {
    //    $('#myModal').modal('show');
    //}

    //// Закрити pop-up
    //function closePopup() {
    //    $('#customPopup').modal('hide');
    //}

    //// Подія для кнопки закриття
    //$('.close-btn').on('click', closePopup);

    //// Закриття при кліку поза pop-up
    //$('#customPopup').on('click', function (e) {
    //    if ($(e.target).is('.popup-overlay')) {
    //        closePopup();
    //    }
    //});

    $(".callback-btn").on('click', function () {
        debugger;
        var callbackType = $(this).attr("callbackType");
        debugger;
        $("#callbackType").val(callbackType);
    });
});