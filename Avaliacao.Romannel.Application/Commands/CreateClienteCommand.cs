using Avaliacao.Romannel.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.Romannel.Application.Commands
{
    public class CreateClienteCommand
    {
        public string NomeRazaoSocial { get; set; }
        public string CpfCnpj { get; set; } // CPF ou CNPJ
        public TipoPessoa TipoPessoa { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get;set; }
        public string Endereco { get; set; }
        public string? InscricaoEstadual { get; set; }
        public bool IsentoIE { get; set; }
    }
}
