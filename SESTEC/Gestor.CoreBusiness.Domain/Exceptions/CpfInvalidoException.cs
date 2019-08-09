﻿using System;
using System.Runtime.Serialization;

namespace Gestor.Domain.Exceptions
{
    [Serializable]
    public class CpfInvalidoException : CoreException
    {
        public override string Key => "CpfInvalido";
        public override string Message => "O CPF fornecido está em branco, é inválido ou está em um formato inválido.";

        public CpfInvalidoException() : base()
        {
        }

        protected CpfInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}