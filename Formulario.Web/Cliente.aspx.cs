using System;
using System.Text.RegularExpressions;
using Formulario.Negocio;

namespace Formulario.Web
{
    public partial class Cliente : System.Web.UI.Page
    {
        VO.Telefone telefone = new VO.Telefone();
        VO.Cliente cliente = new Formulario.VO.Cliente();
        TelefoneNegocio telNeg = new TelefoneNegocio();
        ClienteNegocio cliNeg = new ClienteNegocio();

        private Int32 IdCliente;
        private bool camposInformados;

        public int IdViewState
        {
            get
            {
                if (ViewState["valor"] != null)
                    return Convert.ToInt32(ViewState["valor"]);
                return 0;
            }
            set
            {
                ViewState["valor"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Carrega Ano atua para as Paginas
            lblAno.Text = DateTime.Now.ToString("yyyy ");

            if (!IsPostBack)
            {
                try
                {
                    IdViewState = Convert.ToInt32(Request.QueryString["id"]);
                    if (IdViewState != 0)
                        CarregarClienteId(IdViewState);
                }
                catch (Exception)
                {
                    Voltar();
                }
            }
        }

        private void Voltar()
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdViewState == 0)
                {
                    if (txtNome.Text != "" && txtCpf.Text != "" && txtEmail.Text != "")
                    {
                        if (ValidarEmail(txtEmail.Text))
                            camposInformados = true;
                        else
                        {
                            lblValida.Text = "Email inválido.";
                            return;
                        }


                    }
                    else
                    {
                        lblValida.Text = "Verifique os campos obrigatórios.";
                    }

                    if (camposInformados == true)
                    {
                        CarregarCliente(txtCpf.Text);
                        if (IdCliente == 0)
                        {
                            GravarCliente();

                            HabilitaPanel();
                            CarregarCliente(txtCpf.Text);
                        }
                        else
                        {
                            lblValida.Text = "Cliente já cadastrado!";
                        }
                    }
                }
                else
                {
                    if (txtNome.Text != "" && txtCpf.Text != "" && txtEmail.Text != "")
                    {
                        if (ValidarEmail(txtEmail.Text))
                            camposInformados = true;
                        else
                        {
                            lblValida.Text = "Email inválido.";
                            return;
                        }
                    }
                    else
                    {
                        lblValida.Text = "Verifique os campos obrigatórios.";
                    }

                    if (camposInformados == true)
                    {
                        if (IdViewState != 0)
                        {
                            GravarCliente();
                            HabilitaPanel();
                            CarregarCliente(txtCpf.Text);
                        }
                        else
                        {
                            lblValida.Text = "Cliente já cadastrado!";
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CarregarCliente(string cpf)
        {
            VO.Cliente cliente = new VO.Cliente();
            cliente.Cpf = cpf;

            VO.Cliente ClienteRecuperado = new VO.Cliente();
            ClienteRecuperado = cliNeg.RecuperarCpf(cliente);

            if (ClienteRecuperado == null)
                IdCliente = 0;
            else
                IdCliente = ClienteRecuperado.IdCliente;

            CarregarGrid();
        }

        private void CarregarClienteId(Int32 Id)
        {
            VO.Cliente cliente = new VO.Cliente();
            cliente.IdCliente = Id;

            VO.Cliente ClienteRecuperado = new VO.Cliente();
            ClienteRecuperado = cliNeg.Recuperar(cliente);

            IdCliente = ClienteRecuperado.IdCliente;
            txtNome.Text = ClienteRecuperado.Nome;
            txtCpf.Text = ClienteRecuperado.Cpf;
            txtEmail.Text = ClienteRecuperado.Email;
            txtCep.Text = ClienteRecuperado.Cep;
            txtRua.Text = ClienteRecuperado.Rua;
            txtNumero.Text = ClienteRecuperado.Numero;
            txtCidade.Text = ClienteRecuperado.Cidade;
            ddlEstado.SelectedValue = ClienteRecuperado.Estado;
            CarregarGrid();

            PanelListaTelefones.Visible = true;
            btnCadastrarTelefone.Visible = true;
        }

        private void CarregarGrid()
        {
            VO.Telefone telefone = new VO.Telefone();
            telefone.IdCliente = IdCliente;
            gridTelefone.DataSource = telNeg.RecuperarTelefones(telefone.IdCliente);
            gridTelefone.DataBind();
        }

        private void GravarCliente()
        {
            VO.Cliente cliente = new VO.Cliente();

            cliente.Nome = txtNome.Text;
            cliente.Cpf = txtCpf.Text;
            cliente.Email = txtEmail.Text;
            cliente.Cep = txtCep.Text;
            cliente.Rua = txtRua.Text;
            cliente.Numero = txtNumero.Text;
            cliente.Cidade = txtCidade.Text;
            cliente.Estado = ddlEstado.SelectedValue;

            if (IdViewState == 0)
                cliNeg.Salvar(cliente);
            else
            {
                cliente.IdCliente = IdViewState;
                cliNeg.Atualizar(cliente);
            }
            btnCadastrarTelefone.Visible = true;
        }

        protected void btnPesquisarCep_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCep.Text != "")
                {
                    var ws = new WSCorreios.AtendeClienteClient();
                    var xml = ws.consultaCEP(txtCep.Text);

                    if (xml != null)
                    {
                        string rua = xml.end;
                        string bairro = xml.bairro;
                        string cidade = xml.cidade;
                        string uf = xml.uf;

                        txtRua.Text = rua.ToUpper();
                        //txtBairro.Text = bairro.ToUpper();
                        txtCidade.Text = cidade.ToUpper();
                        ddlEstado.SelectedItem.Text = uf.ToUpper();
                    }
                }
                else
                    lblValidaCep.Text = " Informe um CEP";
            }
            catch (Exception ex)
            {
                //throw ex;
                lblValidaCep.Text = ex.Message.ToString();

            }
        }

        private void HabilitaPanel()
        {
            PanelListaTelefones.Visible = true;
            PanelCliente.Visible = true;
        }

        protected void btnCadastrarTelefone_Click(object sender, EventArgs e)
        {
            Response.Redirect("Telefone.aspx?cliente=" + IdViewState);
        }

        public bool ValidarEmail(String email)
        {
            bool emailValido = false;

            //Expressão regular retirada de
            //https://msdn.microsoft.com/pt-br/library/01escwtf(v=vs.110).aspx
            string emailRegex = string.Format("{0}{1}",
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))",
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");

            try
            {
                emailValido = Regex.IsMatch(
                    email,
                    emailRegex);
            }
            catch (RegexMatchTimeoutException)
            {
                emailValido = false;
            }

            return emailValido;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}