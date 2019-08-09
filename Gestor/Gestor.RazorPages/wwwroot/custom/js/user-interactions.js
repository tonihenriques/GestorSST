$(function () {
    applyPaceOnAjaxFormSubmit();
    applyClickOnAjaxAnchor();
    applyLayoutOnCommonUIElements();
});

applyPaceOnAjaxFormSubmit = function () {
    $.validator.unobtrusive.parse('form');
    $('[data-submit-ajaxform-pace]').off('click');
    $('[data-submit-ajaxform-pace]').on('click', function (e) {
        e.preventDefault();
        var formToSubmit = $(this).closest('form');
        Pace.track(function () {
            formToSubmit.submit();
        });
    });
};

applyClickOnAjaxAnchor = function () {
    $('[data-ajax-anchor]').off('click');
    $('[data-ajax-anchor]').on('click', function (e) {
        e.preventDefault();
        eval($(this).data('ajax-anchor'));
    });
};

makeAjaxRequestWithPace = function (divToBlock, url, method, data, successCallback) {
    blockDivForAjaxRequest(divToBlock);

    Pace.track(function () {
        $.ajax({
            url: url,
            type: method,
            data: data,
            headers: {
                RequestVerificationToken:
                    $('input:hidden[name="__RequestVerificationToken"]').val()
            }
        })
            .done(function (result) {
                successCallback(result);
            })
            .fail(function (xhr) {
                handleUserInteractionInAjaxFailure(xhr);
            })
            .always(function () {
                unblockDivForAjaxRequest(divToBlock);
            });        
    });
};

alertWarning = function (msg) {
    bootbox.dialog({
        message: msg,
        title: "<span style='color: #e08e0b'><i class='fa fa-exclamation-circle'></i> Ops! Algum detalhe precisa de sua atenção.</span>",
        backdrop: true,
        locale: "br",
        buttons: {
            "ok": {
                "label": "<i class='fa fa-check'></i> Ok",
                "className": "btn-sm btn-warning"
            }
        },
        onEscape: true
    });
};

alertError = function (msg) {
    bootbox.dialog({
        message: msg,
        title: "<span style='color: #dd4b39'><i class='fa fa-exclamation-triangle'></i> Ops! Ocorreu algum problema.</span>",
        backdrop: true,
        locale: "br",
        buttons: {
            "ok": {
                "label": "<i class='fa fa-check'></i> Ok",
                "className": "btn-sm btn-danger"
            }
        },
        onEscape: true
    });    
};

alertSuccess = function (msg) {
    bootbox.dialog({
        message: msg,
        title: "<span style='color: #00a65a'><i class='fa fa-check-circle'></i> Tudo certo!</span>",
        backdrop: true,
        locale: "br",
        buttons: {
            "ok": {
                "label": "<i class='fa fa-check'></i> Ok",
                "className": "btn-sm btn-success"
            }
        },
        onEscape: true
    });
};

alertInfo = function (msg) {
    bootbox.dialog({
        message: msg,
        title: "<span style='color: #00c0ef'><i class='fa fa-info-circle'></i> A título de informação:</span>",
        backdrop: true,
        locale: "br",
        buttons: {
            "ok": {
                "label": "<i class='fa fa-check'></i> Ok",
                "className": "btn-sm btn-info"
            }
        },
        onEscape: true
    });
};

confirmOperation = function (extraMessage, callbackFunction) {
    bootbox.confirm({
        message: extraMessage + " Tem certeza de que deseja realizar esta operação?",
        title: "<span style='color: #367fa9'><i class='fa fa-question-circle'></i> Confirmação de Operação</span>",
        backdrop: true,
        locale: "br",
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> Cancelar'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Confirmar'
            }
        },
        callback: function (result) {
            if (result) {
                callbackFunction();
            }
        },
        onEscape: true
    });
};

extractMessageFromCoreException = function (ex) {
    var msg = "";
    if (ex !== undefined) {
        if (ex.items) {
            $.each(ex.items, function (key, value) {
                msg += "<span style='color: #e08e0b; font-weight: bold;'>" + value.key + "</span>: " + value.message + "<br>";
            });
            msg = msg.substr(0, msg.length - 4);
        } else if (ex.message) {
            msg = ex.message;
        }
    }
    return msg;
};

