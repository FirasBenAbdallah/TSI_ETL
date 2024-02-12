using Microsoft.Extensions.Configuration;
using TSI_ERP_ETL.Devise;
using TSI_ERP_ETL.TableUtilities;

namespace TSI_ERP_ETL
{
    class Program
    {

        public static async Task Main(string[] args)
        {
            // Build configuration
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ApiEndpoints/appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Create an instance of ErpApiClient
            var erpApiClient = new ErpApiClient(configuration);

            string connectionString = "Data Source=FIRASBA;Initial Catalog=ETL;Integrated Security=True;";

            // Use the BaseUrl from erpApiClient instance
            string apiUrl = erpApiClient.BaseUrl;

            // Truncate the table before loading new data
            await TableTruncate.TruncateTable(connectionString);

            var extractedData = await DeviseExtract.ExtractDataAsync(apiUrl);

            var transformedData = DeviseTransform.TransformData(extractedData);

            await DeviseLoad.LoadDataAsync(transformedData, connectionString);

            Console.WriteLine("ETL process completed successfully.");
        }
    }
}





















/*using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Net.Http.Headers;

namespace ETL
{
    public class DeviseData
    {
        // Define properties based on the JSON structure returned by your API
        public int nombreDecimales { get; set; }
        public string? uid { get; set; }
        public string? codeDevise { get; set; }
        public int numeroDevise { get; set; }
        public string? libelleDevise { get; set; }
        public int? nombreDevises { get; set; }
        public string? compteBancaireDefaut { get; set; }
    }

    class Program
    {
        public static async Task Main(string[] args)
        {
            string apiUrl = "https://localhost:44380/api/Devise/";
            string connectionString = "Data Source=FIRASBA;Initial Catalog=ETL;Integrated Security=True;";

            // Extract
            var extractedData = await ExtractDataAsync(apiUrl);

            // Transform
            var transformedData = TransformData(extractedData);

            // Load
            await LoadDataAsync(transformedData, connectionString);

            Console.WriteLine("ETL process completed successfully.");
        }

        public static async Task<List<DeviseData>> ExtractDataAsync(string apiUrl)
        {
            using (var httpClient = new HttpClient())
            {

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJUZW5hbnRJZCI6IlNpbmdsZSB0ZW5hbnQgbW9kZSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiQWRtaW5pc3RyYXRldXIiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJObyBFbWFpbCIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcHJpbWFyeXNpZCI6IjVkNjhjMDJkLTRmY2ItNGFmNi04NjY0LTM1ZmU5MGQ5ODlmNCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3N1cm5hbWUiOiIiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiQWRtaW5pc3RyYXRldXIiLCJleHAiOjE3MDgxMzAwNDksImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzgwLyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzgwLyJ9.Oe6MInGtkbg-dyJeaZ6FpMHkt6cmb2jCakoKaspofc8");

                var response = await httpClient.GetStringAsync(apiUrl);
                var data = JsonConvert.DeserializeObject<List<DeviseData>>(response);
                return data!;
            }
        }

        public static IEnumerable<DeviseData> TransformData(IEnumerable<DeviseData> data)
        {
            // Example transformation: Filter based on a condition and modify the data
            foreach (var item in data)
            {
                // Apply transformation logic here
                // For example, converting currency values, filtering out certain records, etc.

                // Example transformation: Convert currency values to USD
                item.numeroDevise = item.numeroDevise * 2;

            }

            return data; // Return the transformed data
        }

        public static async Task LoadDataAsync(IEnumerable<DeviseData> data, string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                foreach (var item in data)
                {
                    var command = new SqlCommand("INSERT INTO Fba (Column1, Column2) VALUES (numeroDevise, codeDevise)", connection);
                    // Set command parameters based on your data structure
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
*/