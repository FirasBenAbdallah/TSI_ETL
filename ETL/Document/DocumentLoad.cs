using Microsoft.EntityFrameworkCore;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.Models.Document;
using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.ETL.Document
{
    public class DocumentLoad
    {
        private readonly ETLDbContext _context;

        public DocumentLoad(ETLDbContext context)
        {
            _context = context;
        }
        public async Task LoadDocumentAsync(IEnumerable<DocumentModel> data)
        {
            try
            {
                // Parcourir les données fournies
                foreach (var item in data)
                {
                    // Créer un nouvel objet DocumentETLModel
                    var document = new DocumentETLModel(item.Uid, item.MontantTtc);

                    // Ajouter l'entité nouvellement créée au DbSet du contexte
                    await _context.Document.AddAsync(document);
                }
                // Sauvegarder les changements dans la base de données
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Gérer les erreurs lors de la sauvegarde des changements dans la base de données
                // Enregistrez l'erreur ou inspectez l'exception interne
                Console.WriteLine($"Une erreur s'est produite lors de l'enregistrement des modifications de l'entité : {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Exception interne : {ex.InnerException.Message}");
                }

                // Éventuellement, relancer l'exception si vous ne pouvez pas la gérer ici
                throw;
            }
        }
    }
}

