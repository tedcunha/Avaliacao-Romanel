using Avaliacao.Romannel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avaliacao.Romannel.Infra.Mapping
{
    public class ClienteComplementoConfigMap : IEntityTypeConfiguration<ClienteComplemento>
    {
        public void Configure(EntityTypeBuilder<ClienteComplemento> builder)
        {
            builder.ToTable("dbo.ClienteComplemento");
            builder.HasKey(c => c.idComplemento);

            builder.Property(c => c.IdCliente).IsRequired();
            builder.Property(c => c.Endereco).HasMaxLength(50);
            builder.Property(c => c.Numero).HasMaxLength(10);
            builder.Property(c => c.Complemento).HasMaxLength(50);
            builder.Property(c => c.Bairro).HasMaxLength(50);
            builder.Property(c => c.Cidade).HasMaxLength(50);
            builder.Property(c => c.Estado).HasMaxLength(2);
            builder.Property(c => c.CreatAt).IsRequired();
            builder.Property(c => c.CreatAt);
            builder.Property(c => c.Ativo).IsRequired();
        }
    }
}
