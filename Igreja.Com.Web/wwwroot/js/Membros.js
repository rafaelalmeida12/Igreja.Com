$(document).ready(function () {

    BuscarAniversariantes();
    CarregarMes();
    carreseletores();
});

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

//function CarregarMes() {
//    $(".nav-link").on("click", function () {
//        var text = $(this).text();

//        $.get("http://localhost:5000/Membros/TESTE", { mes: text }, function (data) {
//            console.log(data);
//        });
//    })
//}


