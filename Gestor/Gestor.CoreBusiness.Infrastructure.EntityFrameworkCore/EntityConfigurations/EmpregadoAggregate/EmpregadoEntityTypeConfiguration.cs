using Gestor.CoreBusiness.Domain.Models.EmpregadoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestor.CoreBusiness.Infrastructure.EntityFrameworkCore.EntityConfigurations.EmpregadoAggregate
{
    internal class EmpregadoEntityTypeConfiguration : IEntityTypeConfiguration<Empregado>
    {
        public void Configure(EntityTypeBuilder<Empregado> builder)
        {
            builder.ToTable("Empregados");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreationDate).IsRequired();
            builder.Property(e => e.CreationUser).HasMaxLength(100).IsRequired(false);
            builder.Property(e => e.Cpf).HasMaxLength(11).IsRequired();
            builder.Property(e => e.Nome).HasMaxLength(100).IsRequired();
            builder.Property(e => e.DataNascimento).IsRequired();
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.Telefone).IsRequired(false);
            builder.Property(e => e.Matricula).IsRequired(false);
            builder.Property(e => e.Status).IsRequired();


            builder.HasIndex(e => e.Cpf).IsUnique();
            builder.HasIndex(e => e.Nome);

            //TODO: adicionar navigation para admissao atual e anteriores
        }
    }
}