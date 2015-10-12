$(document).ready(function () {
    var editandoVelocidade = false;

    $("#addVelocidade").click(function () {
        var idVelocidade = "";

        $.ajax({  //chama o webmethod para salvar as configs no banco
            type: "POST",
            url: "Default.aspx/PegarProximoId",
            data: "{ tbl: 'velocidade'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (rtn) {
                idVelocidade = rtn.d;

                $("#tblVelocidade").append('<tr id="rowVelocidade' + idVelocidade + '"><td><div class="form-group has-feedback"><select id="selVelMaq' + idVelocidade + '" class="form-control"></select><span class="glyphicon form-control-feedback" id="spanVelMaq' + idVelocidade + '"></span></div></td><td><div class="form-group has-feedback"><select id="selVelSetor' + idVelocidade + '" class="form-control"></select><span class="glyphicon form-control-feedback" id="spanVelSetor' + idVelocidade + '"></span></div></td><td><div class="form-group has-feedback"><select id="selVelSku' + idVelocidade + '" class="form-control"></select><span class="glyphicon form-control-feedback" id="spanVelSku' + idVelocidade + '"></span></div></td><td><div class="form-group has-feedback"><input type="text" id="txtVelVelocidade' + idVelocidade + '" name="txtVelVelocidade' + idVelocidade + '" placeholder="Velocidade por hora" class="form-control" /><span class="glyphicon form-control-feedback" id="spanVelVelocidade' + idVelocidade + '"></span></div></td><td style="width:15%; "><button class="btn btn-primary glyphicon glyphicon-floppy-disk saveRowVelocidade"></button> <button class="btn btn-danger glyphicon glyphicon-remove remRowVelocidade"></button></td></tr>');

                $("#addVelocidade").attr('disabled', true);

                editandoVelocidade = true;

                var seletor = "#selVelMaq" + idVelocidade;
                var seletor2 = "#selVelSetor" + idVelocidade;
                var seletor3 = "#selVelSku" + idVelocidade;

                carregarVelMaq(seletor);
                carregarVelSetor(seletor2);
                carregarVelSku(seletor3);
            }
        });
    });

    function carregarVelMaq(seletor) {
        var dataVelocidade = JSON.stringify({
            seletor: seletor
        });

        $.ajax({  //chama o webmethod para salvar as configs no banco
            type: "POST",
            url: "Default.aspx/CarregarSelectVelMaq",
            data: dataVelocidade,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (rtn) {
                $(rtn.d).each(function () {
                    $(seletor).append('<option name=\"selVelMaq\" value="' + this.Id_Maquina + '">' + this.Descricao + '</option>');
                });
            }
        });
    }

    function carregarVelSetor(seletor) {
        var dataVelocidade = JSON.stringify({
            seletor: seletor
        });

        $.ajax({  //chama o webmethod para salvar as configs no banco
            type: "POST",
            url: "Default.aspx/CarregarSelectVelSetor",
            data: dataVelocidade,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (rtn) {
                $(rtn.d).each(function () {
                    $(seletor).append('<option name=\"selVelSetor\" value="' + this.Id_Setor + '">' + this.Descricao + '</option>');
                });
            }
        });
    }

    function carregarVelSku(seletor) {
        var dataVelocidade = JSON.stringify({
            seletor: seletor
        });

        $.ajax({  //chama o webmethod para salvar as configs no banco
            type: "POST",
            url: "Default.aspx/CarregarSelectVelSku",
            data: dataVelocidade,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (rtn) {
                $(rtn.d).each(function() {
                    $(seletor).append('<option name=\"selVelSku\" value="' + this.Id_Sku + '">'+ this.Descricao +'</option>');
                });
            }
        });
    }

    $("#tblVelocidade").on('click', '.edtRowVelocidade', function () {
        if (editandoVelocidade) {
            $('#lblErro').text("Conclua a edição para editar as demais!");
            $('#modalErro').modal('show'); //se explodir exception no no metodo Logar, retorna 
        }
        else {
            editandoVelocidade = true;

            var linha = $(this).parent().parent();

            var idVelocidadeTemp = linha.attr('id');
            var idVelocidade = idVelocidadeTemp.substring(13);

            $("#spanVelMaq" + idVelocidade).removeClass('glyphicon-ok');
            $("#spanVelSetor" + idVelocidade).removeClass('glyphicon-ok');
            $("#spanVelSku" + idVelocidade).removeClass('glyphicon-ok');
            $("#spanVelVelocidade" + idVelocidade).removeClass('glyphicon-ok');

            $("#addVelocidade").attr('disabled', true);

            linha.find('select[id*="selVelMaq"]').attr('disabled', false);
            linha.find('select[id*="selVelSetor"]').attr('disabled', false);
            linha.find('select[id*="selVelSku"]').attr('disabled', false);
            linha.find('input[name*="txtVelVelocidade"]').attr('disabled', false);

            linha.find('.edtRowVelocidade').removeClass('edtRowVelocidade').removeClass('glyphicon-pencil').addClass('glyphicon-floppy-disk').addClass('saveRowVelocidade');
        }
    });

    $("#tblVelocidade").on('click', '.saveRowVelocidade', function () {
        var linha = $(this).parent().parent();

        var idVelocidadeTemp = linha.attr('id');
        var idVelocidade = idVelocidadeTemp.substring(13);

        var selVelMaq = linha.find('select[id*="selVelMaq"]').val();
        var selVelSetor = linha.find('select[id*="selVelSetor"]').val();
        var selVelSku = linha.find('select[id*="selVelSku"]').val();
        var velVelocidade = linha.find('input[name*="txtVelVelocidade"]').val();

        if (selVelMaq != "" && selVelSetor != "" && selVelSku != "" && velVelocidade != "") {
            var dataVelocidade = JSON.stringify({
                idvel: idVelocidade,
                maq: selVelMaq,
                setor: selVelSetor,
                sku: selVelSku,
                vel: velVelocidade
            });

            $.ajax({  //chama o webmethod para salvar as configs no banco
                type: "POST",
                url: "Default.aspx/SalvarVelocidade",
                data: dataVelocidade,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (rtn) {
                    if (rtn.d == "True") {
                        linha.find('select[id*="selVelMaq"]').attr('disabled', true);
                        linha.find('select[id*="selVelSetor"]').attr('disabled', true);
                        linha.find('select[id*="selVelSku"]').attr('disabled', true);
                        linha.find('input[name*="txtVelVelocidade"]').attr('disabled', true);

                        linha.find('.saveRowVelocidade').removeClass('saveRowVelocidade').removeClass('glyphicon-floppy-disk').addClass('glyphicon-pencil').addClass('edtRowVelocidade');

                        $("#spanVelMaq" + idVelocidade).removeClass('glyphicon-remove').addClass('glyphicon-ok').addClass('has-success');
                        $("#spanVelSetor" + idVelocidade).removeClass('glyphicon-remove').addClass('glyphicon-ok').addClass('has-success');
                        $("#spanVelSku" + idVelocidade).removeClass('glyphicon-remove').addClass('glyphicon-ok').addClass('has-success');
                        $("#spanVelVelocidade" + idVelocidade).removeClass('glyphicon-remove').addClass('glyphicon-ok').addClass('has-success');

                        $("#addVelocidade").removeAttr('disabled');

                        editandoVelocidade = false;
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


    $("#tblVelocidade").on('click', '.remRowVelocidade', function () {
        if (editandoVelocidade) {
            $('#lblErro').text("Conclua a edição para excluir!");
            $('#modalErro').modal('show'); //se explodir exception no no metodo Logar, retorna 
        }
        else {
            var linha = $(this).parent().parent();

            var idVelocidadeTemp = linha.attr('id');
            var idVelocidade = idVelocidadeTemp.substring(13);

            var dataVelocidade = JSON.stringify({
                id: idVelocidade
            });

            $.ajax({  //chama o webmethod para salvar as configs no banco
                type: "POST",
                url: "Default.aspx/RemVelocidade",
                data: dataVelocidade,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (rtn) {
                    if (rtn.d == "True") {
                        linha.remove();
                        $("#addVelocidade").removeAttr('disabled');
                    }
                    else if (rtn.d == "False1") {
                        linha.remove();
                        $("#addVelocidade").removeAttr('disabled');
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
