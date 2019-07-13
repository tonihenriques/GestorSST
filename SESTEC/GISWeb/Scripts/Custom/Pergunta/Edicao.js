
function OnSuccessAtualizarPergunta(data) {
    $('#formEdicaoPergunta').removeAttr('style');
    $(".LoadingLayout").hide();
    $('#btnSalvar').show();
    TratarResultadoJSON(data.resultado);
}

function OnBeginAtualizarPergunta() {
    $(".LoadingLayout").show();
    $('#btnSalvar').hide();
    $("#formEdicaoPergunta").css({ opacity: "0.5" });
}