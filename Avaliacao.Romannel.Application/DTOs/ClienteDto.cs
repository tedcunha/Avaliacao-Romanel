using Avaliacao.Romannel.Domain.Enums;

namespace Avaliacao.Romannel.Application.DTOs
{
    public class ClienteDto
    {
        public string NomeRazaoSocial { get; set; } = string.Empty;
        public string CpfCnpj { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string TelefoneCel { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CEP { get; set; } = string.Empty;
        public string Rua { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public TipoPessoa TipoPessoa { get; set; }
        public string? InscricaoEstadual { get; set; } = string.Empty;
        public bool IsentoIE { get; set; }

    }
}
