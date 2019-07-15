﻿using Gestor.Domain.Exceptions;
using Gestor.Domain.ValueObjects;
using System;

namespace Gestor.Domain.Entities
{
    public class Empregado : EntidadeBase
    {
        public Guid Id { get; private set; }
        public string Cpf { get; private set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public bool Admitido { get; private set; }

        private Empregado()
        {

        }

        public Empregado(string usuarioInclusao, Cpf cpf, string nome, DateTime dataNascimento, string email, string endereco) : this()
        {
            SetDadosInclusao(usuarioInclusao);

            if (string.IsNullOrWhiteSpace(nome))
                throw new CampoNaoPodeSerNuloException(nameof(nome));

            if (string.IsNullOrWhiteSpace(nome))
                throw new CampoNaoPodeSerNuloException(nameof(email));

            Id = Guid.NewGuid();
            Cpf = cpf;
            Nome = nome.Trim();
            DataNascimento = dataNascimento;
            Email = email.Trim().ToLower();
            Endereco = endereco?.Trim();
            Admitido = false;
        }
    }
}