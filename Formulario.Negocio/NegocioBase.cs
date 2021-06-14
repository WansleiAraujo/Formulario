using System;
using System.Collections.Generic;
using Formulario.VO;
using Formulario.Dados;

namespace Formulario.Negocio
{
    public abstract  class NegocioBase<T>
    {
        public abstract void Salvar(T entidade);
        public abstract void Excluir(T entidade);
        public abstract void Atualizar(T entidade);
        public abstract T Recuperar(T entidade);
        public abstract List<T> Todos();
    }
}
