$(document).ready(function () {
    $("#callbackButton").on('click', showPopup);

    // Відкрити modal
    function showPopup() {
        $('#callbackModal').modal('show');
    }

    // Закрити pop-up
    function closePopup() {
        $('#customPopup').modal('hide');
    }

    // Подія для кнопки закриття
    $('.close-btn').on('click', closePopup);

    // Закриття при кліку поза pop-up
    $('#customPopup').on('click', function (e) {
        if ($(e.target).is('.popup-overlay')) {
            closePopup();
        }
    });
});