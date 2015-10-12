$(document).ready(function () {
    var editandoJob = false;

    $("#addJob").click(function () {
        var idJob = "";

        $.ajax({  //chama o webmethod para salvar as configs no banco
            type: "POST",
            url: "Default.aspx/PegarProximoId",
            data: "{ tbl: 'job'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (rtn) {
                idJob = rtn.d;

                $("#tblJob").append('<tr id="rowJob' + idJob + '"><td><div class="form-group has-feedback"><select id="selJobSku' + idJob + '" class="form-control"></select><span class="glyphicon form-control-feedback" id="spanJobSku' + idJob + '"></span></div></td><td><div class="form-group has-feedback"><input type="text" id="txtQtdeJob' + idJob + '" name="txtQtdeJob' + idJob + '" placeholder="Quantidade da Job" class="form-control" /><span class="glyphicon form-control-feedback" id="spanQtdeJob' + idJob + '"></span></div></td><td style="width:15%; "><button class="btn btn-primary glyphicon glyphicon-floppy-disk saveRowJob"></button> <button class="btn btn-danger glyphicon glyphicon-remove remRowJob"></button></td></tr>');

                $("#addJob").attr('disabled', true);

                editandoJob = true;

                var seletor = "#selJobSku" + idJob;

                carregarSelectJob(seletor);
            }
        });
    });

    function carregarSelectJob(seletor) {
        var dataJob = JSON.stringify({
            seletor: seletor
        });

        $.ajax({  //chama o webmethod para salvar as configs no banco
            type: "POST",
            url: "Default.aspx/CarregarSelectSkuJob",
            data: dataJob,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (rtn) {
                $(rtn.d).each(function() {
                    $(seletor).append('<option name=\"selJobSku\" value="' + this.Id_Sku + '">'+ this.Descricao +'</option>');
                });
            }
        });
    }

    $("#tblJob").on('click', '.edtRowJob', function () {
        if (editandoJob) {
            $('#lblErro').text("Conclua a edição para editar as demais!");
            $('#modalErro').modal('show'); //se explodir exception no no metodo Logar, retorna 
        }
        else {
            editandoJob = true;

            var linha = $(this).parent().parent();

            var idJobTemp = linha.attr('id');
            var idJob = idJobTemp.substring(6);

            $("#spanJobSku" + idJob).removeClass('glyphicon-ok');
            $("#spanQtdeJob" + idJob).removeClass('glyphicon-ok');

            $("#addJob").attr('disabled', true);

            linha.find('select[id*="selJobSku"]').attr('disabled', false);
            linha.find('input[name*="txtQtdeJob"]').attr('disabled', false);

            linha.find('.edtRowJob').removeClass('edtRowJob').removeClass('glyphicon-pencil').addClass('glyphicon-floppy-disk').addClass('saveRowJob');
        }
    });

    $("#tblJob").on('click', '.saveRowJob', function () {
        var linha = $(this).parent().parent();

        var idJobTemp = linha.attr('id');
        var idJob = idJobTemp.substring(6);

        var selJob = linha.find('select[id*="selJobSku"]').val();
        var qtdeJob = linha.find('input[name*="txtQtdeJob"]').val();

        if (selJob != "" && qtdeJob != "") {
            var dataJob = JSON.stringify({
                idjob: idJob,
                idsku: selJob,
                qtde: qtdeJob
            });

            $.ajax({  //chama o webmethod para salvar as configs no banco
                type: "POST",
                url: "Default.aspx/SalvarJob",
                data: dataJob,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (rtn) {
                    if (rtn.d == "True") {
                        linha.find('select[id*="selJobSku"]').attr('disabled', true);
                        linha.find('input[name*="txtQtdeJob"]').attr('disabled', true);

                        linha.find('.saveRowJob').removeClass('saveRowJob').removeClass('glyphicon-floppy-disk').addClass('glyphicon-pencil').addClass('edtRowJob');

                        $("#spanJobSku" + idJob).removeClass('glyphicon-remove').addClass('glyphicon-ok').addClass('has-success');
                        $("#spanQtdeJob" + idJob).removeClass('glyphicon-remove').addClass('glyphicon-ok').addClass('has-success');

                        $("#addJob").removeAttr('disabled');

                        editandoJob = false;
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


    $("#tblJob").on('click', '.remRowJob', function () {
        if (editandoJob) {
            $('#lblErro').text("Conclua a edição para excluir!");
            $('#modalErro').modal('show'); //se explodir exception no no metodo Logar, retorna 
        }
        else {
            var linha = $(this).parent().parent();

            var idJobTemp = linha.attr('id');
            var idJob = idJobTemp.substring(6);

            var dataJob = JSON.stringify({
                id: idJob
            });

            $.ajax({  //chama o webmethod para salvar as configs no banco
                type: "POST",
                url: "Default.aspx/RemJob",
                data: dataJob,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (rtn) {
                    if (rtn.d == "True") {
                        linha.remove();
                        $("#addJob").removeAttr('disabled');
                    }
                    else if (rtn.d == "False1") {
                        linha.remove();
                        $("#addJob").removeAttr('disabled');
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
