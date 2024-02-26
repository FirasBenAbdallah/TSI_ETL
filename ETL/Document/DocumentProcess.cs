using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSI_ERP_ETL.TableUtilities;

namespace TSI_ERP_ETL.ETL.Document
{
    public class DocumentProcess
    {
        public static async Task ProcessDocumentAsync()
        {
            // Build configuration from appsettings.json
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ApiEndpoints/appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Create an instance of ErpApiClient
            var erpApiClient = new ErpApiClient(configuration);

            // Connection string to the database
            string connectionString = erpApiClient.DbConnection!;

            // Use the BaseUrl from erpApiClient instance
            string apiUrl = erpApiClient.BaseUrl!;

            // Use the LoginUrl from erpApiClient instance
            string loginUrl = erpApiClient.LoginUrl!;

            // Truncate the table before loading new data
            await TableTruncate.TruncateTable(connectionString, "Document");

            // Extracy data from the API endpoint
            var extractedData = await DocumentExtract.ExtractDocumentAsync(apiUrl, loginUrl);

            // Transform the data before loading it into the database
            var transformedData = DocumentTransform.TransformDocument(extractedData);

            // Load the data into the database
            var documentLoad = new DocumentLoad();
            await documentLoad.LoadDocumentAsync(transformedData, connectionString);

            //await DocumentLoad.LoadDocumentAsync(transformedData, connectionString);

            // Log the process completion message for the Devise ETL process
            Console.WriteLine("Document ETL process completed successfully.");
        }
    }
}
