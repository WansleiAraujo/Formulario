<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Formulario.Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Formulário de Cadastro</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="Style/lib/bootstrap/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="Style/css/site.css" />
</head>
<body>
    <header>
        <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
            <div class="container">
                <a class="navbar-brand  text-info" asp-area="Default.aspx" asp-page="Default.aspx" href="Default.aspx">FORMULÁRIO</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                    aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse">
                    <ul class="navbar-nav flex-grow-1">
                        <li class="nav-item">
                            <a class="nav-link text-dark" asp-area="" asp-page="Cliente.aspx" href="Cliente.aspx">Cadastro</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link text-dark" asp-area="" asp-page="ListaCliente.aspx" href="Cliente.aspx">Lista de Clientes</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link text-dark" asp-area="" asp-page="Default.aspx" href="Default.aspx">Sair</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    </header>

    <div class="container">
        <form id="form1" runat="server">
            <main role="main" class="pb-3">
                <div class="container">
                    <div class="row">
                        <div class="col-12 text-center my-2" >
                            <h1 class="display-6" style="margin-top:100px">Formulário de cadastramento de clientes</h1>
                            <i class="fas-clipboard-list-check"></i>
                        </div>
                    </div>
                </div>      
            </main>
        </form>
    </div>

    <footer class="border-top footer text-muted">
        <div class="container">
            &copy;
            <asp:Literal ID="lblAno" runat="server"></asp:Literal>
            <a href="http://www.wansleiaraujo.com">| Wanslei Araujo</a>
        </div>
    </footer>

    <script src="Style/lib/jquery/dist/jquery.min.js"></script>
    <script src="Style/lib/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
    <script src="Style/js/site.js" asp-append-version="true"></script>
</body>
</html>
