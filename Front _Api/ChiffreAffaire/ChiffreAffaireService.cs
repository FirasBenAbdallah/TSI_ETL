using Microsoft.EntityFrameworkCore;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.Front_Api.ChiffreAffaire
{
    public class ChiffreAffaireService
    {
        private readonly ETLDbContext _context;

        public ChiffreAffaireService(ETLDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DocumentDetailETLModel>> GetChiffreAffaireAsync()
        {
            return await _context.DocumentDetail.ToListAsync();
        }
    }
}
