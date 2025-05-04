using Avaliacao.Romannel.Application.DTOs;
using Avaliacao.Romannel.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.Romannel.Application.Commands
{
    [ExcludeFromCodeCoverage]
    public record DeleteClienteCommand : IRequest<bool>
    {
        public long IdCliente { get; set; }
    }

    public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, bool>
    {
        private readonly IClienteRepository _clienteRepository;
        public DeleteClienteCommandHandler(IClienteRepository clienteRepository) 
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _clienteRepository.DeleteClientePorId(request.IdCliente, cancellationToken);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}
