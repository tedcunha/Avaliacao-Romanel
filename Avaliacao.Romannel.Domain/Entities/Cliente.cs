namespace Avaliacao.Romannel.Domain.Entities
{
    public class Cliente
    {
        public long IdCliente { get; private set; }
        public string NomeRazaoSocial { get; private set; }
        public string CpfCnpj { get; private set; } // CPF ou CNPJ
        public DateTime DataNascimento { get; private set; }
        public string TelefoneCel { get; private set; }
        public string Email { get; private set; }
        public DateTime CreateAt { get; private set; }
        public DateTime? UpdateAt { get; private set; }
        public bool Ativo { get; private set; }
        public ClienteComplemento  ClienteComplemento { get; private set; }

        public Cliente(string nomerazaosocial, 
                       string cpfcnpj, 
                       DateTime datanascimento, 
                       string telefonecel, 
                       string email, 
                       bool ativo)
        {
            NomeRazaoSocial = nomerazaosocial;
            CpfCnpj = CpfCnpj;
            DataNascimento = datanascimento;
            TelefoneCel = telefonecel;
            Email = email;
            CreateAt = DateTime.Now;
            Ativo = ativo;
        }
    }
}
