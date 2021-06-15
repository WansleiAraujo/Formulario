using System;
using Formulario.Negocio;

namespace Formulario.Web
{
    public partial class Default : System.Web.UI.Page
    {
        readonly Cliente cliente = new Cliente();
        readonly ClienteNegocio cliMat = new ClienteNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Carrega Ano atua para as Paginas
            lblAno.Text = DateTime.Now.ToString("yyyy ");

            CarregarGrid();
        }

        private void CarregarGrid()
        {
            gridCliente.DataSource = cliMat.Todos();
            gridCliente.DataBind();
        }
    }
}