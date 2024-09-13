using Microsoft.EntityFrameworkCore;
using ERP_InsightWise.Database.Models;
using ERP_InsightWise.Database.Mappings;

namespace ERP_InsightWise.Database
{
    public class FIAPDBContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }

        public FIAPDBContext(DbContextOptions<FIAPDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FuncionarioMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
