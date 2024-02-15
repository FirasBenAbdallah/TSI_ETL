﻿using Microsoft.Extensions.Configuration;
using TSI_ERP_ETL.TableUtilities;

namespace TSI_ERP_ETL.ETL.Devise
{
    public class DeviseProcess
    {
        public static async Task ProcessDataAsync()
        {
            // Build configuration from appsettings.json
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ApiEndpoints/appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Create an instance of ErpApiClient
            var erpApiClient = new ErpApiClient(configuration);

            // Connection string to the database
            string connectionString = "Data Source=FIRASBA;Initial Catalog=ETL;Integrated Security=True;";

            // Use the BaseUrl from erpApiClient instance
            string apiUrl = erpApiClient.BaseUrl!;

            // Use the LoginUrl from erpApiClient instance
            string loginUrl = erpApiClient.LoginUrl!;

            // Truncate the table before loading new data
            await TableTruncate.TruncateTable(connectionString, "devise");

            // Extracy data from the API endpoint
            var extractedData = await DeviseExtract.ExtractDataAsync(apiUrl, loginUrl);

            // Transform the data before loading it into the database
            var transformedData = DeviseTransform.TransformData(extractedData);

            // Load the data into the database
            await DeviseLoad.LoadDataAsync(transformedData, connectionString);

            // Log the process completion message for the Devise ETL process
            Console.WriteLine("Devise ETL process completed successfully.");
        }
    }
}
