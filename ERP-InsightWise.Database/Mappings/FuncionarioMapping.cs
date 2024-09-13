using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP_InsightWise.Database.Models;

namespace ERP_InsightWise.Database.Mappings
{
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder
                .ToTable("ERPINSIGHTWISE_FUNCIONARIOS");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.PrimeiroNome)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Sobrenome)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Cargo)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Salario)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder
                .Property(x => x.DataNascimento)
                .IsRequired();

            builder
                .Property(x => x.DataContratacao)
                .IsRequired();

            builder
                .Property(x => x.Endereco)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(x => x.Telefone)
                .HasMaxLength(15)
                .IsRequired();

            builder
                .Property(x => x.Email)
                .HasMaxLength(128)
                .IsRequired();

            builder
                .Property(x => x.Departamento)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Status)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(x => x.Genero)
                .HasMaxLength(10)
                .IsRequired();

            builder
                .Property(x => x.CargaHoraria)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
