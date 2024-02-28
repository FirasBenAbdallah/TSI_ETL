using Microsoft.EntityFrameworkCore;
using TSI_ERP_ETL.Models;
using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.Erp_ApiEndpoints
{
    public class ETLDbContext : DbContext
    {
        //public DbSet<FournisseurETLModel> Fournisseurs { get; set; }
        public DbSet<TierModel> Fournisseur { get; set; }
        public ETLDbContext(DbContextOptions<ETLDbContext> options) : base(options) { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FournisseurETLModel>().HasKey(f => f.FournisseurId);
        }
    }
}

