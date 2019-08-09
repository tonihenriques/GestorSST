using Furiza.Base.Core.Domain.BR.Exceptions;
using Gestor.CoreBusiness.Domain.Exceptions;
using Gestor.CoreBusiness.Domain.ViewModels;
using Gestor.CoreBusiness.Domain.ViewModels.EmpregadoViewModels;
using System.Threading.Tasks;

namespace Gestor.CoreBusiness.Domain.Models.EmpregadoAggregate
{
    public interface IEmpregadoBusiness// : IEntidadeComImagemService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cadastrarEmpregadoViewModel"></param>
        /// <exception cref="CpfInvalidoException"></exception>
        /// <exception cref="CpfJaCadastradoException"></exception>
        /// <exception cref="CampoNaoPodeSerNuloException"></exception>
        /// <exception cref="IdadeNaoPermitidaException"></exception>
        /// <returns>Objeto contendo o Id e o Cpf formatado do empregado cadastrado.</returns>
        Task<CadastrarResult> CadastrarAsync(CadastrarEmpregadoViewModel cadastrarEmpregadoViewModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="empregado"></param>
        /// <param name="atualizarEmpregadoViewModel"></param>
        /// <exception cref="CpfInvalidoException"></exception>
        /// <exception cref="CpfJaCadastradoException"></exception>
        /// <exception cref="CampoNaoPodeSerNuloException"></exception>
        /// <exception cref="IdadeNaoPermitidaException"></exception>
        Task AtualizarAsync(Empregado empregado, AtualizarEmpregadoViewModel atualizarEmpregadoViewModel);
    }
}