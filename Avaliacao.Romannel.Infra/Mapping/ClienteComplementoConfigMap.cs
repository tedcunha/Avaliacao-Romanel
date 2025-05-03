using Avaliacao.Romannel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avaliacao.Romannel.Infra.Mapping
{
    public class ClienteComplementoConfigMap : IEntityTypeConfiguration<ClienteComplemento>
    {
        public void Configure(EntityTypeBuilder<ClienteComplemento> builder)
        {
            throw new NotImplementedException();
        }
    }
}
