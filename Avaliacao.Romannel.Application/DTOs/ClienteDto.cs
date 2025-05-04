using Avaliacao.Romannel.Domain.Entities;
using Avaliacao.Romannel.Domain.Enums;

namespace Avaliacao.Romannel.Application.DTOs
{
    public class ClienteDto
    {
        public long IdCliente { get; set; }
        public string NomeRazaoSocial { get; set; }
        public string CpfCnpj { get; set; } // CPF ou CNPJ
        public TipoPessoa TipoPessoa { get; set; }
        public DateTime DataNascimento { get; set; }
        public string TelefoneCel { get; set; }
        public string Email { get; set; }
        public bool IsentoIE { get; set; }
        public string InscricaoEstadual { get; set; }
    }
}
