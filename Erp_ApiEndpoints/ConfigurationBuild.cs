using Microsoft.Extensions.Configuration;

namespace TSI_ERP_ETL.Erp_ApiEndpoints
{
    public class ConfigurationBuild
    {
        public static ErpApiClient InitializeErpApiClient()
        {
            // Build configuration from appsettings.json
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Erp_ApiEndpoints/appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            return new ErpApiClient(configuration);
        }
    }
}
