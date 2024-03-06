using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.TableUtilities;

namespace TSI_ERP_ETL.ETL.Devise
{
    public class DeviseProcess
    {
        public static async Task ProcessDeviseAsync(string token, ErpApiClient erpApiClient)
        {
            // Truncate the table before loading new data
            await TableTruncate.TruncateTable(erpApiClient.DbConnection!, "devise");

            // Extracy data from the API endpoint
            var extractedData = await DeviseExtract.ExtractDeviseAsync(erpApiClient.BaseUrl!, token);

            // Transform the data before loading it into the database
            var transformedData = DeviseTransform.TransformData(extractedData);

            // Load the data into the database
            await DeviseLoad.LoadDataAsync(transformedData, erpApiClient.DbConnection!);

            // Log the process completion message for the Devise ETL process
            Console.WriteLine("Devise ETL process completed successfully.\n");
        }
    }
}
