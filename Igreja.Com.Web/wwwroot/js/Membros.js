$(document).ready(function () {

    BuscarAniversariantes();
    CarregarMes();
    carreseletores();
    ObjetoSistema.ListarUsuarios();
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

function CarregarMes() {
    $(".nav-link").on("click", function () {
        var text = $(this).text();

        $.get("http://localhost:5000/Membros/TESTE", { mes: text }, function (data) {
            console.log(data);
        });
    })
}

//------------------------------------------------------------------------------------

var ObjetoSistema = new Object();

ObjetoSistema.IncluirNovousuario = function () {

    $.ajax({
        type: 'GET',
        timeout: 50000,
        url: '/Ofertas/create',
        async: false,
        success: function (jsonRetornado) {
            $("#tabelaUsuario").html(jsonRetornado);
        }
    });
}

ObjetoSistema.ListarUsuarios = function () {
    var idSistema = $("#Id").val();

    var html = '<tr><td><div class="form-group"><input type="button" value="Incluir Novo Usuário" class="btn btn-primary" onclick="ObjetoSistema.IncluirNovousuario()" /></br><span id="mensagemerro" class="text-danger"></span></div></td></tr>';

    $("#tabelaUsuario").html('');

    $.ajax({
        type: 'GET',
        timeout: 50000, 
        url: '/Ofertas/Lista',
        async: false,
        success: function (jsonRetornado) {
            $("#tabelaUsuario").html(jsonRetornado);
        }
    });
}


ObjetoSistema.SalvarUsuario = function () {

    var idSistema = $("#Id").val();
    var emailUsuario = $("#EmailUsuario").val();


    $.ajax({
        type: 'POST',
        timeout: 50000, //Parametrizar com objs
        url: '/UsuarioSistemaFinanceiro/AdicionarUsuaio',
        async: true,
        data: {
            "idSistema": idSistema, 'emailUsuario': emailUsuario
        },
        success: function (jsonRetornado) {

            if (jsonRetornado.sucesso == "OK") {
                ObjetoSistema.ListarUsuarios();
            }
            else {
                $("#mensagemerro").text(jsonRetornado.sucesso);
            }


        }
    });


}

ObjetoSistema.RemoverUsuario = function (emailUsuario) {

    var idSistema = $("#Id").val();

    $.ajax({
        type: 'POST',
        timeout: 50000, //Parametrizar com objs
        url: '/UsuarioSistemaFinanceiro/RemoverUsuario',
        async: false,
        data: {
            "idSistema": idSistema, 'emailUsuario': emailUsuario
        },
        success: function (jsonRetornado) {

            if (jsonRetornado.sucesso == "OK") {
                ObjetoSistema.ListarUsuarios();
            }
            else {
                $("#mensagemerro").text(jsonRetornado.sucesso);
            }


        }
    });
}

