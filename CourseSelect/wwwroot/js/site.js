toastr.options.extendedTimeOut = 3000;
toastr.options.timeOut = 3000;
toastr.options.closeButton = true;
toastr.options.positionClass = 'toast-bottom-right';

function onSubscribe() {

    toastr.info('Succeesfuly subscribed');
}

$(document).ready(function () {
    $("#CourseListSearch").on("keyup", function () {
        var value = $(this).val().toLowerCase();

        $("#CourseList").children().each(function (a, b) {
            var needToggle = false
            $(b).find(".description-text").each(function (aa, bb) {
                needToggle = bb.textContent.toLowerCase().indexOf(value) > -1 || needToggle
            })
            $(b).toggle(needToggle)
        });
    });
});