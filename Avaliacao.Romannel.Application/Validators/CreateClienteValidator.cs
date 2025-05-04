using Avaliacao.Romannel.Application.Commands;
using Avaliacao.Romannel.Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.Romannel.Application.Validators
{
    public class CreateClienteValidator : AbstractValidator<CreateClienteCommand>
    {
        public CreateClienteValidator()
        {
            RuleFor(x => x.NomeRazaoSocial)
                        .NotEmpty().WithMessage("Nome/Razão Social é obrigatório.");

            RuleFor(x => x.CpfCnpj)
                .NotEmpty().WithMessage("CPF/CNPJ é obrigatório.");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("E-mail inválido.")
                .NotEmpty().WithMessage("E-mail é obrigatório.");

            RuleFor(x => x.TipoPessoa)
                .IsInEnum();

            When(x => x.TipoPessoa == TipoPessoa.Fisica, () => {
                RuleFor(x => x.DataNascimento)
                    .Must(d => d <= DateTime.Today.AddYears(-18))
                    .WithMessage("Cliente deve ter no mínimo 18 anos.");
            });

            When(x => x.TipoPessoa == TipoPessoa.Juridica && !x.IsentoIE, () => {
                RuleFor(x => x.InscricaoEstadual)
                    .NotEmpty().WithMessage("IE é obrigatório para PJ não isento.");
            });

            RuleFor(x => x.Endereco).NotNull();

        }
    }
}
