using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gestor.CoreBusiness.WebApi.Queries.Empregado
{
    internal class ObterEmpregadoQueryHandler : IRequestHandler<ObterEmpregadoQuery, ObterEmpregadoQueryResult>
    {
        private readonly CoreBusinessQueryContext coreBusinessQueryContext;

        public ObterEmpregadoQueryHandler(CoreBusinessQueryContext coreBusinessQueryContext)
        {
            this.coreBusinessQueryContext = coreBusinessQueryContext ?? throw new ArgumentNullException(nameof(coreBusinessQueryContext));
        }

        public async Task<ObterEmpregadoQueryResult> Handle(ObterEmpregadoQuery request, CancellationToken cancellationToken)
        {
            var query = $@"
                select
                    *
                from
                    [{coreBusinessQueryContext.DatabaseName}]..[Empregados] with(nolock)
                where
                    [Id] = @empregadoId";

            var queryResult = (await coreBusinessQueryContext.QueryAsync<ObterEmpregadoQueryResult>(query, new
            {
                request.EmpregadoId
            })).FirstOrDefault();

            //if (queryResult != null)
            //{
            //    query = $@"
            //        select
            //            [Id] MembroId, [UserName], [NomeCompleto], [Funcao]
            //        from
            //            [{coreBusinessQueryContext.DatabaseName}]..[Membros] with(nolock)
            //        where
            //            [CipaId] = @cipaId
            //        order by
            //            [UserName]";

            //    queryResult.Membros = await coreBusinessQueryContext.QueryAsync<ObterCipaQueryResult.ObterCipaQueryResultInnerMembro>(query, new
            //    {
            //        request.CipaId
            //    });
            //}

            return queryResult;
        }
    }
}