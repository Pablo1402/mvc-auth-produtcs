using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> entity)
        {
            entity.ToTable("ENDERECOS");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Logadouro)
             .IsRequired()
             .HasColumnType("varchar(1000)");

            entity.Property(x => x.Numero)
                .IsRequired()
                .HasColumnType("varchar(10)");

            entity.Property(x => x.Bairro)
                .IsRequired()
                .HasColumnType("varchar(200)");

            entity.Property(x => x.Estado)
                .IsRequired()
                .HasColumnType("varchar(2)");

            entity.Property(x => x.Cep)
            .IsRequired()
            .HasColumnType("varchar(8)");

            entity.Property(x => x.Cidade)
            .IsRequired()
            .HasColumnType("varchar(200)");


            entity.Property(x => x.Complemento)
            .IsRequired()
            .HasColumnType("varchar(2000)");
        }

     
    }
}
