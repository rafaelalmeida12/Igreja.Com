$(document).ready(function () {

    ObjetoIgreja.CarregarFormulario();
    ObjetoDizimos.autocomplete();
});

var ObjetoSistema = new Object();
var ObjetoIgreja = new Object();
var ObjetoDizimos = new Object();

//Usuario
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

    var ofertas = {
        Observacao: $("#Observacao").val(),
        Valor: $("#Valor").val(),
        DataCadastro: $("#DataCadastro").val(),
        CategoriaOferta: $("#CategoriaOferta").val()
    }

    $.ajax({
        type: 'POST',
        timeout: 50000,
        url: '/Ofertas/Create',
        async: true,
        data: { oferta: ofertas },
        success: function (jsonRetornado) {
            ObjetoSistema.ListarUsuarios();
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
//Culto

ObjetoIgreja.CarregarFormulario = function () {
    $.ajax({
        type: 'GET',
        timeout: 50000,
        url: '/Culto/Criar',
        async: false,
        success: function (jsonRetornado) {
            $("#tabelaUsuario").html(jsonRetornado);
        }
    });
}

ObjetoIgreja.SalvarCulto = function () {

    var Culto = {
        MembroId: $("#MembroId").val(),
        CategoriaCultoId: $("#CategoriaCultoId").val(),
    }

    $.ajax({
        type: 'POST',
        timeout: 50000,
        url: '/Culto/Create',
        async: true,
        data: { culto: Culto },
        success: function (jsonRetornado) {
            $("#tabelaUsuario").html(jsonRetornado);
        }
    });
}
//Dizimos

ObjetoDizimos.CarregarFormulario = function () {
    $.ajax({
        type: 'GET',
        timeout: 50000,
        url: '/Dizimos/Create',
        async: false,
        success: function (jsonRetornado) {
            $("#tabelaUsuario").html(jsonRetornado);
        }
    });
}

ObjetoDizimos.SalvarCulto = function () {

    var Objeto = {
        MembroId: $("#MembroId").val(),
        Observacao: $("#Observacao").val(),
        Valor: $("#Valor").val(),
        DataCadastro: $("#DataCadastro").val(),
        FormaPagamento: $("#FormaPagamento").val(),
        CultoId: $("#CultoId").val()
    }

    $.ajax({
        type: 'POST',
        timeout: 50000,
        url: '/Dizimos/Create',
        async: true,
        data: { objeto: Objeto },
        success: function (jsonRetornado) {
            $("#tabelaUsuario").html(jsonRetornado);
        }
    });
}



ObjetoDizimos.autocomplete = function () {
    var membro = $("#MembroId").val();

    if (membro.length >= 3) {
        $.ajax({
            type: 'POST',
            url: '/Membros/Teste',
            data: {
                nome: membro
            },
            success: function (data) {
                $.each(data) {
                    $("#MembroId").append(data.nome);
                };
            }
        });
    }
}