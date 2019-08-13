using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gestor.CoreBusiness.WebApi.Queries.Empregado
{
    internal class ObterEmpregadosQueryHandler : IRequestHandler<ObterEmpregadosQuery, ObterEmpregadosQueryResult>
    {
        private readonly CoreBusinessQueryContext coreBusinessQueryContext;

        public ObterEmpregadosQueryHandler(CoreBusinessQueryContext coreBusinessQueryContext)
        {
            this.coreBusinessQueryContext = coreBusinessQueryContext ?? throw new ArgumentNullException(nameof(coreBusinessQueryContext));
        }

        public async Task<ObterEmpregadosQueryResult> Handle(ObterEmpregadosQuery request, CancellationToken cancellationToken)
        {
            var query = $@"
                select top (@quantidade)
                    *
                from
                    [{coreBusinessQueryContext.DatabaseName}]..[Empregados] with(nolock)
                where
                    [Status] = @status";

            if (!string.IsNullOrWhiteSpace(request.Cpf))
                query += " and [Cpf] = @cpf";

            if (!string.IsNullOrWhiteSpace(request.Nome))
                query += " and [Nome] like @nome";

            query += @"
                order by
                    [CreationDate] desc";

            var queryResult = new ObterEmpregadosQueryResult()
            {
                Empregados = await coreBusinessQueryContext.QueryAsync<ObterEmpregadosQueryResult.ObterEmpregadosQueryResultInnerEmpregado>(query, new
                {
                    request.Status,
                    request.Quantidade,
                    request.Cpf,
                    nome = $"%{request.Nome}%"
                })
            };

            return queryResult;
        }
    }
}