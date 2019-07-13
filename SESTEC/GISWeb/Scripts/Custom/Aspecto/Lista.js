jQuery(function ($) {

    AplicajQdataTable("dynamic-table", [{ "bSortable": false },{ "bSortable": false }], false, 20);

});

    //function BuscarDetalhesEquipe(IDEquipe) {

    //    $(".LoadingLayout").show();

    //    $.ajax({
    //        method: "POST",
    //        url: "/Equipe/BuscarEquipePorID",
    //        data: { idEquipe: IDEquipe },
    //        error: function (erro) {
    //            $(".LoadingLayout").hide();
    //            ExibirMensagemGritter('Oops! Erro inesperado', erro.responseText, 'gritter-error')
    //        },
    //        success: function (content) {
    //            $(".LoadingLayout").hide();

    //            if (content.data != null) {
    //                bootbox.dialog({
    //                    message: content.data,
    //                    title: "<span class='bigger-110'>Detalhes da Empresa</span>",
    //                    backdrop: true,
    //                    locale: "br",
    //                    buttons: {},
    //                    onEscape: true
    //                });
    //            }
    //            else {
    //                TratarResultadoJSON(content.resultado);
    //            }

    //        }
    //    });

    //}

    function DeletarAspecto(IDAspecto, nome) {

        var callback = function () {
            $('.LoadingLayout').show();
            $('#dynamic-table').css({ opacity: "0.5" });

            $.ajax({
                method: "POST",
                url: "/Aspecto/Terminar",
                data: { IDAspecto: IDAspecto },
                error: function (erro) {
                    $(".LoadingLayout").hide();
                    $("#dynamic-table").css({ opacity: '' });
                    ExibirMensagemGritter('Oops! Erro inesperado', erro.responseText, 'gritter-error')
                },
                success: function (content) {
                    $('.LoadingLayout').hide();
                    $("#dynamic-table").css({ opacity: '' });

                    TratarResultadoJSON(content.resultado);

                    if (content.resultado.Sucesso != null && content.resultado.Sucesso != "") {
                        $("#linha-" + IDAspecto).remove();
                    }
                }
            });
        };

        ExibirMensagemDeConfirmacaoSimples("Tem certeza que deseja excluir o '" + nome + "'?", "Exclusão de Aspecto", callback, "btn-danger");

    }


