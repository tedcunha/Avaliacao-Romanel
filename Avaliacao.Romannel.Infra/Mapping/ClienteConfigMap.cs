using Avaliacao.Romannel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avaliacao.Romannel.Infra.Mapping
{
    public class ClienteConfigMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(c => c.IdCliente);
            builder.Property(c => c.NomeRazaoSocial).IsRequired().HasMaxLength(50);
            builder.Property(c => c.CpfCnpj).IsRequired().HasMaxLength(14);
            builder.Property(c => c.DataNascimento).IsRequired();
            builder.Property(c => c.TelefoneCel).HasMaxLength(11);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(100);
            builder.Property(c => c.CreateAt).IsRequired();
            builder.Property(c => c.UpdateAt);
            builder.Property(c => c.Ativo).IsRequired();
            builder.Property(c => c.TipoPessoa).IsRequired();
            builder.Property(c => c.IsentoIE).IsRequired();
            builder.Property(c => c.InscricaoEstadual).HasMaxLength(20);
        }
    }
}
