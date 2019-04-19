




function OnSuccessCadastrarAtividade(data) {
    $('#formCadastroAtividade').removeAttr('style');
    $(".LoadingLayout").hide();
    $('#btnSalvar').show();
    TratarResultadoJSON(data.resultado);
    ExibirMsgGritter(data.resultado);
}

function OnBeginCadastrarAtividade() {
    $(".LoadingLayout").show();
    $('#blnSalvar').hide();
    $("#formCadastroAtividade").css({ opacity: "0.5" });
}