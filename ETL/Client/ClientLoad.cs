using Microsoft.EntityFrameworkCore;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.Models;

namespace TSI_ERP_ETL.ETL.Client
{
    public class ClientLoad
    {
        private readonly ETLDbContext _context;

        public ClientLoad(ETLDbContext context)
        {
            _context = context;
        }

        public async Task LoadClientlAsync(IEnumerable<ClientModel> data)
        {
            try
            {
                // Parcourir les données fournies
                foreach (var item in data)
                {
                    // Créer un nouvel objet ClientETLModel
                    ClientModel client = new(item.Code, item.Nom);

                    // Ajouter l'objet à la table DocumentDetail
                    await _context.Client.AddAsync(client);
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
