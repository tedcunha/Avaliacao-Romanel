using Avaliacao.Romannel.Application.DTOs;
using Avaliacao.Romannel.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.Romannel.Application.Commands
{

    [ExcludeFromCodeCoverage]
    public record CreateClienteCommand : IRequest<ClienteDto>
    {
        public string NomeRazaoSocial { get; set; }
    }

    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, ClienteDto>
    {
        public async Task<ClienteDto> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            ClienteDto clienteDto = new ClienteDto();
            return clienteDto;
        }
    }
}
