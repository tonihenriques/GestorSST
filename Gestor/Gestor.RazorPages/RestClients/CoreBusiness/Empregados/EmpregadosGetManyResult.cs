using Furiza.Base.Core.Domain.BR.ValueObjects;
using System;
using System.Collections.Generic;

namespace Gestor.RazorPages.RestClients.CoreBusiness.Empregados
{
    public class EmpregadosGetManyResult
    {
        public IEnumerable<EmpregadosGetManyResultInnerEmpregado> Empregados { get; set; }

        public class EmpregadosGetManyResultInnerEmpregado
        {
            public Guid? Id { get; set; }
            public DateTime? CreationDate { get; set; }
            public string CreationUser { get; set; }
            public Cpf Cpf { get; set; }
            public string Nome { get; set; }
            public string Matricula { get; set; }
            public StatusEmpregado? Status { get; set; }
        }
    }
}