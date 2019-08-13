using Furiza.AspNetCore.ExceptionHandling;
using Furiza.AspNetCore.WebApi.Configuration;
using Furiza.Base.Core.Exceptions.Serialization;
using Gestor.CoreBusiness.Domain.Models.EmpregadoAggregate;
using Gestor.CoreBusiness.Domain.ViewModels;
using Gestor.CoreBusiness.Domain.ViewModels.EmpregadoViewModels;
using Gestor.CoreBusiness.WebApi.Exceptions;
using Gestor.CoreBusiness.WebApi.Queries.Empregado;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor.CoreBusiness.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class EmpregadosController : RootController
    {
        private readonly IMediator mediator;
        private readonly IEmpregadoReadOnlyRepository empregadoReadOnlyRepository;
        private readonly IEmpregadoBusiness empregadoBusiness;

        public EmpregadosController(IMediator mediator,
            IEmpregadoReadOnlyRepository empregadoReadOnlyRepository,
            IEmpregadoBusiness empregadoBusiness)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.empregadoReadOnlyRepository = empregadoReadOnlyRepository ?? throw new ArgumentNullException(nameof(empregadoReadOnlyRepository));
            this.empregadoBusiness = empregadoBusiness ?? throw new ArgumentNullException(nameof(empregadoBusiness));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ObterEmpregadosQueryResult), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> GetManyAsync([FromQuery]ObterEmpregadosQuery query)
        {
            var queryResult = await mediator.Send(query);

            return Ok(queryResult);
        }

        [HttpGet("{id}", Name = "EmpregadosGet")]
        [ProducesResponseType(typeof(ObterEmpregadoQueryResult), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> GetAsync([FromRoute]Guid id)
        {
            var query = new ObterEmpregadoQuery()
            {
                EmpregadoId = id
            };
            var queryResult = await mediator.Send(query);
            if (queryResult == null)
                throw new ResourceNotFoundException(new ResourceNotFoundExceptionItem[] { CoreBusinessResourceNotFoundExceptionItem.Empregado });

            return Ok(queryResult);
        }

        [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
        [HttpPost]
        [ProducesResponseType(typeof(CadastrarResult), 201)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(typeof(BadRequestError), 406)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> PostAsync([FromBody]CadastrarEmpregadoViewModel model)
        {
            var result = await empregadoBusiness.CadastrarAsync(model);

            return CreatedAtRoute("EmpregadosGet", new { id = result.Id }, result);
        }

        [Authorize(Policy = FurizaPolicies.RequireEditorRights)]
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BadRequestError), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(typeof(BadRequestError), 404)]
        [ProducesResponseType(typeof(BadRequestError), 406)]
        [ProducesResponseType(typeof(InternalServerError), 500)]
        public async Task<IActionResult> PutAsync(Guid id,
            [FromBody]AtualizarEmpregadoViewModel model)
        {
            var empregado = await ObterEmpregadoAsync(id);
            
            await empregadoBusiness.AtualizarAsync(empregado, model);

            return NoContent();
        }

        #region [+] Pvts
        private async Task<Empregado> ObterEmpregadoAsync(Guid id)
        {
            var errors = new List<CoreBusinessResourceNotFoundExceptionItem>();

            var empregado = await empregadoReadOnlyRepository.GetByIdAsync(id);
            if (empregado == null)
                errors.Add(CoreBusinessResourceNotFoundExceptionItem.Empregado);

            if (errors.Any())
                throw new ResourceNotFoundException(errors);

            return empregado;
        }
        #endregion
    }
}