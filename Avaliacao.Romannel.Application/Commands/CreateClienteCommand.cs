using AutoMapper;
using Avaliacao.Romannel.Application.DTOs;
using Avaliacao.Romannel.Application.Validators;
using Avaliacao.Romannel.Domain.Entities;
using Avaliacao.Romannel.Domain.Enums;
using Avaliacao.Romannel.Domain.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public string InscricaoEstadual { get;  set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }

    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, ClienteDto>
    {

        private readonly IValidator<CreateClienteCommand> _validator;
        private readonly IClienteRepository _clienteRepository;
        //private readonly INotificationResultContext _notifications;

        public CreateClienteCommandHandler(IValidator<CreateClienteCommand> validator,
                                           IClienteRepository clienteRepository)
        {
            _validator = validator;
            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteDto> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.Errors);
                }

                if (await _clienteRepository.PesquisaPorCnpjEmail(request.CpfCnpj,request.Email, cancellationToken))
                {
                    throw new ValidationException($"Este cpf/cnpj : {request.CpfCnpj} já esta cadastrado !");
                }

                var result = await _clienteRepository.AdicionarCliente(new Cliente()
                {
                    NomeRazaoSocial = request.NomeRazaoSocial,
                    CpfCnpj = request.CpfCnpj,
                    TipoPessoa = (int)request.TipoPessoa,
                    DataNascimento = request.DataNascimento,
                    TelefoneCel = request.TelefoneCel,
                    Email = request.Email,
                    Ativo = true,
                    IsentoIE = request.IsentoIE,
                    InscricaoEstadual = request.InscricaoEstadual,
                    CreateAt = DateTime.Now,
                }, cancellationToken);

                return new ClienteDto
                {
                    IdCliente = result.IdCliente,
                    NomeRazaoSocial = result.NomeRazaoSocial,
                    CpfCnpj = result.CpfCnpj,
                    TipoPessoa = result.TipoPessoa == 1 ? TipoPessoa.Fisica : TipoPessoa.Juridica,
                    DataNascimento = result.DataNascimento,
                    TelefoneCel= result.TelefoneCel,
                    Email= result.Email,
                    IsentoIE= result.IsentoIE,
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
