
$(function () {
    var placeholderElement = $('#modal-placeholder');
    $('#modal-placeholder').on('shown.bs.modal', function () {
        var input = $("#modal-placeholder").find("input:text").first();
        $(input).focus();
        $(input).select();
    })
    $('body').on('click', 'button[data-toggle="ajax-modal"]', function (event) {
        var button = $(this);
        toggleSpinner(button);
        url = $(this).data('url');
        $.get(url).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
            toggleSpinner(button, false);
        });
    });


    $('body').on('click', 'button[data-toggle="ajax-modal-post"]', function (event, data) {
        debugger
        var button = $(this);
        toggleSpinner(button);
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
        toggleSpinner(button);
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
    function toggleSpinner(button, enable = true) {
        debugger
        console.log('button was clicked');
        if (button[0].localName == 'a') { //for anchor tag disable property will not work
            $(button).click(function (e) {
                e.preventDefault();
            });
        }
        if (enable) { //enable spinner
            button.append('<i class="fas fa-spinner fa-spin"></i>');
            button.prop('disabled', true);
        }
        else {
            button.removeAttr('disabled', 'disabled');
            button.find('.fa-spinner').remove();
        }
    }
    function reloadtable() {
        $('#myTable').load('/Employee/index #myTable>', function () {
            $('#myTable').DataTable().destroy();
            $('#myTable').DataTable();
        });
    }

});
