$("#configNavbar").click(function () {
    $("#EltismoSim").prop("checked", true); //marca o sim pois somente trabalha com sim 
    $('#EltismoNao').attr('disabled', true); // e desativa o não para n ser clicado. 
});

$("#btnSalvarConfig").click(function () {
    $(this).attr("disabled", true); //enable false no botão ao clicar
    $("#btnFecharModalConfig").attr("disabled", true); //enable false no botão fechar

    var dataConfig = JSON.stringify({
        solucao: $('#txtDefineSolucao').val(),
        crossover: $('#txtCrossover').val(),
        mutacao: $('#txtMutacao').val(),
        populacao: $('#txtPopulacao').val(),
        geracao: $('#txtGeracoes').val(),
    });

    $.ajax({  //chama o webmethod para salvar as configs no banco
        type: "POST",
        url: "Default.aspx/salvarConfiguracoes",
        data: dataConfig,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (rtn) {

            if (rtn.d == "True") {

                setTimeout(function () {
                    $('#modalConfiguracoes').modal('hide') //fecha o modal após 2,5 seg
                }, 2500);

                setTimeout(function () {
                    $('#btnSalvarConfig').removeAttr("disabled"); //botão enbale true após 3,2 seg.
                    $('#btnFecharModalConfig').removeAttr("disabled");
                }, 3200);

            } else {
                alert(rtn.d);
                $('#modalConfiguracoes').modal('hide');
                $('#btnFecharModalConfig').removeAttr("disabled");
            }
        }
    });
});

$('#btnLogar').click(function () {
    var dataString = JSON.stringify({
        user: $('#txtLogin').val(), //pega as variasis dos textbox e joga no data do json
        senha: $('#txtSenha').val()
    });

    $.ajax({ //chama o webmethod logar
        type: "POST",
        url: "login.aspx/Logar",
        data: dataString,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (rtn) {
            if (rtn.d == "False") {
                $('#modalErroLogin').modal('show'); //se falso, chama um modal para aviso
                $('#txtSenha').val("")
            }
            else if (rtn.d == "True") {
                $(location).attr('href', 'Default.aspx'); //se sim, redimensiona para a página default
            }
            else {
                $('#lblErroLogin').text(rtn.d + "\n - Algum erro inesperado aconteceu!\nPor favor, entre em contato com o suporte.");
                $('#modalErroLogin').modal('show'); //se explodir exception no no metodo Logar, retorna 
                $('#txtSenha').val("");             //diferente de true ou false, e altera o texto do modal avisando do erro!
            }
        }
    });
});