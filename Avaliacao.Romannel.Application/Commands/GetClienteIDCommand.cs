using Avaliacao.Romannel.Application.DTOs;
using Avaliacao.Romannel.Domain.Enums;
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
    public record GetClienteIDCommand : IRequest<ClienteDto>
    {
        public long IdCliente { get; set; }
    }

    public class GetClienteIDCommandHandler : IRequestHandler<GetClienteIDCommand, ClienteDto>
    {
        private readonly IClienteRepository _clienteRepository;

        public GetClienteIDCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository; 
        }

        public async Task<ClienteDto> Handle(GetClienteIDCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _clienteRepository.PesquisaClientePorId(request.IdCliente, cancellationToken);
                if (result == null)
                {
                    return null;
                }

                return new ClienteDto
                {
                    IdCliente = result.IdCliente,
                    NomeRazaoSocial = result.NomeRazaoSocial,
                    CpfCnpj = result.CpfCnpj,
                    TipoPessoa = result.TipoPessoa == 1 ? TipoPessoa.Fisica : TipoPessoa.Juridica,
                    DataNascimento = result.DataNascimento,
                    TelefoneCel = result.TelefoneCel,
                    Email = result.Email,
                    IsentoIE = result.IsentoIE,
                    InscricaoEstadual = result.InscricaoEstadual,
                };

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
