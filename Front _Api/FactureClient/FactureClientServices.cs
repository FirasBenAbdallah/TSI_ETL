using Microsoft.EntityFrameworkCore;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.Models;

namespace TSI_ERP_ETL.Front__Api.FactureClient
{
    public class FactureClientServices : IFactureClientServices
    {
        private readonly ETLDbContext _context;

        public FactureClientServices(ETLDbContext context)
        {
            _context = context;
        }

        // Get all articles :
        public async Task<IEnumerable<FactureClientModel>> GetFacturesClientsAsync()
        {
            return await _context.FactureClient.ToListAsync();
        }
    }
}
