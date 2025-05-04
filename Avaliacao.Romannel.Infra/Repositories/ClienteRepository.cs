using Avaliacao.Romannel.Domain.Entities;
using Avaliacao.Romannel.Domain.Repositories;
using Avaliacao.Romannel.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.Romannel.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _appDbContext;

        public ClienteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Cliente> AdicionarCliente(Cliente cliente, CancellationToken cancellationToken)
        {
            try
            {
                await _appDbContext.Clientes.AddAsync(cliente);
                await _appDbContext.SaveChangesAsync();
                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteClientePorId(long idCliente, CancellationToken cancellationToken)
        {
            var cliente = await _appDbContext.Clientes.FirstOrDefaultAsync(c => c.IdCliente == idCliente);

            if (cliente == null)
            return false;

            _appDbContext.Clientes.RemoveRange(cliente);
            await _appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Cliente> PesquisaClientePorId(long idCliente, CancellationToken cancellationToken)
        {
            return await _appDbContext.Clientes.FirstOrDefaultAsync(c => c.IdCliente == idCliente);
        }

        public async Task<bool> PesquisaPorCnpjEmail(string cpfcnpj, string email, CancellationToken cancellationToken)
        {
            return await _appDbContext.Clientes.AnyAsync(c => c.CpfCnpj == cpfcnpj.Trim() && c.Email == email.Trim());
        }
    }
}
