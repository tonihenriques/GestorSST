applyDataTable = function (elementId, paging, pageLength) {
    $("#" + elementId).DataTable({
        autoWidth: false,
        paging: paging,
        displayLength: pageLength,
        language: {
            emptyTable: "<span class=\"small\" style=\">Nenhum registro encontrado.</span>",
            info: "<small>Mostrando de _START_ até _END_ de _TOTAL_ registros</small>",
            infoEmpty: "<span class=\"small\">Mostrando 0 até 0 de 0 registros</span>",
            infoFiltered: "<small>(Filtrados de _MAX_ registros)</small>",
            infoPostFix: "",
            infoThousands: ".",
            lengthMenu: "_MENU_ <span class=\"small\">resultados por página</span>",
            loadingRecords: "Carregando...",
            processing: "Processando...",
            zeroRecords: "<small>Nenhum registro encontrado</small>",
            search: "<span class=\"small\"><i class=\"ace-icon fa fa-search bigger-110\"> </i> </span> ",
            paginate: {
                next: "<span style=\"font-weight: bold\">>></span>",
                previous: "<span style=\"font-weight: bold\"><<</span>",
                first: "<span style=\"font-weight: bold\">|<</span>",
                last: "<span style=\"font-weight: bold\">>|</span>"
            },
            aria: {
                sortAscending: ": Ordenar colunas de forma ascendente",
                sortDescending: ": Ordenar colunas de forma descendente"
            }
        }
    });
};