using Furiza.Base.Core.Domain.BR.ValueObjects;
using Furiza.Base.Core.SeedWork;
using Gestor.CoreBusiness.Domain.Exceptions;
using System;

namespace Gestor.CoreBusiness.Domain.Models.EmpregadoAggregate
{
    public class Empregado : Entity, IAggregateRoot
    {
        public string Cpf { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; set; }
        public string Matricula { get; set; }
        public StatusEmpregado Status { get; private set; }

        private Empregado()
        {

        }

        public Empregado(string usuarioCadastro, Cpf cpf, string nome, DateTime dataNascimento, string email, string telefone, string matricula) : this()
        {
            SetCpf(cpf);
            SetNome(nome);
            SetDataNascimento(dataNascimento);
            SetEmail(email);

            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
            CreationUser = usuarioCadastro;

            Telefone = telefone;
            Matricula = matricula;

            Status = StatusEmpregado.Livre;
        }

        public void SetCpf(Cpf cpf) => Cpf = cpf;

        public void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new CampoNaoPodeSerNuloException(nameof(nome));

            Nome = nome.Trim().ToUpper();
        }

        public void SetDataNascimento(DateTime dataNascimento)
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - dataNascimento.Year;
            if (dataNascimento > hoje.AddYears(-idade))
                idade--;

            if (idade < 16 || idade > 80)
                throw new IdadeNaoPermitidaException();

            DataNascimento = dataNascimento;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new CampoNaoPodeSerNuloException(nameof(email));

            Email = email.Trim().ToLower();
        }
    }
}