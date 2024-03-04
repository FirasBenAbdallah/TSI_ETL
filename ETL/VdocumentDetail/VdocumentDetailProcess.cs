using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.TableUtilities;

namespace TSI_ERP_ETL.ETL.VdocumentDetail
{
    public class VdocumentDetailProcess
    {
        public static async Task ProcessVdocumentDetailAsync(string token, ErpApiClient erpApiClient)
        {
            // Configure DbContext
            var optionsBuilder = new DbContextOptionsBuilder<ETLDbContext>();
            optionsBuilder.UseSqlServer(erpApiClient.DbConnection!);
            var context = new ETLDbContext(optionsBuilder.Options);

            // Use the BaseUrl from erpApiClient instance
            string apiUrl = erpApiClient.BaseUrl!;

            // Truncate the table before loading new data
            await TableTruncate.TruncateTable(erpApiClient.DbConnection!, "documentDetail");

            // Extract data from the API endpoint
            var extractedData = await VdocumentDetailExtract.ExtractVdocumentDetailAsync(apiUrl, token);

            // Transform the data before loading it into the database
            var transformedData = VdocumentDetailTransform.TransformVdocumentDetail(extractedData);

            // Load the data into the database
            await VdocumentDetailLoad.LoadVdocumentDetailAsync(transformedData, erpApiClient.DbConnection!);

            // Log the process completion message for the Devise ETL process
            Console.WriteLine("VdocumentDetail ETL process completed successfully.\n");
        }
    }
}
