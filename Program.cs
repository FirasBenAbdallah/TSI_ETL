using Microsoft.Extensions.Configuration;
using TSI_ERP_ETL.ETL;
using TSI_ERP_ETL.ETL.Devise;
using TSI_ERP_ETL.ETL.Document;
using TSI_ERP_ETL.ETL.Tier.Fournisseur;
using TSI_ERP_ETL.ETL.VdocumentDetail;

namespace TSI_ERP_ETL
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                // Build configuration from appsettings.json
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("Erp_ApiEndpoints/appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                // Create an instance of ErpApiClient
                var erpApiClient = new ErpApiClient(configuration);

                // Login URL from erpApiClient instance
                string loginUrl = erpApiClient.LoginUrl!;

                // Call login method
                string Token = await Login.GetTokenAsync(loginUrl);

                // Call the DeviseProcess.ProcessDeviseAsync method
                await DeviseProcess.ProcessDeviseAsync(Token, erpApiClient);

                // Call the FournisseurProcess.ProcessFpurnisseurAsync method
                await FournisseurProcess.ProcessFournisseurAsync();

                // await DocumentProcess.ProcessDocumentAsync();

                // Call the VdocumentDetailProcess.ProcessVdocumentDetailAsync method
                await VdocumentDetailProcess.ProcessVdocumentDetailAsync();

                // Log the process completion message for the ETL process
                Console.WriteLine("\nETL process completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nAn error occurred: \n{ex.Message}");
            }

        }
    }
}


