using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.Front__Api.FicheFournisseur
{
    public class FicheFournisseurService
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
