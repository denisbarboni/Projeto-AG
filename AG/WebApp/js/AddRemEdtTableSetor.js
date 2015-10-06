$(document).ready(function () {
    var editandoSetor = false;

    $("#addSetor").click(function () {
        var idSetor = "";

        $.ajax({  //chama o webmethod para salvar as configs no banco
            type: "POST",
            url: "Default.aspx/PegarProximoId",
            data: "{ tbl: 'setor'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (rtn) {
                idSetor = rtn.d;

                $("#tblSetor").append('<tr id="rowSetor' + idSetor + '"><td style="width:85%; "><div class="form-group has-feedback"><input type="text" id="txtNomeSetor' + idSetor + '" name="txtNomeSetor' + idSetor + '" placeholder="Nome do Setor" class="form-control" /><span class="glyphicon form-control-feedback" id="spanNomeSetor' + idSetor + '"></span></div></td><td style="width:15%; "><button class="btn btn-primary glyphicon glyphicon-floppy-disk saveRowSetor"></button> <button class="btn btn-danger glyphicon glyphicon-remove remRowSetor"></button></td></tr>');

                $("#addSetor").attr('disabled', true);

                editandoSetor = true;
            }
        });
    });

    $("#tblSetor").on('click', '.edtRowSetor', function () {
        if (editandoSetor) {
            $('#lblErro').text("Conclua a edição para editar as demais!");
            $('#modalErro').modal('show'); //se explodir exception no no metodo Logar, retorna 
        }
        else {
            editandoSetor = true;

            var linha = $(this).parent().parent();

            var idSetorTemp = linha.attr('id');
            var idSetor = idSetorTemp.substring(8);

            $("#spanNomeSetoruina" + idSetor).removeClass('glyphicon-ok');

            $("#addSetor").attr('disabled', true);

            linha.find('input[name*="txtNomeSetor"]').attr('disabled', false);

            linha.find('.edtRowSetor').removeClass('edtRowSetor').removeClass('glyphicon-pencil').addClass('glyphicon-floppy-disk').addClass('saveRowSetor');
        }
    });

    $("#tblSetor").on('click', '.saveRowSetor', function () {
        var linha = $(this).parent().parent();

        var idSetorTemp = linha.attr('id');
        var idSetor = idSetorTemp.substring(8);

        var nomeSetor = linha.find('input[name*="txtNomeSetor"]').val();

        if (nomeSetor != "") {
            var dataSetor = JSON.stringify({
                id: idSetor,
                nome: nomeSetor
            });

            $.ajax({  //chama o webmethod para salvar as configs no banco
                type: "POST",
                url: "Default.aspx/SalvarSetor",
                data: dataSetor,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (rtn) {
                    if (rtn.d == "True") {
                        linha.find('input[name*="txtNomeSetor"]').attr('disabled', true);

                        linha.find('.saveRowSetor').removeClass('saveRowSetor').removeClass('glyphicon-floppy-disk').addClass('glyphicon-pencil').addClass('edtRowSetor');

                        $("#spanNomeSetor" + idSetor).removeClass('glyphicon-remove').addClass('glyphicon-ok').addClass('has-success');

                        $("#addSetor").removeAttr('disabled');

                        editandoSetor = false;
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


    $("#tblSetor").on('click', '.remRowSetor', function () {
        if (editandoSetor) {
            $('#lblErro').text("Conclua a edição para excluir!");
            $('#modalErro').modal('show'); //se explodir exception no no metodo Logar, retorna 
        }
        else {
            var linha = $(this).parent().parent();

            var idSetorTemp = linha.attr('id');
            var idSetor = idSetorTemp.substring(8);

            var dataSetor = JSON.stringify({
                id: idSetor
            });

            $.ajax({  //chama o webmethod para salvar as configs no banco
                type: "POST",
                url: "Default.aspx/RemSetor",
                data: dataSetor,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (rtn) {
                    if (rtn.d == "True") {
                        linha.remove();
                        $("#addSetor").removeAttr('disabled');
                    }
                    else if (rtn.d == "False1") {
                        linha.remove();
                        $("#addSetor").removeAttr('disabled');
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