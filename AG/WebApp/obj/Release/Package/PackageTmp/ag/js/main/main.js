function configNavbar() {
    $("#EltismoSim").prop("checked", true); //marca o sim pois somente trabalha com sim 
    $('#EltismoNao').attr('disabled', true); // e desativa o não para n ser clicado. 
};

function btnSalvarConfig() {
    $("#btnSalvarCfg").attr("disabled", true); //enable false no botão ao clicar
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
                    $('#btnSalvarCfg').removeAttr("disabled"); //botão enbale true após 3,2 seg.
                    $('#btnFecharModalConfig').removeAttr("disabled");
                }, 3200);

            } else {
                alert(rtn.d);
                $('#modalConfiguracoes').modal('hide');
                $('#btnFecharModalConfig').removeAttr("disabled");
            }
        }
    });
};

function Logar() {
    var dataString = JSON.stringify({
        user: $('#txtLogin').val(), //pega as variasis dos textbox e joga no data do json
        senha: $('#txtSenha').val()
    });

    $.ajax({ //chama o webmethod logar
        type: "POST",
        url: "./ag/login.aspx/Logar",
        data: dataString,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (rtn) {
            if (rtn.d == "False") {
                $('#lblErroLogin').text("Verifique seu usuário e/ou senha. Caso contrário, seu usuário pode estar em manutenção!");
                $('#modalErroLogin').modal('show'); //se falso, chama um modal para aviso
                $('#txtSenha').val("")
            }
            else if (rtn.d == "True") {
                $(location).attr('href', 'ag/Default.aspx'); //se sim, redimensiona para a página default
            }
            else {
                $('#lblErroLogin').text(rtn.d + "\n - Algum erro inesperado aconteceu!\nPor favor, entre em contato com o suporte.");
                $('#modalErroLogin').modal('show'); //se explodir exception no no metodo Logar, retorna 
                $('#txtSenha').val("");             //diferente de true ou false, e altera o texto do modal avisando do erro!
            }
        }
    });
}

function altSenha() {
    var senha = $('#txtSenhaAntiga').val();
    var newsenha = $('#txtSenhaNova').val();
    var newsenha2 = $('#txtSenhaNovaNovamente').val();

    var dataString = JSON.stringify({
        senha: senha,
        newsenha: newsenha,
        newsenha2: newsenha2
    });

    $.ajax({ //chama o webmethod logar
        type: "POST",
        url: "Default.aspx/AlterarSenha",
        data: dataString,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (rtn) {
            if (rtn.d == "False1") {
                $('#lblErro').text("Senhas não conferem ou invalidas!");
                $('#modalErro').modal('show'); //se explodir exception no no metodo Logar, retorna 
            }
            else if (rtn.d == "False2") {
                $('#lblErro').text("Senha antiga incorreta!");
                $('#modalErro').modal('show'); //se explodir exception no no metodo Logar, retorna 
            }
            else if (rtn.d == "True") {
                $('#lblSucess').text("Senha alterada com sucesso!");
                $('#modalSucess').modal('show'); //se explodir exception no no metodo Logar, retorna 
                $.ajax({ //chama o webmethod logar
                    type: "POST",
                    url: "Default.aspx/Logoff",
                    data: dataString,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function () {
                        setTimeout(function () {
                            window.location.href = "../index.aspx"
                        }, 1500);
                    }
                });
            }
            else {
                $('#lblErro').text(rtn.d + "\n - Algum erro inesperado aconteceu!\nPor favor, entre em contato com o suporte.");
                $('#modalErro').modal('show'); //se explodir exception no no metodo Logar, retorna 
            }
        }
    });
}

function rodarAg() {
    var solucao = $("#txtDefineSolucao").val();

    $("#graficoAnterior").hide(); 
    $("#btnVaiTeste2").hide();
    $("#btnVaiTeste").hide();
    $("#verGrafico").hide();
    $("#aguarde").show();

    $("#divtext1").text("Iniciando... Aptidão da solução: " + solucao);
    $("#divtext2").text("");
    $("#divtext3").text("");

    $.ajax({ //chama o webmethod logar
        type: "POST",
        url: "Default.aspx/RodarAg",
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (rtn) {
            $("#btnVaiTeste2").show();
            $("#verGrafico").show();
            $("#aguarde").hide();

            $("#divtext1").text(rtn.d.text1);
            $("#divtext2").text(rtn.d.text2);
            $("#divtext3").text(rtn.d.text3);
        }
    });
}