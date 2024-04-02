using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.Models;
using TSI_ERP_ETL.Models.ETLModel;
using TSI_ERP_ETL.Resource;

namespace TSI_ERP_ETL.ETL.FicheFournisseur
{
    public class FicheFournisseurLoad
    {
        private readonly ETLDbContext _context;

        public FicheFournisseurLoad(ETLDbContext context)
        {
            _context = context;
        }

        public async Task FicheFournisseurLoadAsync(IEnumerable<FicheFournisseurETLModel> data)
        {
            try
            {
                // Parcourir les données fournies
                foreach (var item in data)
                {
                    // Créer un nouvel objet ClientETLModel
                    FicheFournisseurETLModel fournisseur = new(item.Id, item.Code, item.Nom, item.Debit, item.Credit, item.Solde);

                    // Ajouter l'objet à la table DocumentDetail
                    await _context.FicheFournisseur.AddAsync(fournisseur);
                }
                // Sauvegarder les changements dans la base de données
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Traiter l'exception DbUpdateException ici
                Console.WriteLine($"Une erreur s'est produite lors de l'enregistrement des modifications de l'entité : {ex.Message}");

                if (ex.InnerException != null)
                {
                    // Traiter l'exception interne ici si nécessaire
                    Console.WriteLine($"Exception interne : {ex.InnerException.Message}");
                }
                // Rejeter l'exception DbUpdateException
                throw;
            }
        }
    }
}
