using Microsoft.EntityFrameworkCore;
using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.ApiEndpoints
{
    public class ETLDbContext : DbContext
    {
        public DbSet<FournisseurETLModel> Fournisseur { get; set; }
        public ETLDbContext(DbContextOptions<ETLDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FournisseurETLModel>().HasKey(f => f.FournisseurId);
        }
    }
}

