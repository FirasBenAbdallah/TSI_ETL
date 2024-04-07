using Microsoft.EntityFrameworkCore;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.Front_Api.FactureClient
{
    public class FactureClientServices : IFactureClientServices
    {
        private readonly ETLDbContext _context;

        public FactureClientServices(ETLDbContext context)
        {
            _context = context;
        }

        // Get all articles :
        public async Task<IEnumerable<FactureClientETLModel>> GetFacturesClientsAsync()
        {
            return await _context.FactureClient.ToListAsync();
        }

        // Get articles by client code :
        public async Task<IEnumerable<FactureClientETLModel>> GetFacturesByCodeClientAsync(string Code)
        {
            return await _context.FactureClient.Where(x => x.Code == Code).ToListAsync();
        }

        public async Task<(IEnumerable<FactureClientETLModel> data, int totalCount)> GetFacturesClientsPagedAsync(int pageNumber, int pageSize)
        {
            var totalCount = await _context.FactureClient.CountAsync();
            var pagedData = await _context.FactureClient
                                        .Skip((pageNumber - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();
            if (pageNumber * pageSize > totalCount + pageSize)
            {
                return (pagedData, totalCount);
            }
            return (pagedData, totalCount);
        }
    }
}
