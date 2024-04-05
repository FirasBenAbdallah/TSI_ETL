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

        public async Task<(IEnumerable<FicheFournisseurETLModel> data, int totalCount)> GetFicheFournisseursPagedAsync(int pageNumber, int pageSize)
        {
            var totalCount = await _context.FicheFournisseur.CountAsync();
            var pagedData = await _context.FicheFournisseur
                                        .Skip((pageNumber - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();
            return (pagedData, totalCount);
        }
    }
}