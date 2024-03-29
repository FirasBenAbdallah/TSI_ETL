using Microsoft.EntityFrameworkCore;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.TableUtilities;

namespace TSI_ERP_ETL.ETL.Client
{
    public class ClientProcess
    {
        public static async Task ProcessClientAsync(ErpApiClient erpApiClient)
        {
            {
                // Configure DbContext
                var optionsBuilder = new DbContextOptionsBuilder<ETLDbContext>();
                optionsBuilder.UseSqlServer(erpApiClient.DbConnection!);
                var context = new ETLDbContext(optionsBuilder.Options);

                // Instantiate FournisseurLoad with DbContext
                var clientLoad = new ClientLoad(context);

                // Utiliser BaseUrl de l'instance erpApiClient
                string apiUrl = erpApiClient.BaseUrl!;

                // Vérifier si la table "Document" existe
                bool tableExists = await DatabaseHelper.TableExistsAsync(erpApiClient.DbConnection!, "Client");
                if (!tableExists)
                {
                    Console.WriteLine("La table n'existe pas. Procéder à l'initialisation.");

                    await TableCreate.CreateTable(erpApiClient.DbConnection!, "Client", "Code NVARCHAR(50), Nom NVARCHAR(150)");
                }
                else
                {
                    Console.WriteLine("La table existe déjà. Ignorer l'initialisation.");

                    // Tronquer la table avant de charger de nouvelles données
                    await TableTruncate.TruncateTable(erpApiClient.DbConnection!, "Client");
                }
                // Extracy data from the API endpoint
                var extractedData = await ClientExtract.ExtractClientAsync(erpApiClient.DbOlmiConnection!);

                // Transformer les données avant de les charger dans la base de données
                var transformedData = ClientTransform.ClientsTransform(extractedData);

                // Charger les données transformées dans la base de données
                await clientLoad.LoadClientlAsync(transformedData);

                // Enregistrer le message de fin du processus ETL Document
                Console.WriteLine("Le processus ETL Client s'est terminé avec succès.");
            }
        }
    }
}
