using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.Front_Api.ChiffreAffairesParClient
{
    public class ChiffreAffaireParClientService : IChiffreAffaireParClientService
    {
        private readonly ETLDbContext _context;
        public ChiffreAffaireParClientService(ETLDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChiffreAffairesParClientETLModel>> GetChiffreAffairesParClientAsync()
        {
            return await _context.ChiffreAffairesParClient.ToListAsync();
        }

        public async Task<(IEnumerable<ChiffreAffairesParClientETLModel> data, int totalCount)> GetChiffreAffairesParClientPagedAsync(int pageNumber, int pageSize)
        {
            var totalCount = await _context.ChiffreAffairesParClient.CountAsync();
            var pagedData = await _context.ChiffreAffairesParClient
                                        .Skip((pageNumber - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();
            return (pagedData, totalCount);
        }
    }
}
