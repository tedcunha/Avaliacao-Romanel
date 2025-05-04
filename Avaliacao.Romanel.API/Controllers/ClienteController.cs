using Avaliacao.Romannel.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<bool>> CreateCliente([FromBody] CreateClienteCommand command)
        {
            var result = await _mediator.Send(command);
            return result is not null ? Created(string.Empty,result) :  StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}
