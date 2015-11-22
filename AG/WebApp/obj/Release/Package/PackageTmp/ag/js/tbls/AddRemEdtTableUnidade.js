$(document).ready(function () {
    var editandoUnidade = false;

    $("#addUnidade").click(function () {
        var idUnidade = "";

        $.ajax({  //chama o webmethod para salvar as configs no banco
            type: "POST",
            url: "Default.aspx/PegarProximoId",
            data: "{ tbl: 'unidade'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (rtn) {
                idUnidade = rtn.d;

                $("#tblUnidade").append('<tr id="rowUnidade' + idUnidade + '"><td style="width:30%; "><div class="form-group has-feedback"><input type="text" id="txtCodUnidade' + idUnidade + '" name="txtCodUnidade' + idUnidade + '" placeholder="Código da Unidade" class="form-control" /><span class="glyphicon form-control-feedback" id="spanCodUnidade' + idUnidade + '"></span></div></td><td style="width:55%; "><div class="form-group has-feedback"><input type="text" id="txtNomeUnidade' + idUnidade + '" name="txtNomeUnidade' + idUnidade + '" placeholder="Nome da Unidade" class="form-control" /><span class="glyphicon form-control-feedback" id="spanNomeUnidade' + idUnidade + '"></span></div></td><td style="width:15%; "><button class="btn btn-primary glyphicon glyphicon-floppy-disk saveRowUnidade"></button> <button class="btn btn-danger glyphicon glyphicon-remove remRowUnidade"></button></td></tr>');

                $("#addUnidade").attr('disabled', true);

                editandoUnidade = true;
            }
        });
    });

    $("#tblUnidade").on('click', '.edtRowUnidade', function () {
        if (editandoUnidade) {
            $('#lblErro').text("Conclua a edição para editar as demais!");
            $('#modalErro').modal('show'); //se explodir exception no no metodo Logar, retorna 
        }
        else {
            editandoUnidade = true;

            var linha = $(this).parent().parent();

            var idUnidadeTemp = linha.attr('id');
            var idUnidade = idUnidadeTemp.substring(10);

            $("#spanNomeUnidade" + idUnidade).removeClass('glyphicon-ok');

            $("#addUnidade").attr('disabled', true);

            linha.find('input[name*="txtNomeUnidade"]').attr('disabled', false);

            linha.find('.edtRowUnidade').removeClass('edtRowUnidade').removeClass('glyphicon-pencil').addClass('glyphicon-floppy-disk').addClass('saveRowUnidade');
        }
    });

    $("#tblUnidade").on('click', '.saveRowUnidade', function () {
        var linha = $(this).parent().parent();

        var idUnidadeTemp = linha.attr('id');
        var idUnidade = idUnidadeTemp.substring(10);

        var codUnidade = linha.find('input[name*="txtCodUnidade"]').val();
        var nomeUnidade = linha.find('input[name*="txtNomeUnidade"]').val();

        if (codUnidade != "" && nomeUnidade != "") {
            var dataUnidade = JSON.stringify({
                cod: codUnidade,
                nome: nomeUnidade
            });

            $.ajax({  //chama o webmethod para salvar as configs no banco
                type: "POST",
                url: "Default.aspx/SalvarUnidade",
                data: dataUnidade,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (rtn) {
                    if (rtn.d == "True") {
                        linha.find('input[name*="txtCodUnidade"]').attr('disabled', true);
                        linha.find('input[name*="txtNomeUnidade"]').attr('disabled', true);

                        linha.find('.saveRowUnidade').removeClass('saveRowUnidade').removeClass('glyphicon-floppy-disk').addClass('glyphicon-pencil').addClass('edtRowUnidade');

                        $("#spanCodUnidade" + idUnidade).removeClass('glyphicon-remove').addClass('glyphicon-ok').addClass('has-success');
                        $("#spanNomeUnidade" + idUnidade).removeClass('glyphicon-remove').addClass('glyphicon-ok').addClass('has-success');

                        $("#addUnidade").removeAttr('disabled');

                        editandoUnidade = false;
                    }
                    else if (rtn.d == "False") {
                        $('#lblErro').text("Não foi possível salvar! Entre em contato com o suporte!");
                        $('#modalErro').modal('show'); //se explodir exception no no metodo Logar, retorna 
                    }
                    else {
                        $('#lblErro').text("Ocorreu um erro: " + rtn.d + " - Entre em contato com o suporte!");
                        $('#modalErro').modal('show'); //se explodir exception no no metodo Logar, retorna 
                    }
                }
            });
        }
        else {
            $('#lblErro').text("Preencha o(s) campo(s) corretamente!");
            $('#modalErro').modal('show'); //se explodir exception no no metodo Logar, retorna 
        }
    });


    $("#tblUnidade").on('click', '.remRowUnidade', function () {
        if (editandoUnidade) {
            $('#lblErro').text("Conclua a edição para excluir!");
            $('#modalErro').modal('show'); //se explodir exception no no metodo Logar, retorna 
        }
        else {
            var linha = $(this).parent().parent();

            var codUnidade = linha.find('input[name*="txtCodUnidade"]').val();

            var dataUnidade = JSON.stringify({
                cod: codUnidade
            });

            $.ajax({  //chama o webmethod para salvar as configs no banco
                type: "POST",
                url: "Default.aspx/RemUnidade",
                data: dataUnidade,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (rtn) {
                    if (rtn.d == "True") {
                        linha.remove();
                        $("#addUnidade").removeAttr('disabled');
                    }
                    else if (rtn.d == "False1") {
                        linha.remove();
                        $("#addUnidade").removeAttr('disabled');
                    }
                    else if (rtn.d == "False2") {
                        $('#lblErro').text("Não foi possível excluir! Entre em contato com o suporte!");
                        $('#modalErro').modal('show'); //se explodir exception no no metodo Logar, retorna 
                    }
                    else {
                        $('#lblErro').text("Ocorreu um erro: " + rtn.d + " - Entre em contato com o suporte!");
                        $('#modalErro').modal('show'); //se explodir exception no no metodo Logar, retorna 
                    }
                }
            });
        }
    });
});
