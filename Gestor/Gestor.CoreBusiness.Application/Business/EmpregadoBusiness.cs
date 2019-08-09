using Furiza.Audit.Abstractions;
using Furiza.Base.Core.Domain.BR.ValueObjects;
using Furiza.Base.Core.Identity.Abstractions;
using Gestor.CoreBusiness.Domain.Exceptions;
using Gestor.CoreBusiness.Domain.Models.EmpregadoAggregate;
using Gestor.CoreBusiness.Domain.ViewModels;
using Gestor.CoreBusiness.Domain.ViewModels.EmpregadoViewModels;
using System;
using System.Threading.Tasks;

namespace Gestor.CoreBusiness.Application.Business
{
    internal class EmpregadoBusiness : IEmpregadoBusiness
    {
        private readonly IUserPrincipalBuilder userPrincipalBuilder;
        private readonly IEmpregadoReadOnlyRepository empregadoReadOnlyRepository;
        private readonly IEmpregadoWriteOnlyRepository empregadoWriteOnlyRepository;
        private readonly IAuditTrailProvider auditTrailProvider;

        public EmpregadoBusiness(IUserPrincipalBuilder userPrincipalBuilder,
            IEmpregadoReadOnlyRepository empregadoReadOnlyRepository,
            IEmpregadoWriteOnlyRepository empregadoWriteOnlyRepository,
            IAuditTrailProvider auditTrailProvider)
            //IImageRepository imageRepository)
        {
            this.userPrincipalBuilder = userPrincipalBuilder ?? throw new ArgumentNullException(nameof(userPrincipalBuilder));
            this.empregadoReadOnlyRepository = empregadoReadOnlyRepository ?? throw new ArgumentNullException(nameof(empregadoReadOnlyRepository));
            this.empregadoWriteOnlyRepository = empregadoWriteOnlyRepository ?? throw new ArgumentNullException(nameof(empregadoWriteOnlyRepository));
            this.auditTrailProvider = auditTrailProvider ?? throw new ArgumentNullException(nameof(auditTrailProvider));
        }

        public async Task<CadastrarResult> CadastrarAsync(CadastrarEmpregadoViewModel cadastrarEmpregadoViewModel)
        {
            var cpf = new Cpf(cadastrarEmpregadoViewModel.Cpf);
            var empregado = await empregadoReadOnlyRepository.ObterPeloCpfAsync(cpf);
            if (empregado != null)
                throw new CpfJaCadastradoException();

            empregado = new Empregado(userPrincipalBuilder.UserPrincipal.UserName, cpf, cadastrarEmpregadoViewModel.Nome, cadastrarEmpregadoViewModel.DataNascimento.Value, cadastrarEmpregadoViewModel.Email, cadastrarEmpregadoViewModel.Telefone, cadastrarEmpregadoViewModel.Matricula);

            empregadoWriteOnlyRepository.Insert(empregado);

            await empregadoWriteOnlyRepository.UnitOfWork.SaveEntitiesAsync();

            await auditTrailProvider.AddTrailsAsync(AuditOperation.Create, userPrincipalBuilder.UserPrincipal.UserName, new AuditableObjects<Empregado>(empregado.Id.ToString(), empregado));

            return new CadastrarResult(empregado.Id, cpf.NumeroComMascara);
        }

        public async Task AtualizarAsync(Empregado empregado, AtualizarEmpregadoViewModel atualizarEmpregadoViewModel)
        {
            var cpf = new Cpf(atualizarEmpregadoViewModel.Cpf);
            if (cpf != empregado.Cpf && await empregadoReadOnlyRepository.ObterPeloCpfAsync(cpf) != null)
                throw new CpfJaCadastradoException();

            empregado.SetCpf(cpf);
            empregado.SetNome(atualizarEmpregadoViewModel.Nome);
            empregado.SetDataNascimento(atualizarEmpregadoViewModel.DataNascimento.Value);
            empregado.SetEmail(atualizarEmpregadoViewModel.Email);

            empregado.Telefone = atualizarEmpregadoViewModel.Telefone;
            empregado.Matricula = atualizarEmpregadoViewModel.Matricula;

            empregadoWriteOnlyRepository.Update(empregado);

            await empregadoWriteOnlyRepository.UnitOfWork.SaveEntitiesAsync();

            await auditTrailProvider.AddTrailsAsync(AuditOperation.Update, userPrincipalBuilder.UserPrincipal.UserName, new AuditableObjects<Empregado>(empregado.Id.ToString(), empregado));
        }

        //#region [+] Imagem Service
        //public void IncluirFoto(Guid entidadeId, string imagemBase64)
        //{
        //    if (empregadoRepository.ObterPeloId(entidadeId) == null)
        //        throw new RecursoNaoEncontradoException(nameof(Empregado));

        //    imageRepository.Upload<Empregado>(entidadeId, imagemBase64);
        //}

        //public byte[] ObterFoto(Guid entidadeId)
        //{
        //    if (empregadoRepository.ObterPeloId(entidadeId) == null)
        //        throw new RecursoNaoEncontradoException(nameof(Empregado));

        //    return imageRepository.Get<Empregado>(entidadeId);
        //}

        //public bool PossuiFoto(Guid entidadeId)
        //{
        //    if (empregadoRepository.ObterPeloId(entidadeId) == null)
        //        throw new RecursoNaoEncontradoException(nameof(Empregado));

        //    return imageRepository.Has<Empregado>(entidadeId);
        //}
        //#endregion
    }
}