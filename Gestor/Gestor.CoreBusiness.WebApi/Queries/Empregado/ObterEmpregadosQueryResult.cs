using Gestor.CoreBusiness.Domain.Models.EmpregadoAggregate;
using System;
using System.Collections.Generic;

namespace Gestor.CoreBusiness.WebApi.Queries.Empregado
{
    public class ObterEmpregadosQueryResult
    {
        public IEnumerable<ObterEmpregadosQueryResultInnerEmpregado> Empregados { get; set; }

        public class ObterEmpregadosQueryResultInnerEmpregado
        {
            public Guid? Id { get; set; }
            public DateTime? CreationDate { get; set; }
            public string CreationUser { get; set; }
            public string Cpf { get; set; }
            public string Nome { get; set; }
            public string Matricula { get; set; }
            public StatusEmpregado? Status { get; set; }

            //TODO: adicionar depois as colunas da admissão e alocação atuais do empregado
        }
    }
}