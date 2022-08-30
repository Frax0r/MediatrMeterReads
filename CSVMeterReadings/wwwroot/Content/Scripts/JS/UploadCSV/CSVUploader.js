$(document).ready(function () { 

    if (window.history.replaceState) {
        window.history.replaceState(null, document.title, window.location.href);
    }

    $('#fileSelect').on("change", function () {
        ShowLoader();
        $('window').redraw();
        if ($('#fileSelect').val() && $("#headerForm").valid()) {
            $("#headerForm").submit();
        }
    });
    $('#dtMeterReadingRecords').DataTable();
    $('#DynamicModal').modal('show');
  
});

