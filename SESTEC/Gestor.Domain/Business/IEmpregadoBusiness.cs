using Gestor.Domain.ViewModels;
using Gestor.Domain.ViewModels.Empregado;

namespace Gestor.Domain.Business
{
    public interface IEmpregadoBusiness
    {
        CadastrarResult Cadastrar(CadastrarEmpregadoViewModel cadastrarEmpregadoViewModel);
    }
}