using TSI_ERP_ETL.ETL.Tier.Fournisseur;

namespace TSI_ERP_ETL
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
<<<<<<< HEAD
                // Call the FournisseurProcess.ProcessFpurnisseurAsync method
                 await FournisseurProcess.ProcessFournisseurAsync();
                //  await DocumentProcess.ProcessDocumentAsync();
=======
                await FournisseurProcess.ProcessFournisseurAsync();

                // Call the FournisseurProcess.ProcessFpurnisseurAsync method
                //await FournisseurProcess.ProcessFournisseurAsync();
                //await DocumentProcess.ProcessDocumentAsync();
>>>>>>> 2b789c2a618334bac90f003bc968c6b26ff8c0ad

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


