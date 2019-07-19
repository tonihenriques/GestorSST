using Gestor.Domain.Business;
using Gestor.Domain.Entities;
using Gestor.Domain.Exceptions;
using Gestor.Domain.Repositories;
using Gestor.Domain.ValueObjects;
using Gestor.Domain.ViewModels;
using Gestor.Domain.ViewModels.Empregado;
using System;

namespace Gestor.Application.Business
{
    internal class EmpregadoBusiness : IEmpregadoBusiness
    {
        private readonly IEmpregadoRepository empregadoRepository;

        public EmpregadoBusiness(IEmpregadoRepository empregadoRepository)
        {
            this.empregadoRepository = empregadoRepository ?? throw new ArgumentNullException(nameof(empregadoRepository));
        }

        public CadastrarResult Cadastrar(CadastrarEmpregadoViewModel cadastrarEmpregadoViewModel)
        {
            var cpf = new Cpf(cadastrarEmpregadoViewModel.Cpf);
            var empregado = empregadoRepository.ObterPeloCpf(cpf);
            if (empregado != null)
                throw new CpfJaCadastradoException();

            //TODO: ajustar usuario...
            empregado = new Empregado("ivan", cpf, cadastrarEmpregadoViewModel.Nome, cadastrarEmpregadoViewModel.DataNascimento, cadastrarEmpregadoViewModel.Email, null);

            empregadoRepository.Inserir(empregado);

            empregadoRepository.UnitOfWork.SaveEntities();

            return new CadastrarResult(empregado.Uid, cpf.NumeroComMascara);
        }
    }
}