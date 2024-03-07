using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.Models.ETLModel;
using Microsoft.EntityFrameworkCore;

namespace TSI_ERP_ETL.Front_Api.Fournisseur
{
    public class FournisseurService
    {
        private readonly ETLDbContext _context;

        public FournisseurService(ETLDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FournisseurETLModel>> GetFournisseursAsync()
        {
            return await _context.Fournisseur.ToListAsync();
        }
    }
}