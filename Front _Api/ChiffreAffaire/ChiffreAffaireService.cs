using Microsoft.EntityFrameworkCore;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.Front_Api.ChiffreAffaire
{
    public class ChiffreAffaireService : IChiffreAffaireService
    {
        private readonly ETLDbContext _context;

        public ChiffreAffaireService(ETLDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DocumentDetailETLModel>> GetChiffreAffaireAsync()
        {
            return await _context.DocumentDetail.Where(x => x.DateFilter!.HasValue && x.DateFilter!.Value.Year > 1900).OrderBy(x => x.Quantite!.Value).ToListAsync();
        }

        public async Task<IEnumerable<DocumentDetailETLModel>> FilterChiffreAffaireByYearAsync(int year)
        {
            //return await _context.DocumentDetail.Where(x => x.DateFilter.Year == year).ToListAsync();
            return await _context.DocumentDetail.Where(x => x.DateFilter.HasValue && x.DateFilter.Value.Year == year).ToListAsync();

        }

        public async Task<IEnumerable<DocumentDetailETLModel>> FilterChiffreAffaireByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.DocumentDetail
                .Where(x => x.DateFilter.HasValue &&
                            x.DateFilter.Value >= startDate &&
                            x.DateFilter.Value <= endDate)
                .OrderBy(x => x.DateFilter!.Value)
                .ToListAsync();
        }
    }
}
