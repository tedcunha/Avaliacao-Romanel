using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.Romannel.Domain.Entities
{
    public class ClienteComplemento
    {
        public long idComplemento { get; private set; }
        public long IdCliente { get; private set; }
        public string Endereco { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public DateTime CreatAt { get; private set; }
        public DateTime? UpdateAt { get; private set; }
        public bool Ativo { get; private set; }

        public ClienteComplemento(long idcliente,
                                  string endereco,
                                  string numero,
                                  string complemento,
                                  string bairro,
                                  string cidade,
                                  string estado,
                                  bool ativo)
        {
            IdCliente = idcliente;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            CreatAt = DateTime.Now;
            Ativo = ativo;
    }
    }
}
