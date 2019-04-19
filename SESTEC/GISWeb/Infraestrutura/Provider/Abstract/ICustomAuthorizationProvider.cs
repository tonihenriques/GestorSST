using GISModel.DTO.Conta;
using GISModel.Entidades;

namespace GISWeb.Infraestrutura.Provider.Abstract
{
    public interface ICustomAuthorizationProvider
    {

        Usuario UsuarioAutenticado { get; }

        bool EstaAutenticado { get; }

        void Logar(AutenticacaoModel autenticacaoModel);

        void Deslogar();

    }
}