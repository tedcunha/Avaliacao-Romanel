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
        public string NomeRazaoSocial { get;  set; }
        public string CpfCnpj { get; set; } // CPF ou CNPJ
        public TipoPessoa TipoPessoa { get;  set; }
        public DateTime DataNascimento { get;  set; }
        public string TelefoneCel { get;  set; }
        public string Email { get;  set; }
        public bool IsentoIE { get;  set; }
        public string? InscricaoEstadual { get;  set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }

    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, ClienteDto>
    {

        public CreateClienteCommandHandler()
        {
            
        }

        public async Task<ClienteDto> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            ClienteDto clienteDto = new ClienteDto();

            return clienteDto;
        }
    }
}
