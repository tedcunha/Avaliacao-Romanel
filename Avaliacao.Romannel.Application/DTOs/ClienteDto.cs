using Avaliacao.Romannel.Domain.Entities;
using Avaliacao.Romannel.Domain.Enums;

namespace Avaliacao.Romannel.Application.DTOs
{
    public class ClienteDto
    {
        public string NomeRazaoSocial { get; private set; }
        public string CpfCnpj { get; private set; } // CPF ou CNPJ
        public TipoPessoa TipoPessoa { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string TelefoneCel { get; private set; }
        public string Email { get; private set; }
        public bool IsentoIE { get; private set; }
        public string? InscricaoEstadual { get; private set; }
        public ClienteComplementoDto ClienteComplemento { get; private set; } = new ClienteComplementoDto();

    }
}
