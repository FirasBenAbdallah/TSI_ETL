using Microsoft.EntityFrameworkCore;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.Models;

namespace TSI_ERP_ETL.ETL.FactureClient
{
    public class FactureClientLoad
    {
        private readonly ETLDbContext _context;

        public FactureClientLoad(ETLDbContext context)
        {
            _context = context;
        }
        public async Task LoadFactureClientAsync(IEnumerable<FactureClientModel> data)
        {
            try
            {
                // Parcourir les données fournies
                foreach (var item in data)
                {
                    // Créer un nouvel objet ClientETLModel
                    FactureClientModel factureClientModel = new(item.Id, item.NumDocument, item.Realisation, item.MontantTTC, item.Code, item.Nom, item.Libelle);

                    // Ajouter l'objet à la table DocumentDetail
                    await _context.FactureClient.AddAsync(factureClientModel);
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
            finally
            {
                // Dispose of the context object
                _context.Dispose();
            }
        }
    }
}
