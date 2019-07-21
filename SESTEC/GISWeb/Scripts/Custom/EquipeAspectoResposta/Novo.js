




function OnSuccessCadastrarEquipeAspectoResposta(data) {
    $('#formCadEquipeAspectoResposta').removeAttr('style');
    $(".LoadingLayout").hide();
    $('#btnSalvar').show();
    TratarResultadoJSON(data.resultado);
    ExibirMsgGritter(data.resultado);
}

function OnBeginCadastrarEquipeAspectoResposta() {
    $(".LoadingLayout").show();
    $('#blnSalvar').hide();
    $("#formCadEquipeAspectoResposta").css({ opacity: "0.5" });
}