using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.Romannel.Application.DTOs
{
    public class ClienteComplementoDto
    {
        public string Endereco { get; private set; } = string.Empty;
        public string Numero { get; private set; } = string.Empty;
        public string Complemento { get; private set; } = string.Empty;
        public string Bairro { get; private set; } = string.Empty;
        public string Cidade { get; private set; } = string.Empty;
        public string Estado { get; private set; } = string.Empty;

    }
}
