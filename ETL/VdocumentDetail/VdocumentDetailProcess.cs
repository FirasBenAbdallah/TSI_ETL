﻿using Microsoft.Extensions.Configuration;
using TSI_ERP_ETL.TableUtilities;

namespace TSI_ERP_ETL.ETL.VdocumentDetail
{
    public class VdocumentDetailProcess 
    {
        public static async Task ProcessVdocumentDetailAsync()
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
            await TableTruncate.TruncateTable(connectionString, "documentDetail");

            // Extract data from the API endpoint
            var extractedData = await VdocumentDetailExtract.ExtractVdocumentDetailAsync(apiUrl, loginUrl);

            // Transform the data before loading it into the database
            var transformedData = VdocumentDetailTransform.TransformVdocumentDetail(extractedData);

            // Load the data into the database
            await VdocumentDetailLoad.LoadVdocumentDetailAsync(transformedData, connectionString);

            // Log the process completion message for the Devise ETL process
            Console.WriteLine("VdocumentDetail ETL process completed successfully.");
        }
    }
}
