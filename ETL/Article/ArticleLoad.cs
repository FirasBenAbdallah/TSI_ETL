using Microsoft.EntityFrameworkCore;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.Models.ETLModel;
using TSI_ERP_ETL.Models;

namespace TSI_ERP_ETL.ETL.Article
{
    public class ArticleLoad
    {
        private readonly ETLDbContext _context;

        public ArticleLoad(ETLDbContext context)
        {
            _context = context;
        }

        public async Task LoadArticlelAsync(IEnumerable<ArticleModel> data)
        {
            try
            {
                // Parcourir les données fournies
                foreach (var item in data)
                {
                    // Créer un nouvel objet ArticleETLModel
                    ArticleETLModel article = new(item.Uid, item.Code, item.CodeAbarres, item.Libelle, item.PrixUnitaireAchat, item.TauxTva, item.PrixUnitaireVente, item.PrixVenteTtc, item.FamilleArticle, item.CodeFournisseur, item.Active, item.Vendu, item.Achete);

                    // Ajouter l'objet à la table DocumentDetail
                    await _context.Article.AddAsync(article);
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
