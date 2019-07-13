




function OnSuccessCadastrarPergunta(data) {
    $('#formCadastroPergunta').removeAttr('style');
    $(".LoadingLayout").hide();
    $('#btnSalvar').show();
    TratarResultadoJSON(data.resultado);
    ExibirMsgGritter(data.resultado);
}

function OnBeginCadastrarPergunta() {
    $(".LoadingLayout").show();
    $('#blnSalvar').hide();
    $("#formCadastroPergunta").css({ opacity: "0.5" });
}