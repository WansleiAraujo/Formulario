using System;
using System.Collections.Generic;
using Formulario.VO;
using Formulario.Dados;

namespace Formulario.Negocio
{
    public class TelefoneNegocio : NegocioBase<Telefone>
    {
        private TelefoneDados Dados = new TelefoneDados();

        public override void Salvar(Telefone entidade)
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

        public override void Excluir(Telefone entidade)
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

        public override void Atualizar(Telefone entidade)
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

        public override Telefone Recuperar(Telefone entidade)
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

        public override List<Telefone> Todos()
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
