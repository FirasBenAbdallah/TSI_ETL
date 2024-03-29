using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.Models.ETLModel;
using TSI_ERP_ETL.Models;
using TSI_ERP_ETL.Resource;

namespace TSI_ERP_ETL.ETL.ChiffreAffairesParClient
{
    public class ChiffreAffairesParClientLoad
    {
        private readonly ETLDbContext _context;
        public ChiffreAffairesParClientLoad(ETLDbContext context)
        {
            _context = context;
        }
        public async Task LoadChiffreAffairesParClientAsync(IEnumerable<ChiffreAffairesParClientModel> data)

        {
            try
            {
                foreach (var item in data)
                {
                    var chiffreAffairesClient = new ChiffreAffairesParClientETLModel(item.UIDTier,item.Nom, item.MontantTtc);
                    await _context.ChiffreAffairesParClient.AddAsync(chiffreAffairesClient);
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Une erreur s'est produite lors de l'enregistrement des modifications de l'entité : {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Exception interne : {ex.InnerException.Message}");
                }
                throw;
            }
        }
    }
}
