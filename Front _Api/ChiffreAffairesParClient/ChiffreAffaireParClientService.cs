using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.Front__Api.ChiffreAffairesParClient
{
    public class ChiffreAffaireParClientService
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
    }
}
