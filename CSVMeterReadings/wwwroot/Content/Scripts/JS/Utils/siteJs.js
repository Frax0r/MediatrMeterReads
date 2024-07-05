var rvt = $('input[name="__RequestVerificationToken"]').val();
$(document)
    .ajaxSend(function (t, a, i) {
        a && i && ("POST" === i.type || "PUT" === i.type || "DELETE" === i.type) && a.setRequestHeader("RequestVerificationToken", rvt);
    });

$(document).ready(function () {

    $(".pbButton").click(function (e) {
        ShowLoader();
    });
    $('#hideSpinnerBn').click(function (e) {
        StopLoader();
    });
    $('.closeModel').click(function(e){
        HideDynamicModal();
    });

    StopLoader();

});

function HideDynamicModal() {
    $('.modal-backdrop').remove();
    $('#DynamicModal').modal('hide');
}

function ShowLoader() {

    $('#overLay').show();
    var opts = {
        lines: 13, // The number of lines to draw
        length: 20, // The length of each line
        width: 10, // The line thickness
        radius: 30, // The radius of the inner circle
        corners: 1, // Corner roundness (0..1)
        rotate: 0, // The rotation offset
        direction: 1, // 1: clockwise, -1: counterclockwise
        color: '#f66e3e', // #rgb or #rrggbb or array of colors
        speed: 1, // Rounds per second
        trail: 60, // Afterglow percentage
        shadow: false, // Whether to render a shadow
        hwaccel: false, // Whether to use hardware acceleration
        className: 'spinner', // The CSS class to assign to the spinner
        zIndex: 2e9, // The z-index (defaults to 2000000000)

    };
    var target = document.getElementById('spinnerHolderDiv');
    target.style.display = 'block';
    spinner = new Spinner(opts).spin(target);
   }

function StopLoader() {

    $('#overLay').hide();
    $('#spinnerHolderDiv').hide();
    $('#renderBody, #MainNav').css('visibility', 'visible');
  
    if (typeof spinner !== 'undefined') {
        if (spinner) {
            spinner.stop()
        }
    }
   
    return true
}

function HandleAjaxError() {

    canEdit = false;
    if (typeof SetEditControl === 'function') {     
        SetEditControl(false, false);
    }   
    HideWaitCursor();
    StopLoader();
    $(window).css('cursor', 'auto');

    CreateDynamicModal('bg-danger', "An Error Has Occurred",
        "An error has occurred, if the problem persists please raise a service now ticket.",
        null,
        true, true);

}

$.fn.redraw = function () {
    $(this).each(function () {
        var redraw = this.offsetHeight;
    });
};