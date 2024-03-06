using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Console;
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
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder =>
                {
                    builder.AddConsole(options =>
                    {
                        options.FormatterName = nameof(CustomConsoleFormatter);
                    })
                    .AddConsoleFormatter<CustomConsoleFormatter, ConsoleFormatterOptions>();
                })
                .BuildServiceProvider();
            // Set up Dependency Injection
            /*var serviceProvider = new ServiceCollection()
                                .AddLogging(builder => builder
                                    .AddConsole()
                                    .AddFilter(level => level >= LogLevel.Information) // Customize log level as needed
                                )
                                .BuildServiceProvider();*/

            // Get logger from DI
            var logger = serviceProvider.GetService<ILogger<Program>>();


            try
            {
                if (args is null)
                {
                    logger!.LogError("Arguments are null.");
                    throw new ArgumentNullException(nameof(args));
                }
                var erpApiClient = ConfigurationBuild.InitializeErpApiClient();

                // Login URL from erpApiClient instance
                string loginUrl = erpApiClient.LoginUrl!;

                // Call login method
                string Token = await Login.GetTokenAsync(loginUrl);

                logger!.LogInformation("Starting ETL procedures.");

                //! Initiate the ETL procedures
                //---------------------------------------------------------------------------//
                // Call the DeviseProcess.ProcessDeviseAsync method
              
                //  await DeviseProcess.ProcessDeviseAsync(Token, erpApiClient);

                // Call the FournisseurProcess.ProcessFpurnisseurAsync method
                await FournisseurProcess.ProcessFournisseurAsync(Token, erpApiClient);

                //await FournisseurProcess.ProcessFournisseurAsync();
                await DocumentProcess.ProcessDocumentAsync(Token, erpApiClient);

                // Call the VdocumentDetailProcess.ProcessVdocumentDetailAsync method
                await VdocumentDetailProcess.ProcessVdocumentDetailAsync(Token, erpApiClient);

                // Log the process completion message for the ETL process
                //Console.WriteLine("ETL process completed successfully.\n");
                logger!.LogInformation("ETL process completed successfully.");
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"\nAn error occurred: \n{ex.Message}");
                logger!.LogError($"An error occurred: {ex.Message}");
            }
        }
    }


    public class CustomConsoleFormatter : ConsoleFormatter
    {
        public CustomConsoleFormatter() : base(nameof(CustomConsoleFormatter))
        {
        }

        public override void Write<TState>(in LogEntry<TState> entry, IExternalScopeProvider? scopeProvider, TextWriter writer)
        {
            // Extract the default console color only once at the beginning of the Write method
            var defaultColor = Console.ForegroundColor;

            var logLevel = entry.LogLevel;
            var message = entry.Formatter(entry.State, entry.Exception);

            // Set the color for the log level
            //var logLevelColor = GetLogLevelColor(logLevel);
            //Console.ForegroundColor = logLevelColor;
            writer.Write($"[{DateTime.Now:dd-MMM-yyyy HH:mm:ss} ");
            writer.Write($"{logLevel.ToString()[..3].ToUpperInvariant()}] ");

            // Reset the color to the default before writing the message
            Console.ForegroundColor = defaultColor;
            writer.WriteLine($" {message}");
        }


        /*private static ConsoleColor GetLogLevelColor(LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.Error => ConsoleColor.Red,
                LogLevel.Warning => ConsoleColor.Yellow,
                LogLevel.Information => ConsoleColor.Green,
                LogLevel.Debug => ConsoleColor.Gray,
                LogLevel.Trace => ConsoleColor.DarkGray,
                LogLevel.Critical => ConsoleColor.DarkRed,
                _ => Console.ForegroundColor, // This should be the default color, not a specific color.
            };
        }*/
    }


    /*public class CustomConsoleFormatter : ConsoleFormatter
    {
        public CustomConsoleFormatter() : base(nameof(CustomConsoleFormatter))
        {
        }

        public override void Write<TState>(in LogEntry<TState> entry, IExternalScopeProvider scopeProvider, TextWriter writer)
        {
            var originalColor = Console.ForegroundColor;
            try
            {
                var logLevel = entry.LogLevel;
                var message = entry.Formatter(entry.State, entry.Exception);

                // Write the date and time
                writer.Write($"[{DateTime.Now:dd-MMM-yyyy HH:mm:ss}] ");

                // Change color for log level
                Console.ForegroundColor = GetLogLevelColor(logLevel);
                writer.Write($"{logLevel.ToString()[..3].ToUpperInvariant()}: \n");

                //logLevel = LogLevel.Debug;
                Console.ForegroundColor = originalColor;
                writer.WriteLine(message);
            }
            finally
            {
                // Ensure the original console color is set back
                Console.ForegroundColor = originalColor;
            }
        }

        private static ConsoleColor GetLogLevelColor(LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.Error => ConsoleColor.Red,
                LogLevel.Warning => ConsoleColor.Yellow,
                LogLevel.Information => ConsoleColor.Green,
                LogLevel.Debug => ConsoleColor.Gray,
                LogLevel.Trace => ConsoleColor.DarkGray,
                LogLevel.Critical => ConsoleColor.DarkRed,
                _ => ConsoleColor.Blue,
            };
        }
    }*/
}


