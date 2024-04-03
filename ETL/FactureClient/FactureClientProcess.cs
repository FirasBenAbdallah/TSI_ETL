using Microsoft.EntityFrameworkCore;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.TableUtilities;

namespace TSI_ERP_ETL.ETL.FactureClient
{
    public class FactureClientProcess
    {
        public static async Task ProcessFactureClientAsync(ErpApiClient erpApiClient)
        {
            // Configure DbContext
            var optionsBuilder = new DbContextOptionsBuilder<ETLDbContext>();
            optionsBuilder.UseSqlServer(erpApiClient.DbConnection!);
            var context = new ETLDbContext(optionsBuilder.Options);

            // Instantiate FactureClientLoad with DbContext
            var factureClientLoad = new FactureClientLoad(context);

            // Vérifier si la table "FactureClient" existe
            bool tableExists = await DatabaseHelper.TableExistsAsync(erpApiClient.DbConnection!, "FactureClient");
            if (!tableExists)
            {
                Console.WriteLine("La table n'existe pas. Procéder à l'initialisation.");

                await TableCreate.CreateTable(erpApiClient.DbConnection!, "FactureClient", "Id INT NOT NULL, NumDocument NVARCHAR(50), Realisation NVARCHAR(50), MontantTTC DECIMAL(18,2), Code NVARCHAR(50), Nom NVARCHAR(150), Libelle NVARCHAR(150), MontantRecouvrement DECIMAL(18,2)");
            }
            else
            {
                Console.WriteLine("La table existe déjà. Ignorer l'initialisation.");

                // Tronquer la table avant de charger de nouvelles données
                await TableTruncate.TruncateTable(erpApiClient.DbConnection!, "FactureClient");
            }
            // Extract data from the API endpoint
            var extractedData = await FactureClientExtract.ExtractFactureClientAsync(erpApiClient.DbOlmiConnection!);

            // Transform the data before loading it into the database
            var transformedData = FactureClientTransform.FactureClientsTransform(extractedData);

            // Load the transformed data into the database
            await factureClientLoad.LoadFactureClientAsync(transformedData);

            // Save the end message of the FactureClient ETL process
            Console.WriteLine("Le processus ETL FactureClient s'est terminé avec succès.");
        }
    }
}
