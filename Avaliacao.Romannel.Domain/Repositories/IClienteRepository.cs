using Avaliacao.Romannel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.Romannel.Domain.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> AdicionarCliente(Cliente cliente, CancellationToken cancellationToken);

        Task<bool> PesquisaPorCnpjEmail(string cpfcnpj, string email, CancellationToken cancellationToken);

        Task<Cliente> PesquisaClientePorId(long idCliente, CancellationToken cancellationToken);

        Task<bool> DeleteClientePorId(long idCliente, CancellationToken cancellationToken);
    }
}
