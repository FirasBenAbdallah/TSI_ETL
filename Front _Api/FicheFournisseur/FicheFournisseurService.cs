using Microsoft.EntityFrameworkCore;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.Front_Api.FicheFournisseur
{
    public class FicheFournisseurService : IFicheFournisseurService
    {
        private readonly ETLDbContext _context;
        public FicheFournisseurService(ETLDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FicheFournisseurETLModel>> GetFicheFournisseursAsync()
        {
            return await _context.FicheFournisseur.ToListAsync();
        }
    }
}