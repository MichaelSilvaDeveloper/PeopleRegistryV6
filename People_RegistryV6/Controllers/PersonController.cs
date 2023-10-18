using Application.Commands.Create.Request;
using Application.Commands.Create.Response;
using Application.Commands.Delete.Request;
using Application.Commands.Delete.Response;
using Application.Commands.Update.Request;
using Application.Queries.GetAllPeople;
using Application.Queries.GetPersonById;
using Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace People_RegistryV6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Person>> List()
        {
            return await _mediator.Send(new GetAllPersonQuery());
            //return Ok(await _mediator.Send(new GetAllPersonQuery())) -> IActionResult;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonById(int id)
        {
            //return await _mediator.Send(new GetPersonByIdQuery { Id = id});
            return Ok(await _mediator.Send(new GetPersonByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePersonRequest command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeletePersonRequest { Id = id }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdatePersonRequest command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}