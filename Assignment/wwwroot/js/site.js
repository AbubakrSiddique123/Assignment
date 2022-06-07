//$.fn.datepicker.defaults.format = "mm/dd/yyyy";
//$.fn.datepicker.defaults.autoclose = true;
////$.fn.datepicker.defaults.


//$('.datepicker,[data-provide="datepicker"]').datepicker().on('hide', function (e) {
//    this.blur();
//});


//$('.datepicker').datepicker({
//    todayBtn: "linked",
//    todayHighlight: true,
//    autoclose: true
//});

//var startDate = new Date();
//startDate.setDate(startDate.getDate() - 1);

//$('.day-before').datepicker({
//    setDate: new Date(),
//    endDate: startDate,
//    todayBtn: "linked",
//    todayHighlight: true,
//    autoclose: true
//});


$(function () {
    var placeholderElement = $('#modal-placeholder');
    $('#modal-placeholder').on('shown.bs.modal', function () {
        var input = $("#modal-placeholder").find("input:text").first();
        $(input).focus();
        $(input).select();
    })
    $('body').on('click', 'button[data-toggle="ajax-modal"]', function (event) {

        var button = $(this);
        url = $(this).data('url');
        $.get(url).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });
    });


    $('body').on('click', 'button[data-toggle="ajax-modal-post"]', function (event, data) {
        debugger
        var button = $(this);
        event.preventDefault();
        form = $(this).parents('form');
        actionUrl = form.attr('action');
        tableToReload = form.data('reloadtable');
        dataToSend = new FormData(form[0]);
        $.ajax({
            type: "POST",
            enctype: 'multipart/form-data',
            url: actionUrl,
            data: dataToSend,
            processData: false,
            contentType: false,
            cache: false,
            //timeout: 600000
        })
            .done(function (data) {
                placeholderElement.html(data);
                $(".modal-backdrop").hide();
                reloadtable(tableToReload);
                
              /*  window.location.reload();*/
            })

            .fail(function (XMLHttpRequest, textStatus, errorThrown) {
                var errMsg = errorThrown;
                if (XMLHttpRequest.responseText != '')
                    errMsg = XMLHttpRequest.responseText;
            });
       
    });
   
    
    $('body').on('click', 'button[data-delete="delete"]', function (event, tableToReload) {
       
        url = $(this).data('url');
        tableToReload = $(this).data('reload');
        var button = $(this);
        Swal.fire({
            title: "Are you sure you want to delete this?",
            text: "You won't be able to return this!",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#FF0000',
            cancelButtonColor: '#337ab7',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.value) {
                $.post(url)
                    .done(function (data) {
                        reloadtable(tableToReload);
                        alert('your item is deleted');
                    
                    })
                    .fail(function (XMLHttpRequest, textStatus, errorThrown) {
                        var errMsg = errorThrown;
                        if (XMLHttpRequest.responseText != '')
                            errMsg = XMLHttpRequest.responseText;
                    });
            }
        });

    });
   
});
