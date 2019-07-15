using Gestor.Domain.ViewModels.Empregado;

namespace Gestor.Domain.Business
{
    public interface IEmpregadoBusiness
    {
        void Cadastrar(CadastrarEmpregadoViewModel cadastrarEmpregadoViewModel);
    }
}