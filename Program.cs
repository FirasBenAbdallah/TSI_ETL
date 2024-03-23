using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TSI_ERP_ETL.Erp_ApiEndpoints;

namespace TSI_ERP_ETL
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Get logger from DI
            ServiceProvider serviceProvider = Logger.Log();
            var logger = serviceProvider.GetService<ILogger<Program>>();
            //var fournisseurLogger = serviceProvider.GetService<ILogger<FournisseurProcess>>();

            try
            {
                if (args is null)
                {
                    logger!.LogError("Arguments are null.");
                    throw new ArgumentNullException(nameof(args));
                }
                CreateHostBuilder(args).Build().Run();
                var erpApiClient = ConfigurationBuild.InitializeErpApiClient();

                // Login URL from erpApiClient instance
                //string loginUrl = erpApiClient.LoginUrl!;

                // Call login method
                //string Token = await Login.GetTokenAsync(loginUrl);

                logger!.LogInformation("Starting ETL procedures.");

                //! Initiate the ETL procedures
                //---------------------------------------------------------------------------//
                // Call the DeviseProcess.ProcessDeviseAsync method

                //  await DeviseProcess.ProcessDeviseAsync(Token, erpApiClient);

                // Call the FournisseurProcess.ProcessFpurnisseurAsync method
                //await FournisseurProcess.ProcessFournisseurAsync(Token, erpApiClient, fournisseurLogger);

                //await FournisseurProcess.ProcessFournisseurAsync();
                //await DocumentProcess.ProcessDocumentAsync(Token, erpApiClient);

                // Call the VdocumentDetailProcess.ProcessVdocumentDetailAsync method
                //await VdocumentDetailProcess.ProcessVdocumentDetailAsync(Token, erpApiClient);

                // Log the process completion message for the ETL process
                //Console.WriteLine("ETL process completed successfully.\n");
                logger!.LogInformation("ETL process completed successfully.");
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"\nAn error occurred: \n{ex.Message}");
                logger!.LogError("An error occurred: {ErrorMessage}", ex.Message);
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>()
                .UseUrls("http://*:7001");
            });
    }
}