using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TSI_ERP_ETL.Erp_ApiEndpoints;
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
                .AddJsonFile("Erp_ApiEndpoints/appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Create an instance of ErpApiClient
            var erpApiClient = new ErpApiClient(configuration);

            // Connection string to the database
            string connectionString = erpApiClient.DbConnection!;

            // Configure DbContext
            var optionsBuilder = new DbContextOptionsBuilder<ETLDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            var context = new ETLDbContext(optionsBuilder.Options);

            // Instantiate FournisseurLoad with DbContext
            var fournisseurLoad = new FournisseurLoad(context);

            // Use the BaseUrl from erpApiClient instance
            string apiUrl = erpApiClient.BaseUrl!;
            string loginUrl = erpApiClient.LoginUrl!;

            // Check if the "Fournisseur" table exists
            bool tableExists = await DatabaseHelper.TableExistsAsync(connectionString, "Fournisseur");
            if (!tableExists)
            {
                Console.WriteLine("Table does not exist. Proceed with initialization.");
                await TableCreate.CreateTable(connectionString, "Fournisseur", "FournisseurId uniqueidentifier PRIMARY KEY, RaisonSocial nvarchar(max) null");
            }
            else
            {
                Console.WriteLine("Table already exists. Skipping initialization.");
                // Truncate the table before loading new data
                await TableTruncate.TruncateTable(connectionString, "fournisseur");
            }

            // Extract data from the API endpoint
            var extractedData = await TierExtract.ExtractTierAsync(apiUrl, loginUrl);

            // Transform the data before loading it into the database
            var transformedData = FournisseurTransform.TransformFournisseurData(extractedData);

            // Load the data into the database
            await fournisseurLoad.LoadDataAsync(transformedData);

            // Log the process completion message for the Fournisseur ETL process
            Console.WriteLine("Fournisseur ETL process completed successfully.\n");
        }

    }
}
/*public static IServiceProvider ConfigureServices()
{
    var services = new ServiceCollection();

    // Build configuration
    IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("Erp_ApiEndpoints/appsettings.json", optional: false, reloadOnChange: true)
        .Build();

    // Add DbContext with SQL Server
    services.AddDbContext<ETLDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

    // Register other services
    services.AddTransient<FournisseurProcess>();

    return services.BuildServiceProvider();
}*/