using TSI_ERP_ETL.ETL.Devise;

namespace TSI_ERP_ETL
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            // Call the DeviseProcess.ProcessDataAsync method
            await DeviseProcess.ProcessDataAsync();

            // Log the process completion message for the ETL process
            Console.WriteLine("\nETL process completed successfully.");
        }
    }
}