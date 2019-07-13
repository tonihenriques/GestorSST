
function OnSuccessAtualizarAspecto(data) {
    $('#formEdicaoAspecto').removeAttr('style');
    $(".LoadingLayout").hide();
    $('#btnSalvar').show();
    TratarResultadoJSON(data.resultado);
}

function OnBeginAtualizarAspecto() {
    $(".LoadingLayout").show();
    $('#btnSalvar').hide();
    $("#formEdicaoAspecto").css({ opacity: "0.5" });
}