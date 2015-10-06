$(document).ready(function () {
    var editandoMaq = false;

    $("#addMaq").click(function () {
        var idMaq = "";

        $.ajax({  //chama o webmethod para salvar as configs no banco
            type: "POST",
            url: "Default.aspx/PegarProximoId",
            data: "{ tbl: 'maquina'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (rtn) {
                idMaq = rtn.d;

                $("#tblMaquina").append('<tr id="rowMaq' + idMaq + '"><td style="width:85%; "><div class="form-group has-feedback"><input type="text" id="txtNomeMaquina' + idMaq + '" name="txtNomeMaquina' + idMaq + '" placeholder="Nome da Máquina" class="form-control" /><span class="glyphicon form-control-feedback" id="spanNomeMaquina' + idMaq + '"></span></div></td><td style="width:15%; "><button class="btn btn-primary glyphicon glyphicon-floppy-disk saveRowMaq"></button> <button class="btn btn-danger glyphicon glyphicon-remove remRowMaq"></button></td></tr>');

                $("#addMaq").attr('disabled', true);

                editandoMaq = true;
            }
        });
    });

    $("#tblMaquina").on('click', '.edtRowMaq', function () {
        if (editandoMaq) {
            $('#lblErro').text("Conclua a edição para editar as demais!");
            $('#modalErro').modal('show'); //se explodir exception no no metodo Logar, retorna 
        }
        else {
            editandoMaq = true;

            var linha = $(this).parent().parent();

            var idMaqTemp = linha.attr('id');
            var idMaq = idMaqTemp.substring(6);

            $("#spanNomeMaquina" + idMaq).removeClass('glyphicon-ok');

            $("#addMaq").attr('disabled', true);

            linha.find('input[name*="txtNomeMaq"]').attr('disabled', false);

            linha.find('.edtRowMaq').removeClass('edtRowMaq').removeClass('glyphicon-pencil').addClass('glyphicon-floppy-disk').addClass('saveRowMaq');
        }
    });

    $("#tblMaquina").on('click', '.saveRowMaq', function () {
        var linha = $(this).parent().parent();

        var idMaqTemp = linha.attr('id');
        var idMaq = idMaqTemp.substring(6);

        var nomeMaq = linha.find('input[name*="txtNomeMaq"]').val();

        if (nomeMaq != "") {
            var dataMaq = JSON.stringify({
                id: idMaq,
                nome: nomeMaq
            });

            $.ajax({  //chama o webmethod para salvar as configs no banco
                type: "POST",
                url: "Default.aspx/SalvarMaq",
                data: dataMaq,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (rtn) {
                    if (rtn.d == "True") {
                        linha.find('input[name*="txtNomeMaq"]').attr('disabled', true);

                        linha.find('.saveRowMaq').removeClass('saveRowMaq').removeClass('glyphicon-floppy-disk').addClass('glyphicon-pencil').addClass('edtRowMaq');

                        $("#spanNomeMaquina" + idMaq).removeClass('glyphicon-remove').addClass('glyphicon-ok').addClass('has-success');

                        $("#addMaq").removeAttr('disabled');

                        editandoMaq = false;
                        addMaq = false;
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


    $("#tblMaquina").on('click', '.remRowMaq', function () {
        if (editandoMaq) {
            $('#lblErro').text("Conclua a edição para excluir!");
            $('#modalErro').modal('show'); //se explodir exception no no metodo Logar, retorna 
        }
        else {
            var linha = $(this).parent().parent();

            var idMaqTemp = linha.attr('id');
            var idMaq = idMaqTemp.substring(6);

            var dataMaq = JSON.stringify({
                id: idMaq
            });

            $.ajax({  //chama o webmethod para salvar as configs no banco
                type: "POST",
                url: "Default.aspx/RemMaq",
                data: dataMaq,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (rtn) {
                    if (rtn.d == "True") {
                        linha.remove();
                        $("#addMaq").removeAttr('disabled');
                    }
                    else if (rtn.d == "False1") {
                        linha.remove();
                        $("#addMaq").removeAttr('disabled');
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