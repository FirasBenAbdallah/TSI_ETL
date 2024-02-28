using Microsoft.EntityFrameworkCore;
using TSI_ERP_ETL.Models.Document;
using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.ApiEndpoints
{
    public class ETLDbContext : DbContext
    {
        public DbSet<DocumentETLModel> Document { get; set; }

        public DbSet<FournisseurETLModel> Fournisseur { get; set; }
        public ETLDbContext(DbContextOptions<ETLDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FournisseurETLModel>().HasKey(f => f.FournisseurId);
            //modelBuilder.Entity<DocumentCreateRequest>().HasKey(f => f.Devise);
            modelBuilder.Entity<DocumentETLModel>().HasKey(f => f.Devise);
        }
}
}

