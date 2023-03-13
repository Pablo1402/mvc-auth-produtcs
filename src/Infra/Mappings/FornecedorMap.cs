using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> entity)
        {
            entity.ToTable("FORNECEDORES");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            entity.Property(x => x.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)");

            entity.HasOne(x => x.Endereco)
                .WithOne(x => x.Fornecedor);

            entity.HasMany(x => x.Produtos)
                .WithOne(x => x.Fornecedor)
                .HasForeignKey(x => x.FornecedorId);

        }
    }
}
