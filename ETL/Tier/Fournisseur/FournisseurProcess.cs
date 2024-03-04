using Microsoft.EntityFrameworkCore;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.TableUtilities;

namespace TSI_ERP_ETL.ETL.Tier.Fournisseur
{
    public class FournisseurProcess
    {
        public static async Task ProcessFournisseurAsync(string token, ErpApiClient erpApiClient)
        {
            // Configure DbContext
            var optionsBuilder = new DbContextOptionsBuilder<ETLDbContext>();
            optionsBuilder.UseSqlServer(erpApiClient.DbConnection!);
            var context = new ETLDbContext(optionsBuilder.Options);

            // Instantiate FournisseurLoad with DbContext
            var fournisseurLoad = new FournisseurLoad(context);

            // Use the BaseUrl from erpApiClient instance
            string apiUrl = erpApiClient.BaseUrl!;

            // Check if the "Fournisseur" table exists
            bool tableExists = await DatabaseHelper.TableExistsAsync(erpApiClient.DbConnection!, "Fournisseur");
            if (!tableExists)
            {
                Console.WriteLine("Table does not exist. Proceed with initialization.");
                await TableCreate.CreateTable(erpApiClient.DbConnection!, "Fournisseur", "FournisseurId uniqueidentifier PRIMARY KEY, RaisonSocial nvarchar(max) null");
            }
            else
            {
                Console.WriteLine("Table already exists. Skipping initialization.");
                // Truncate the table before loading new data
                await TableTruncate.TruncateTable(erpApiClient.DbConnection!, "fournisseur");
            }

            // Extract data from the API endpoint
            var extractedData = await TierExtract.ExtractTierAsync(apiUrl, token);

            // Transform the data before loading it into the database
            var transformedData = FournisseurTransform.TransformFournisseurData(extractedData);

            // Load the data into the database
            await fournisseurLoad.LoadDataAsync(transformedData);

            // Log the process completion message for the Fournisseur ETL process
            Console.WriteLine("Fournisseur ETL process completed successfully.\n");
        }

    }
}