﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Gestor.Domain.ViewModels.Empregado
{
    public class AtualizarEmpregadoViewModel
    {
        [Display(Name = "CPF")]
        [Required]
        //[CustomValidationCPF(ErrorMessage = "CPF inválido")] //TODO: criar o filtro e colocar aqui !
        public string Cpf { get; set; }

        [Required]
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required]
        public DateTime? DataNascimento { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Telefone { get; set; }

        [Display(Name = "Matrícula")]
        public string Matricula { get; set; }
    }
}