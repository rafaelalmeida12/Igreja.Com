$(document).ready(function () {

    BuscarAniversariantes();
});

function BuscarAniversariantes() {
    var corpodatabela = $(".tabelaaniversariantes").find("tbody");

    $.get("http://localhost:5000/Membros/BuscarAniversariantes", function (data) {

        $.each(data, function (nome, result) {

            var linha = $("<tr>");
            var usuario = $("<td>").text(result.nome);
            var dtNascimento = $("<td>").text(result.dataNascimento);
            var linhabotao = $("<td>").addClass("td-actions text-right");

            var botao = $("<button>").attr("type", "button").attr("asp-action", "Detalhes").attr("asp-controller", "Membros").attr("rel","tooltip").addClass("btn btn-primary btn-link btn-sm");
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

//<button type="button" rel="tooltip" title="" class="btn btn-primary btn-link btn-sm" formaction="/Membros/Detalhes" data-original-title="Detalhes">
//    <i class="material-icons">visibility</i>
//    <div class="ripple-container"></div></button>