extractMessageFromInternalServerError = function (ex) {
    var msg = "";
    if (ex !== undefined) {
        if (ex.logId) {
            msg = "Identificador do erro: <span style='color: #dd4b39; font-weight: bold;'>" + ex.logId + "</span><br>";
        }
        if (ex.message) {
            msg += ex.message;
        }
        if (msg.endsWith("<br>")) {
            msg = msg.substr(0, msg.length - 4);
        }
    }
    return msg;
};

handleRedirectInAjaxRequest = function (xhr) {
    if (xhr.returnUrl)
        location.href = xhr.returnUrl;
};

handleUserInteractionInAjaxFailure = function (xhr) {
    var alertMethod = 'warning';
    var msgColor = '#e08e0b';
    var msg = "<span style='color: #msgColor; font-weight: bold; font-size: 20px;'><i style='color: #001f3f;' class='fa fa-wrench icon-animated-wrench'></i> " + xhr.status + " - ";

    if (xhr.status === 400 || xhr.status === 404 || xhr.status === 406) {
        msg += "Bad Request</span>";

        if (xhr.responseJSON) {
            var detail4x = extractMessageFromCoreException(xhr.responseJSON);
            if (detail4x !== '')
                msg += '<br>' + detail4x;
        }
    } else if (xhr.status === 401 || xhr.status === 403) {
        msg += "Unauthorized</span>" +
            "<br>Credentials are invalid, expired, or have insufficient privileges.";
    } else if (xhr.status === 500) {
        alertMethod = 'error';
        msgColor = '#dd4b39';
        msg += "Internal Server Error</span>";

        if (xhr.responseJSON) {
            var detail500 = extractMessageFromInternalServerError(xhr.responseJSON);
            if (detail500 !== '')
                msg += '<br>' + detail500;
        }
    } else if (xhr.status === 503) {
        alertMethod = 'error';
        msgColor = '#dd4b39';
        msg += "Service Unavailable</span>" +
            "<br>There is a connectivity issue with some microservice host.";
    } else {
        msg += xhr.statusText + "</span>";
    }

    msg = msg.replace('#msgColor', msgColor);
    if (alertMethod === 'warning') {
        alertWarning(msg);
    } else {
        alertError(msg);
    }
};

blockDivForAjaxRequest = function (id) {
    if (id) {
        $('#' + id).append('<div class="blockDiv"></div>');
    }
    else {
        $('.blockableDiv').append('<div class="blockDiv"></div>');
    }
};

unblockDivForAjaxRequest = function (id) {
    if (id) {
        $('#' + id).children('.blockDiv').remove();
    }
    else {
        $('.blockableDiv').children('.blockDiv').remove();
    }
};

showPartialOnBootbox = function (xhr) {
    var dialog = bootbox.dialog({
        message: xhr,
        title: "<span style='color: #333333'><i class='fa fa-info-circle'></i> Informações</span>",
        backdrop: true,
        locale: "br",
        onEscape: true
    });

    dialog.on('shown.bs.modal', function (e) {
        applyLayoutOnCommonUIElements();
    });  
};

showFormOnBootbox = function (xhr) {
    var dialog = bootbox.dialog({
        message: xhr,
        title: "<span style='color: #333333'><i class='fa fa-edit'></i> Informe os dados abaixo:</span>",
        backdrop: false,
        locale: "br",
        onEscape: false
    });

    dialog.on('shown.bs.modal', function (e) {
        applyPaceOnAjaxFormSubmit();
    });    
};

handleUserInteractionInBootboxFormSubmit = function (bootboxChildId) {
    $('#' + bootboxChildId).closest('.bootbox.modal').modal('hide');
    alertSuccess("O formulário foi submetido e processado com sucesso.");
};

applyLayoutOnCommonUIElements = function () {
    $('.select2').select2({
        allowClear: true,
        dropdownAutoWidth: true,
        width: '100%'
    });

    $('.datepicker').datepicker({
        autoclose: true,
        language: 'pt-BR'
    });

    $('.timepicker').timepicker({
        showInputs: false,
        defaultTime: false
    });

    $('[data-toggle="tooltip"]').tooltip();

    $('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
        checkboxClass: 'icheckbox_flat-red',
        radioClass: 'iradio_flat-red'
    });
};