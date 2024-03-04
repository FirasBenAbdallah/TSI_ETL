using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TSI_ERP_ETL.TableUtilities;
using TSI_ERP_ETL.Erp_ApiEndpoints;

namespace TSI_ERP_ETL.ETL.Document
{
    public class DocumentProcess
    {
        public static async Task ProcessDocumentAsync(string token, ErpApiClient erpApiClient)
        {
            if (token is null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            {
                // Configurer DbContext
                var optionsBuilder = new DbContextOptionsBuilder<ETLDbContext>();
                optionsBuilder.UseSqlServer(erpApiClient.DbConnection!);
                var context = new ETLDbContext(optionsBuilder.Options);

                // Instancier DocumentLoad avec DbContext
                var documentLoad = new DocumentLoad(context);

                // Utiliser BaseUrl de l'instance erpApiClient
                string apiUrl = erpApiClient.BaseUrl!;
                string loginUrl = erpApiClient.LoginUrl!;

                // Tronquer la table avant de charger de nouvelles données
                // Vérifier si la table "Document" existe
                bool tableExists = await DatabaseHelper.TableExistsAsync(erpApiClient.DbConnection!, "Document");
                if (!tableExists)
                {
                    Console.WriteLine("La table n'existe pas. Procéder à l'initialisation.");
                    await TableCreate.CreateTable(erpApiClient.DbConnection!, "Document", "Devise uniqueidentifier PRIMARY KEY, NumDocument varchar(max) null");
                }
                else
                {
                    Console.WriteLine("La table existe déjà. Ignorer l'initialisation.");
                    // Tronquer la table avant de charger de nouvelles données
                    await TableTruncate.TruncateTable(erpApiClient.DbConnection!, "document");
                }
                // Extraire les données à partir du point d'API
                var extractedData = await DocumentExtract.ExtractDocumentAsync(apiUrl, loginUrl);

                // Transformer les données avant de les charger dans la base de données

                var transformedData = DocumentTransform.TransformDocument(extractedData);

                // Charger les données dans la base de données
                await documentLoad.LoadDocumentAsync(transformedData);

                // Enregistrer le message de fin du processus ETL Document
                Console.WriteLine("Le processus ETL Document s'est terminé avec succès.");
            }
        }
    }
}

