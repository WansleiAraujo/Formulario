using System;
using System.Collections.Generic;
using Formulario.VO;
using Formulario.Dados;

namespace Formulario.Negocio
{
    public class ClienteNegocio : NegocioBase<Cliente>
    {
        private ClienteDados Dados = new ClienteDados();

        public override void Salvar(Cliente entidade)
        {
            try
            {
                Dados.Salvar(entidade);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override void Excluir(Cliente entidade)
        {
            try
            {
                Dados.Excluir(entidade);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override void Atualizar(Cliente entidade)
        {
            try
            {
                Dados.Atualizar(entidade);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override Cliente Recuperar(Cliente entidade)
        {
            try
            {
                return Dados.Recuperar(entidade);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override List<Cliente> Todos()
        {
            try
            {
                return Dados.Todos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
