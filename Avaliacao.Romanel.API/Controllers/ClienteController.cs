using Avaliacao.Romannel.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Avaliacao.Romanel.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(IMediator mediator,
                                 ILogger<ClienteController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("CadastrarCliente")]
        public async Task<IActionResult> CreateCliente([FromBody] CreateClienteCommand command)
        {
            var result = await _mediator.Send(command);
            return result is not null ? Created(string.Empty,result) :  StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("PesquisarClientePorID/{IdCliente}")]
        public async Task<IActionResult> GetClientePorId([FromRoute] long IdCliente)
        {
            var result = await _mediator.Send(new GetClienteIDCommand { IdCliente = IdCliente});
            return result is not null ? Created(string.Empty, result) : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("RemoveCliente/{IdCliente}")]
        public async Task<IActionResult> DeleteCliente([FromRoute] long IdCliente)
        {
            var result = await _mediator.Send(new DeleteClienteCommand { IdCliente = IdCliente });
            return result ? Created(string.Empty, result) : StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
