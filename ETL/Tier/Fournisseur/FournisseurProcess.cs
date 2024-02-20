using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSI_ERP_ETL.ETL.Devise;
using TSI_ERP_ETL.TableUtilities;

namespace TSI_ERP_ETL.ETL.Tier.Fournisseur
{
    public class FournisseurProcess
    {
        public static async Task ProcessFournisseurAsync()
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

            // Extracy data from the API endpoint
            var extractedData = await TierExtract.ExtractTierAsync(apiUrl, loginUrl);
        }
    }
}
