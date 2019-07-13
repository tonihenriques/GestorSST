
function OnSuccessAtualizarEquipe(data) {
    $('#formEdicaoEquipe').removeAttr('style');
    $(".LoadingLayout").hide();
    $('#btnSalvar').show();
    TratarResultadoJSON(data.resultado);
}

function OnBeginAtualizarEquipe() {
    $(".LoadingLayout").show();
    $('#btnSalvar').hide();
    $("#formEdicaoEquipe").css({ opacity: "0.5" });
}