using Gestor.Domain.Exceptions;
using System;

namespace Gestor.Domain.Entities
{
    public class EntidadeBase
    {
        public string UsuarioInclusao { get; private set; }

        public DateTime DataInclusao { get; private set; }

        public string UsuarioExclusao { get; private set; }

        public DateTime DataExclusao { get; private set; }

        protected void SetDadosInclusao(string usuarioInclusao)
        {
            if (string.IsNullOrWhiteSpace(usuarioInclusao))
                throw new CampoNaoPodeSerNuloException(nameof(usuarioInclusao));

            UsuarioInclusao = usuarioInclusao;
            DataInclusao = DateTime.Now;
        }

        protected void SetDadosExclusao(string usuarioExclusao)
        {
            if (string.IsNullOrWhiteSpace(usuarioExclusao))
                throw new CampoNaoPodeSerNuloException(nameof(usuarioExclusao));

            UsuarioExclusao = usuarioExclusao;
            DataExclusao = DateTime.Now;
        }
    }
}