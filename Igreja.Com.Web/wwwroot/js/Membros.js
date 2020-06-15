$(document).ready(function () {

    BuscarAniversariantes();
    //  CarregarMes();
    carreseletores();
})

function BuscarAniversariantes() {
    var corpodatabela = $(".tabelaaniversariantes").find("tbody");

    $.get("http://localhost:5000/Membros/BuscarAniversariantes", function (data) {

        $.each(data, function (nome, result) {

            var linha = $("<tr>");
            var usuario = $("<td>").text(result.nome);
            var dtNascimento = $("<td>").text(result.dataNascimento);
            var linhabotao = $("<td>").addClass("td-actions text-right");

            var botao = $("<button>").attr("type", "button").attr("asp-action", "Detalhes").attr("asp-controller", "Membros").attr("rel", "tooltip").addClass("btn btn-primary btn-link btn-sm");
            var icone = $("<i>").addClass("material-icons").text("visibility");

            botao.append(icone);
            linhabotao.append(botao);

            linha.append(usuario);
            linha.append(dtNascimento);
            linha.append(linhabotao);

            corpodatabela.append(linha);

        });
    });
}

function carreseletores() {
    $(".form-check-input").on("click", function () {
        event.preventDefault();
        $(".dropIgrejas").toggle();
    })
}


function PesquisarDatas() {
    var data1 = $("#data1").val();
    var data2 = $("#data2").val();

    $.ajax({
        type: 'GET',
        timeout: 50000,
        data: { data1, data2 },
        url: '/Movimentacao/Pesquisar',
        async: false,
        success: function (retorno) {
            $("#tabelaMovimentacao").html(retorno);
            $("#data1").val(data1);
            $("#data2").val(data2);
        }
    });
}