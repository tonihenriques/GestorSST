




function OnSuccessCadastrarAspectoPergunta(data) {
    $('#formCadastroAspectoPergunta').removeAttr('style');
    $(".LoadingLayout").hide();
    $('#btnSalvar').show();
    TratarResultadoJSON(data.resultado);
    ExibirMsgGritter(data.resultado);
}

function OnBeginCadastrarAspectoPergunta() {
    $(".LoadingLayout").show();
    $('#blnSalvar').hide();
    $("#formCadastroAspectoPergunta").css({ opacity: "0.5" });
}