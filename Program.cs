using TSI_ERP_ETL.Erp_ApiEndpoints;
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
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            try
            {
                var erpApiClient = ConfigurationBuild.InitializeErpApiClient();

                // Login URL from erpApiClient instance
                string loginUrl = erpApiClient.LoginUrl!;

                // Call login method
                string Token = await Login.GetTokenAsync(loginUrl);

                //! Call the ETL process 
                //?---------------------------------------------------------------
                // Call the DeviseProcess.ProcessDeviseAsync method
              
                //  await DeviseProcess.ProcessDeviseAsync(Token, erpApiClient);

               await VdocumentDetailProcess.ProcessVdocumentDetailAsync(Token, erpApiClient);

                // Call the FournisseurProcess.ProcessFpurnisseurAsync method
              
                // await FournisseurProcess.ProcessFournisseurAsync(Token, erpApiClient);
               await DocumentProcess.ProcessDocumentAsync(Token, erpApiClient);

                

                // Log the process completion message for the ETL process
                Console.WriteLine("ETL process completed successfully.\n");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nAn error occurred: \n{ex.Message}");
            }

        }
    }
}


