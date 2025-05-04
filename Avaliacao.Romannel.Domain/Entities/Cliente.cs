using Avaliacao.Romannel.Domain.Enums;

namespace Avaliacao.Romannel.Domain.Entities
{
    public class Cliente
    {
        public long IdCliente { get;  set; }
        public string NomeRazaoSocial { get; set; }
        public string CpfCnpj { get; set; } // CPF ou CNPJ
        public int TipoPessoa { get; set; }
        public DateTime DataNascimento { get; set; }
        public string TelefoneCel { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool Ativo { get; set; }
        public bool IsentoIE { get; set; }
        public string InscricaoEstadual { get; set; }
    }
}
