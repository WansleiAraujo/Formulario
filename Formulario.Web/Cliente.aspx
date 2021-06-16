<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="Formulario.Web.Cliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Formulário de Cadastro</title>
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
        function ChecarEmail() {
            if (document.forms[0].email.value == ""
                || document.forms[0].email.value.indexOf('@') == -1
                || document.forms[0].email.value.indexOf('.') == -1) {
                alert("Por favor, informe um E-MAIL válido!");
                return false;
            }
        }
        function IsEmail(email) {
            var exclude = /[^@-.w]|^[_@.-]|[._-]{2}|[@.]{2}|(@)[^@]*1/;
            var check = /@[w-]+./;
            var checkend = /.[a-zA-Z]{2,3}$/;
            if (((email.search(exclude) != -1) || (email.search(check)) == -1) || (email.search(checkend) == -1)) { return false; }
            else { return true; }
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
                            <a class="nav-link text-info" asp-area="" asp-page="Cliente.aspx" href="Cliente.aspx">Cadastro</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link text-dark" asp-area="" asp-page="ListaCliente.aspx" href="ListaCliente.aspx">Lista de Clientes</a>
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
        <asp:Panel ID="PanelCliente" runat="server">
            <div class="container" id="cliente">
                <main role="main" class="pb-3">
                    <div class="container">
                        <div class="row">
                            <div class="col-12 text-center my-2">
                                <h2 class="display-6">Cadastro/Alteração de Cliente</h2>
                                <i class="fas-clipboard-list-check"></i>
                            </div>
                        </div>
                    </div>
                    <div class="container my-5">
                        <div class="form-group">
                            <asp:TextBox ID="txtNome" runat="server" class="form-control" type="cliente" placeholder="Informe o nome do cliente (obrigatório)" onkeyup="upper(this)" MaxLength="100" TabIndex="1"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtCpf" runat="server" class="form-control" type="cliente" placeholder="Informe o CPF do cliente (obrigatório)" onkeypress="Cpf(event, this)" MaxLength="15" TabIndex="2"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtEmail" runat="server" class="form-control" type="cliente" placeholder="Informe o email do cliente (obrigatório)" onkeyup="IsEmail(this)" MaxLength="100" TabIndex="3"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <div class="form-group" style="float: left; margin-right: 10px">
                                <asp:TextBox ID="txtCep" runat="server" class="form-control" type="cliente" placeholder="Informe o CEP do cliente" onkeypress="Cep(event, this)" MaxLength="10" TabIndex="4"></asp:TextBox>
                            </div>
                            <div class="form-group" style="float: left; margin-right: 10px">
                                <asp:Button ID="btnPesquisarCep" runat="server" Text="Pesquisar" class="btn btn-primary" OnClick="btnPesquisarCep_Click" Visible="True" TabIndex="5"></asp:Button>
                            </div>
                            <div class="form-group" style="float: left">
                                <asp:Label ID="lblValidaCep" runat="server" Text="" class="form-text text-muted"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtRua" runat="server" class="form-control" type="cliente" placeholder="Informe a rua" onkeyup="upper(this)" MaxLength="100" TabIndex="6"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtNumero" runat="server" class="form-control" type="cliente" placeholder="Informe o número" onkeyup="upper(this)" MaxLength="50" TabIndex="7"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtCidade" runat="server" class="form-control" type="cliente" placeholder="Informe a cidade" onkeyup="upper(this)" MaxLength="50" TabIndex="8"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ddlEstado" runat="server" class="form-control" placeholder="Selecione um Estado" type="mensagem" TabIndex="9">
                                <asp:ListItem Value="0">Selecione um Estado</asp:ListItem>
                                <asp:ListItem Value="1">Acre</asp:ListItem>
                                <asp:ListItem Value="2">Alagoas</asp:ListItem>
                                <asp:ListItem Value="3">Amapá</asp:ListItem>
                                <asp:ListItem Value="4">Amazonas</asp:ListItem>
                                <asp:ListItem Value="5">Bahia</asp:ListItem>
                                <asp:ListItem Value="6">Ceará</asp:ListItem>
                                <asp:ListItem Value="7">Distrito Federal</asp:ListItem>
                                <asp:ListItem Value="8">Espírito Santo</asp:ListItem>
                                <asp:ListItem Value="9">Goiás</asp:ListItem>
                                <asp:ListItem Value="10">Maranhão</asp:ListItem>
                                <asp:ListItem Value="11">Mato Grosso</asp:ListItem>
                                <asp:ListItem Value="12">Mato Grosso do Sul</asp:ListItem>
                                <asp:ListItem Value="13">Minas Gerais</asp:ListItem>
                                <asp:ListItem Value="14">Pará</asp:ListItem>
                                <asp:ListItem Value="15">Paraíba</asp:ListItem>
                                <asp:ListItem Value="16">Paraná</asp:ListItem>
                                <asp:ListItem Value="17">Pernambuco</asp:ListItem>
                                <asp:ListItem Value="18">Piauí</asp:ListItem>
                                <asp:ListItem Value="19">Rio de Janeiro</asp:ListItem>
                                <asp:ListItem Value="20">Rio Grande do Norte</asp:ListItem>
                                <asp:ListItem Value="21">Rio Grande do Sul</asp:ListItem>
                                <asp:ListItem Value="22">Rondônia</asp:ListItem>
                                <asp:ListItem Value="23">Roraima</asp:ListItem>
                                <asp:ListItem Value="24">Santa Catarina</asp:ListItem>
                                <asp:ListItem Value="25">São Paulo</asp:ListItem>
                                <asp:ListItem Value="26">Sergipe</asp:ListItem>
                                <asp:ListItem Value="27">Tocantins</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblValida" runat="server" Text="" class="form-text text-muted"></asp:Label>
                        <asp:Label ID="lblEnvioMsg" runat="server" Text="" class="form-text text-muted"></asp:Label>
                    </div>
                    <div class="form-group" style="float: left; margin-right: 10px">
                        <asp:Button ID="btnCadastrarTelefone" runat="server" Text="Novo Telefone" class="btn btn-primary" Visible="False" TabIndex="10" OnClick="btnCadastrarTelefone_Click"></asp:Button>
                    </div>
                    <div class="form-group" style="float: left; margin-right: 10px">
                        <asp:Button ID="btnCadastrar" runat="server" Text="Salvar" class="btn btn-primary"
                            OnClick="btnCadastrar_Click" Visible="True" TabIndex="11"></asp:Button>
                    </div>
                    <div class="form-group" style="float: left">
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-primary" TabIndex="12" OnClick="btnCancelar_Click"></asp:Button>
                    </div>

                </main>
            </div>
        </asp:Panel>
        <asp:Panel ID="PanelListaTelefones" runat="server" Visible="false">
            <main role="main" class="pb-3">
                <div class="container my-5">
                    <div class="form-group">

                        <div style="margin-top: 10px; text-align: left">
                            <asp:GridView ID="gridTelefone" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4" GridLines="None" PageSize="5"
                                AllowPaging="True" ForeColor="#333333">
                                <AlternatingRowStyle CssClass="linhaAlterada" BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:BoundField DataField="IdTelefone" HeaderText="IdTelefone" Visible="False" />
                                    <asp:BoundField DataField="TipoTelefone" HeaderText="Telefone" />
                                    <asp:BoundField DataField="NumeroTelefone" HeaderText="N.º Telefone" />
                                    <asp:TemplateField HeaderText="Visualizar">
                                        <ItemTemplate>
                                            <a href="Telefone.aspx?id=<%# Eval("IdTelefone") %>">
                                                <asp:Image runat="server" ImageUrl="~/imgs/magnifier.png" />
                                            </a>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <EmptyDataTemplate>
                                    NÃO HÁ TELEFONES CADASTRADOS.
                                </EmptyDataTemplate>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                            <div style="display: none"></div>
                        </div>
                    </div>
                </div>
            </main>
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
