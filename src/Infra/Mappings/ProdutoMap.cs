using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> entity)
        {
            entity.ToTable("PRODUTOS");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            entity.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            entity.Property(x => x.Imagem)
                .IsRequired()
                .HasColumnType("varchar(100)");
        }
    }
}
