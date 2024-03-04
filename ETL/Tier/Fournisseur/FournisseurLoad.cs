using Microsoft.EntityFrameworkCore;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.Models;
using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.ETL.Tier.Fournisseur
{
    public class FournisseurLoad
    {
        private readonly ETLDbContext _context;

        public FournisseurLoad(ETLDbContext context)
        {
            _context = context;
        }


        public async Task LoadDataAsync(IEnumerable<TierModel> data)
        {
            try
            {
                foreach (var item in data)
                {
                    var fournisseur = new FournisseurETLModel { FournisseurId = item.Uid, RaisonSocial = item.RaisonSociale };
                    await _context.Fournisseur.AddAsync(fournisseur);
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Log the error or inspect the inner exception
                Console.WriteLine($"An error occurred while saving the entity changes: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }

                // Optionally, rethrow the exception if you cannot handle it here
                throw;
            }
        }
    }
}