using TSI_ERP_ETL.ETL.Devise;
using TSI_ERP_ETL.ETL.Tier.Fournisseur;
using TSI_ERP_ETL.ETL.VdocumentDetail;

namespace TSI_ERP_ETL
{
    class Program
    {
        public static async Task Main()
        {
            try
            {
                // Call the FournisseurProcess.ProcessFpurnisseurAsync method
                await FournisseurProcess.ProcessFournisseurAsync();
                await DocumentProcess.ProcessDocumentAsync();
                
                // Call the DeviseProcess.ProcessDeviseAsync method
                //?await DeviseProcess.ProcessDeviseAsync();

                // Call the VdocumentDetailProcess.ProcessVdocumentDetailAsync method
                //?await VdocumentDetailProcess.ProcessVdocumentDetailAsync();

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


