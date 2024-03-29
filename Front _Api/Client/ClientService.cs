using Microsoft.EntityFrameworkCore;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.Front_Api.Client
{
    public class ClientService : IClientService
    {
        private readonly ETLDbContext _context;
        public ClientService(ETLDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClientETLModel>> GetClientsWithArticlesAsync()
        {
            return await _context.ClientETL.ToListAsync();
        }
    }
}
