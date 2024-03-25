using Microsoft.EntityFrameworkCore;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.TableUtilities;

namespace TSI_ERP_ETL.ETL.Article
{
    public class ArticleProcess
    {
        public static async Task ProcessArticleAsync(string token, ErpApiClient erpApiClient)
        {
            {
                // Configure DbContext
                var optionsBuilder = new DbContextOptionsBuilder<ETLDbContext>();
                optionsBuilder.UseSqlServer(erpApiClient.DbConnection!);
                var context = new ETLDbContext(optionsBuilder.Options);

                // Instantiate FournisseurLoad with DbContext
                var articleLoad = new ArticleLoad(context);

                // Utiliser BaseUrl de l'instance erpApiClient
                string apiUrl = erpApiClient.BaseUrl!;

                // Vérifier si la table "Document" existe
                bool tableExists = await DatabaseHelper.TableExistsAsync(erpApiClient.DbConnection!, "Article");
                if (!tableExists)
                {
                    Console.WriteLine("La table n'existe pas. Procéder à l'initialisation.");

                    await TableCreate.CreateTable(erpApiClient.DbConnection!, "Article", "Uid UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,Code NVARCHAR(255),CodeAbarres NVARCHAR(255),Libelle NVARCHAR(MAX),PrixUnitaireAchat DECIMAL(18, 2),TauxTva FLOAT,PrixUnitaireVente FLOAT,PrixVenteTtc DECIMAL(18, 2),FamilleArticle UNIQUEIDENTIFIER,CodeFournisseur NVARCHAR(255),Active BIT,Vendu BIT,Achete BIT");
                }
                else
                {
                    Console.WriteLine("La table existe déjà. Ignorer l'initialisation.");

                    // Tronquer la table avant de charger de nouvelles données
                    await TableTruncate.TruncateTable(erpApiClient.DbConnection!, "Article");
                }
                // Extraire les données à partir du point d'API
                var extractedData = await ArticleExtract.ExtractArticleAsync(apiUrl, token);

                // Transformer les données avant de les charger dans la base de données
                var transformedData = ArticleTransform.ArticlesTransform(extractedData);

                // Charger les données transformées dans la base de données
                await articleLoad.LoadArticlelAsync(transformedData);

                // Enregistrer le message de fin du processus ETL Document
                Console.WriteLine("Le processus ETL Document s'est terminé avec succès.");
            }
        }
    }
}
