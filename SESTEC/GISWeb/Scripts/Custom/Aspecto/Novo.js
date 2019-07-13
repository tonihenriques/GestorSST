




function OnSuccessCadastrarAspecto(data) {
    $('#formCadastroAspecto').removeAttr('style');
    $(".LoadingLayout").hide();
    $('#btnSalvar').show();
    TratarResultadoJSON(data.resultado);
    ExibirMsgGritter(data.resultado);
}

function OnBeginCadastrarAspecto() {
    $(".LoadingLayout").show();
    $('#blnSalvar').hide();
    $("#formCadastroAspecto").css({ opacity: "0.5" });
}