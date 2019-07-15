using Gestor.Domain.Business;
using Gestor.Domain.Entities;
using Gestor.Domain.Repositories;
using Gestor.Domain.ViewModels.Empregado;
using System;

namespace Gestor.Application.Business
{
    internal class EmpregadoBusiness : IEmpregadoBusiness
    {
        private readonly IBaseRepository<Empregado> empregadoRepository;

        public EmpregadoBusiness(IBaseRepository<Empregado> empregadoRepository)
        {
            this.empregadoRepository = empregadoRepository ?? throw new ArgumentNullException(nameof(empregadoRepository));
        }

        public void Cadastrar(CadastrarEmpregadoViewModel cadastrarEmpregadoViewModel)
        {
            throw new NotImplementedException();
        }
    }
}