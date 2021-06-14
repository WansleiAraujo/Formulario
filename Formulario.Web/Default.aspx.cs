using System;
using System.Web.UI.WebControls;
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

            //if (gridCliente.DataSource != null)
            //{
            //    ///// Esta diferente de Null
            //    int total = Convert.ToInt32(gridCliente.Rows.Count);
            //    //// Percorre as linhas da pagina atual
            //    for (int i = 0; i < total; i++)
            //    {
            //        if (i < total)
            //        {
            //            // Percorrento Coluna Valor
            //            //Removendo campos não necessario
            //            gridCliente.Rows[i].Cells[2].Text = Convert.ToDecimal(gridCliente.Rows[i].Cells[2].Text).ToString("00.00'");

            //            /// Percorrendo Columa Curso
            //            //tabelaCurso.IdCodigoCurso = Convert.ToInt32(gridMatricula.Rows[i].Cells[6].Text);
            //            //tabelaCurso.IdCodigoCurso = matricula.IdCodigoCurso;

            //            //TabelaCurso tabelaCursoRecuperado = negTabCur.Recuperar(tabelaCurso);
            //            //gridCliente.Rows[i].Cells[6].Text = tabelaCursoRecuperado.Descricao;
            //        }
            //        else
            //        {
            //            i = total;
            //        }
            //    }
            //}
        }
    }
}