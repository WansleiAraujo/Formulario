namespace Formulario.VO
{
    public class Telefone
    {
        public int IdTelefone { get; set; }
        public int TipoTelefone { get; set; } // 1 - Fixo e 2 - Celular
        public string NumeroTelefone { get; set; }
        public int IdCliente { get; set; }
    }
}
