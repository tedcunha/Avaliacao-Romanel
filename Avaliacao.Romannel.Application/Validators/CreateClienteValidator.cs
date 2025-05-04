using Avaliacao.Romannel.Domain.Enums;
using FluentValidation;
using Avaliacao.Romannel.Domain.Entities;

namespace Avaliacao.Romannel.Application.Validators
{
    public class CreateClienteValidator : AbstractValidator<Cliente>
    {
        public CreateClienteValidator()
        {
            RuleFor(x => x.NomeRazaoSocial)
                .NotEmpty().WithMessage("Nome/Razão Social é obrigatório");

            RuleFor(x => x.CpfCnpj)
                .NotEmpty().WithMessage("CPF/CNPJ é obrigatório")
                .Must(ValidarDocumento).WithMessage("CPF/CNPJ inválido");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-mail é obrigatório")
                .EmailAddress().WithMessage("E-mail inválido");

            RuleFor(x => x.TelefoneCel).NotEmpty().WithMessage("Telefone é obrigatório");

            When(x => x.TipoPessoa == TipoPessoa.Fisica, () => {
                RuleFor(x => x.DataNascimento)
                    .Must(d => d <= DateTime.Today.AddYears(-18))
                    .WithMessage("Cliente deve ter no mínimo 18 anos.");
            });

            When(x => x.TipoPessoa == TipoPessoa.Juridica, () =>
            {
                RuleFor(x => x.IsentoIE)
                    .Equal(true).When(x => string.IsNullOrWhiteSpace(x.InscricaoEstadual))
                    .WithMessage("Informe a IE ou marque como isento");
            });

        }

        private bool ValidarDocumento(string doc)
        {
            return doc.Length == 11 || doc.Length == 14; // Simplificado: 11 = CPF, 14 = CNPJ
        }
    }
}
