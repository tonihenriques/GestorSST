



function OnSuccessCadastrarAnaliseRisco(data) {
    $('#formCadastroAnaliseRisco').removeAttr('style');
    $(".LoadingLayout").hide();
    $('#btnSalvar').show();
    TratarResultadoJSON(data.resultado);
}

function OnBeginCadastrarAnaliseRisco() {
    $(".LoadingLayout").show();
    $('#btnSalvar').hide();
    $("#formCadastroAnaliseRisco").css({ opacity: "0.5" });
}


