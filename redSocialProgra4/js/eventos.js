$(document).ready(function () {
    var noti = $('#p-noti');
    var soli = $('#p-soli');

    if (noti > 0) {
        noti.css("background-color", "red");
        noti.css("color", "white");
        noti.css("font-weigth", "bold");
    }
    else {
        noti.value = ' ';
    }


    if (soli > 0) {
        soli.css("background-color", "red");
        soli.css("color", "white");
        soli.css("font-weigth", "bold");
    }
    else {
        soli.value = ' ';
    }


});
