
function OnSuccessAtualizarAspectoPergunta(data) {
    $('#formEdicaoAspectoPergunta').removeAttr('style');
    $(".LoadingLayout").hide();
    $('#btnSalvar').show();
    TratarResultadoJSON(data.resultado);
}

function OnBeginAtualizarAspectoPergunta() {
    $(".LoadingLayout").show();
    $('#btnSalvar').hide();
    $("#formEdicaoAspectoPergunta").css({ opacity: "0.5" });
}