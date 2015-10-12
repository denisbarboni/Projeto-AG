$(document).ready(function () {
    var editandoSku = false;

    $("#addSku").click(function () {
        var idSku = "";

        $.ajax({  //chama o webmethod para salvar as configs no banco
            type: "POST",
            url: "Default.aspx/PegarProximoId",
            data: "{ tbl: 'sku'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (rtn) {
                idSku = rtn.d;

                $("#tblSku").append('<tr id="rowSku' + idSku + '"><td style="width:55%; "><div class="form-group has-feedback"><input type="text" id="txtNomeSku' + idSku + '" name="txtNomeSku' + idSku + '" placeholder="Nome do Sku" class="form-control" /><span class="glyphicon form-control-feedback" id="spanNomeSku' + idSku + '"></span></div></td><td style="width:30%; "><div class="form-group has-feedback"><input type="text" id="txtPesoSku' + idSku + '" name="txtPesoSku' + idSku + '" placeholder="Peso do Máquina" class="form-control" /><span class="glyphicon form-control-feedback" id="spanPesoSku' + idSku + '"></span></div></td><td style="width:15%; "><button class="btn btn-primary glyphicon glyphicon-floppy-disk saveRowSku"></button> <button class="btn btn-danger glyphicon glyphicon-remove remRowSku"></button></td></tr>');

                $("#addSku").attr('disabled', true);

                editandoSku = true;
            }
        });
    });

    $("#tblSku").on('click', '.edtRowSku', function () {
        if (editandoSku) {
            $('#lblErro').text("Conclua a edição para editar as demais!");
            $('#modalErro').modal('show'); //se explodir exception no no metodo Logar, retorna 
        }
        else {
            editandoSku = true;

            var linha = $(this).parent().parent();

            var idSkuTemp = linha.attr('id');
            var idSku = idSkuTemp.substring(6);

            $("#spanNomeSku" + idSku).removeClass('glyphicon-ok');
            $("#spanPesoSku" + idSku).removeClass('glyphicon-ok');

            $("#addSku").attr('disabled', true);

            linha.find('input[name*="txtNomeSku"]').attr('disabled', false);
            linha.find('input[name*="txtPesoSku"]').attr('disabled', false);

            linha.find('.edtRowSku').removeClass('edtRowSku').removeClass('glyphicon-pencil').addClass('glyphicon-floppy-disk').addClass('saveRowSku');
        }
    });

    $("#tblSku").on('click', '.saveRowSku', function () {
        var linha = $(this).parent().parent();

        var idSkuTemp = linha.attr('id');
        var idSku = idSkuTemp.substring(6);

        var nomeSku = linha.find('input[name*="txtNomeSku"]').val();
        var pesoSku = linha.find('input[name*="txtPesoSku"]').val();

        if (nomeSku != "" && pesoSku != "") {
            var dataSku = JSON.stringify({
                id: idSku,
                nome: nomeSku,
                peso: pesoSku
            });

            $.ajax({  //chama o webmethod para salvar as configs no banco
                type: "POST",
                url: "Default.aspx/SalvarSku",
                data: dataSku,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (rtn) {
                    if (rtn.d == "True") {
                        linha.find('input[name*="txtNomeSku"]').attr('disabled', true);
                        linha.find('input[name*="txtPesoSku"]').attr('disabled', true);

                        linha.find('.saveRowSku').removeClass('saveRowSku').removeClass('glyphicon-floppy-disk').addClass('glyphicon-pencil').addClass('edtRowSku');

                        $("#spanNomeSku" + idSku).removeClass('glyphicon-remove').addClass('glyphicon-ok').addClass('has-success');
                        $("#spanPesoSku" + idSku).removeClass('glyphicon-remove').addClass('glyphicon-ok').addClass('has-success');

                        $("#addSku").removeAttr('disabled');

                        editandoSku = false;
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


    $("#tblSku").on('click', '.remRowSku', function () {
        if (editandoSku) {
            $('#lblErro').text("Conclua a edição para excluir!");
            $('#modalErro').modal('show'); //se explodir exception no no metodo Logar, retorna 
        }
        else {
            var linha = $(this).parent().parent();

            var idSkuTemp = linha.attr('id');
            var idSku = idSkuTemp.substring(6);

            var dataSku = JSON.stringify({
                id: idSku
            });

            $.ajax({  //chama o webmethod para salvar as configs no banco
                type: "POST",
                url: "Default.aspx/RemSku",
                data: dataSku,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (rtn) {
                    if (rtn.d == "True") {
                        linha.remove();
                        $("#addSku").removeAttr('disabled');
                    }
                    else if (rtn.d == "False1") {
                        linha.remove();
                        $("#addSku").removeAttr('disabled');
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
