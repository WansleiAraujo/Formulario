using System;
using Formulario.Negocio;

namespace Formulario.Web
{
    public partial class Telefone : System.Web.UI.Page
    {
        VO.Telefone telefone = new VO.Telefone();
        TelefoneNegocio telNeg = new TelefoneNegocio();

        private Int32 IdTelefone;
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
        public int IdViewStateCliente
        {
            get
            {
                if (ViewState["valor1"] != null)
                    return Convert.ToInt32(ViewState["valor1"]);
                return 0;
            }
            set
            {
                ViewState["valor1"] = value;
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
                    IdViewStateCliente = Convert.ToInt32(Request.QueryString["cliente"]);
                    if (IdViewState != 0)
                        CarregarTelefoneId(IdViewState);

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

        private void CarregarTelefoneId(Int32 Id)
        {
            VO.Telefone telefone = new VO.Telefone();
            telefone.IdTelefone = Id;

            VO.Telefone TelefoneRecuperado = new VO.Telefone();
            TelefoneRecuperado = telNeg.Recuperar(telefone);

            IdTelefone = TelefoneRecuperado.IdTelefone;
            ddlTipoTelefone.SelectedValue = TelefoneRecuperado.TipoTelefone;
            txtTelefone.Text = TelefoneRecuperado.NumeroTelefone;
        }

        protected void btnCadastrarTelefone_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdViewState == 0)
                {
                    if (ddlTipoTelefone.SelectedIndex != 0 && txtTelefone.Text != "")
                    {
                        camposInformados = true;
                    }
                    else
                    {
                        lblValidaTelefone.Text = "Todos os campos são obrigatórios.";
                    }

                    if (camposInformados == true)
                    {
                        if (IdTelefone == 0)
                        {
                            GravarTelefone();
                            Response.Redirect("Default.aspx");
                        }
                        else
                        {
                            lblValidaTelefone.Text = "Telefone já cadastrado!";
                        }
                    }
                }
                else
                {
                    if (ddlTipoTelefone.SelectedIndex != 0 && txtTelefone.Text != "")
                    {
                        camposInformados = true;
                    }
                    else
                    {
                        lblValidaTelefone.Text = "Todos os campos são obrigatórios.";
                    }

                    if (camposInformados == true)
                    {
                        if (IdViewState != 0)
                        {
                            GravarTelefone();
                            Response.Redirect("Default.aspx");
                        }
                        else
                        {
                            lblValidaTelefone.Text = "Telefone já cadastrado!";
                        }
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GravarTelefone()
        {
            VO.Telefone telefone = new VO.Telefone();

            telefone.TipoTelefone = ddlTipoTelefone.SelectedValue;
            telefone.NumeroTelefone = txtTelefone.Text;
            telefone.IdCliente = IdViewStateCliente;

            if (IdViewState == 0)
                telNeg.Salvar(telefone);
            else
            {
                telefone.IdTelefone = IdViewState;
                telNeg.Atualizar(telefone);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}