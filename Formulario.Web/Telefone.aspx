<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Telefone.aspx.cs" Inherits="Formulario.Web.Telefone" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Formulário Cliente</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="Style/lib/bootstrap/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="Style/css/site.css" />
    <script type="text/javascript">
        function upper(ustr) {
            var str = ustr.value;
            ustr.value = str.toUpperCase();
        }
        function Telefone(evento, objeto) {
            var keypress = (window.event) ? event.keyCode : evento.which;
            campo = eval(objeto);
            if (campo.value == '(00)0000-0000') {
                campo.value = ""
            }

            caracteres = '0123456789';
            separacao1 = '(';
            separacao2 = ')';
            separacao3 = '-';

            conjunto01 = 2;
            conjunto02 = 8;
            conjunto03 = 13;

            if ((caracteres.search(String.fromCharCode(keypress)) != -1) && campo.value.length < (13)) {
                if (campo.value.length == conjunto01)
                    campo.value = separacao1 + campo.value + separacao2;
                else if (campo.value.length == conjunto02)
                    campo.value = campo.value + separacao3;
                else if (campo.value.length == conjunto03)
                    campo.value = campo.value;
            }
            else
                event.returnValue = false;
        }
        function Celular(evento, objeto) {
            var keypress = (window.event) ? event.keyCode : evento.which;
            campo = eval(objeto);
            if (campo.value == '(00)00000-0000') {
                campo.value = ""
            }

            caracteres = '0123456789';
            separacao1 = '(';
            separacao2 = ')';
            separacao3 = '-';

            conjunto01 = 2;
            conjunto02 = 9;
            conjunto03 = 14;

            if ((caracteres.search(String.fromCharCode(keypress)) != -1) && campo.value.length < (14)) {
                if (campo.value.length == conjunto01)
                    campo.value = separacao1 + campo.value + separacao2;
                else if (campo.value.length == conjunto02)
                    campo.value = campo.value + separacao3;
                else if (campo.value.length == conjunto03)
                    campo.value = campo.value;
            }
            else
                event.returnValue = false;
        }
        function Cpf(evento, objeto) {
            var keypress = (window.event) ? event.keyCode : evento.which;
            campo = eval(objeto);
            if (campo.value == '000.000.000-00') {
                campo.value = ""
            }

            caracteres = '0123456789';

            separacao11 = '.';
            separacao12 = '-';

            conjunto0001 = 3;
            conjunto0002 = 7;
            conjunto0003 = 11;
            conjunto0004 = 14;

            if ((caracteres.search(String.fromCharCode(keypress)) != -1) && campo.value.length < (14)) {
                if (campo.value.length == conjunto0001)
                    campo.value = campo.value + separacao11;
                else if (campo.value.length == conjunto0002)
                    campo.value = campo.value + separacao11;
                else if (campo.value.length == conjunto0003)
                    campo.value = campo.value + separacao12;
                else if (campo.value.length == conjunto0004)
                    campo.value = campo.value;
            }
            else
                event.returnValue = false;
        }
        function Cep(evento, objeto) {
            var keypress = (window.event) ? event.keyCode : evento.which;
            campo = eval(objeto);
            if (campo.value == '00.000-000') {
                campo.value = ""
            }

            caracteres = '0123456789';

            separacao110 = '.';
            separacao120 = '-';

            conjunto0001 = 2;
            conjunto0002 = 6;
            conjunto0003 = 10;

            if ((caracteres.search(String.fromCharCode(keypress)) != -1) && campo.value.length < (10)) {
                if (campo.value.length == conjunto0001)
                    campo.value = campo.value + separacao110;
                else if (campo.value.length == conjunto0002)
                    campo.value = campo.value + separacao120;
                else if (campo.value.length == conjunto0003)
                    campo.value = campo.value;
            }
            else
                event.returnValue = false;
        }
    </script>
</head>
<body>
    <header>
        <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
            <div class="container">
                <a class="navbar-brand" asp-area="Default.aspx" asp-page="Default.aspx" href="Default.aspx">FORMULÁRIO</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                    aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse">
                    <ul class="navbar-nav flex-grow-1">
                        <li class="nav-item">
                            <a class="nav-link text-dark" asp-area="" asp-page="Cliente.aspx" href="Cliente.aspx">Cliente</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link text-dark" asp-area="" asp-page="Default.aspx" href="Default.aspx">Sair</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    </header>
    <form id="form1" runat="server">
        <asp:Panel ID="PanelTelefone" runat="server">
            <div class="container" id="telefone">
                <main role="main" class="pb-3">
                    <div class="container">
                        <div class="row">
                            <div class="col-12 text-center my-2">
                                <h1 id="TitCadTelefone" class="display-3">Cadastro/Alteração Telefone</h1>
                                <i class="fas-clipboard-list-check"></i>
                            </div>
                        </div>
                    </div>
                    <div class="container my-5">
                        <div class="form-group">
                            <asp:DropDownList ID="ddlTipoTelefone" runat="server" class="form-control col-4" placeholder="Selecione o tipo de telefone *"
                                type="mensagem" TabIndex="1">
                                <asp:ListItem Value="0" Selected="True">Selecione o tipo</asp:ListItem>
                                <asp:ListItem Value="1">Fixo</asp:ListItem>
                                <asp:ListItem Value="2">Celular</asp:ListItem>
                                <asp:ListItem Value="3">Comercial</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtTelefone" runat="server" class="form-control" type="telefone" placeholder="Informe o telefone *" onkeypress="Telefone(event, this)" MaxLength="50" TabIndex="2"></asp:TextBox>
                        </div>

                        <asp:Button ID="btnCadastrarTelefone" runat="server" Text="Salvar" class="btn btn-primary" OnClick="btnCadastrarTelefone_Click" TabIndex="3"></asp:Button>
                        <asp:Label ID="lblValidaTelefone" runat="server" Text="" class="form-text text-muted"></asp:Label>
                        <asp:Label ID="lblEnvioMsgTelefone" runat="server" Text="" class="form-text text-muted"></asp:Label>
                    </div>
                </main>
            </div>
        </asp:Panel>

        <footer class="border-top footer text-muted">
            <div class="container">
                &copy;
            <asp:Literal ID="lblAno" runat="server"></asp:Literal>
                <a href="http://www.wansleiaraujo.com">| Wanslei Araujo</a>
            </div>
        </footer>

    </form>
    <script src="Style/lib/jquery/dist/jquery.min.js"></script>
    <script src="Style/lib/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
    <script src="Style/js/site.js" asp-append-version="true"></script>
</body>
</html>
