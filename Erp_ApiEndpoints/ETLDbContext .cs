using Microsoft.EntityFrameworkCore;
using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.Erp_ApiEndpoints
{
    public class ETLDbContext : DbContext
    {
        public DbSet<DocumentETLModel> Document { get; set; }
        public DbSet<DocumentDetailETLModel> DocumentDetail { get; set; }
        public DbSet<ArticleETLModel> Article { get; set; }
        public DbSet<FournisseurETLModel> Fournisseur { get; set; }
        //public DbSet<TierModel> Fournisseur { get; set; }
        public DbSet<ChiffreAffairesParClientETLModel> ChiffreAffairesParClient { get; set; }

        public ETLDbContext(DbContextOptions<ETLDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FournisseurETLModel>().HasKey(f => f.FournisseurId);
            //modelBuilder.Entity<DocumentCreateRequest>().HasKey(f => f.Devise);
            modelBuilder.Entity<DocumentETLModel>().HasKey(f => f.Devise);
            modelBuilder.Entity<DocumentDetailETLModel>().HasKey(f => f.Devise);
            modelBuilder.Entity<ArticleETLModel>().HasKey(f => f.Uid);
            modelBuilder.Entity<ChiffreAffairesParClientETLModel>().HasKey(f => f.UIDTier);
        }
    }
}
