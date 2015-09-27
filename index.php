<?php include_once "topo.php" ?>

<div class="cover-image" style="background-image:url(_img/bg-working.jpg)"></div>
<div class="container">
    <div class="row">
        <div class="col-md-12 text-center">
            <h1 class="text-inverse">Heading</h1>
            <p class="text-inverse">Lorem ipsum dolor sit amet, consectetur adipisici eli.</p>
            <br>
            <br>
            <script type="text/javascript">
                function cadastro()
                {
                    location.href="cadastro.php"
                }
            </script>
            <button class="btn btn-danger" onclick="cadastro();">
                Cadastre - se
            </button>
            <button class="btn btn-primary" data-toggle="modal" data-target="#myModal">
                Entrar
            </button>

            <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">

                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                            <h4 class="modal-title" id="myModalLabel">Log in</h4>
                        </div> <!-- /.modal-header -->

                        <div class="modal-body">
                            <form role="form">
                                <div class="form-group">
                                    <div class="input-group">
                                        <input type="text" class="form-control" id="uLogin" placeholder="Login">
                                        <label for="uLogin" class="input-group-addon glyphicon glyphicon-user"></label>
                                    </div>
                                </div> <!-- /.form-group -->

                                <div class="form-group">
                                    <div class="input-group">
                                        <input type="password" class="form-control" id="uPassword" placeholder="Senha">
                                        <label for="uPassword" class="input-group-addon glyphicon glyphicon-lock"></label>
                                    </div> <!-- /.input-group -->
                                </div> <!-- /.form-group -->

                                <div class="checkbox">
                                    <label>
                                        <input type="checkbox"> Lembrar me
                                    </label>
                                </div> <!-- /.checkbox -->
                            </form>

                        </div> <!-- /.modal-body -->

                        <div class="modal-footer">
                            <button class="form-control btn btn-primary">Ok</button>

                            <div class="progress">
                                <div class="progress-bar progress-bar-primary" role="progressbar" aria-valuenow="1" aria-valuemin="1" aria-valuemax="100" style="width: 0%;">
                                    <span class="sr-only">progress</span>
                                </div>
                            </div>
                        </div> <!-- /.modal-footer -->

                    </div><!-- /.modal-content -->
                </div><!-- /.modal-dialog -->
            </div><!-- /.modal -->
        </div>
    </div>
</div>
</div>
<div class="section">
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <img src="http://pingendo.github.io/pingendo-bootstrap/assets/placeholder.png"
                     class="img-responsive">
            </div>
            <div class="col-md-6">
                <h1 class="text-primary">A title</h1>
                <h3>A subtitle</h3>
                <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo
                    ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis
                    dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies
                    nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim.
                    Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In
                    enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum
                    felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus
                    elementum semper nisi.</p>
            </div>
        </div>
    </div>
</div>
<div class="section">
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <h1 class="text-primary">A title</h1>
                <h3>A subtitle</h3>
                <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo
                    ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis
                    dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies
                    nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim.
                    Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In
                    enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum
                    felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus
                    elementum semper nisi.</p>
            </div>
            <div class="col-md-6">
                <img src="http://pingendo.github.io/pingendo-bootstrap/assets/placeholder.png"
                     class="img-responsive">
            </div>
        </div>
    </div>
</div>

</body>

</html>