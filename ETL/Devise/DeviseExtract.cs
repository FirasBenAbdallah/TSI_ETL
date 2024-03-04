using Newtonsoft.Json;
using System.Net.Http.Headers;
using TSI_ERP_ETL.Models;

namespace TSI_ERP_ETL.ETL.Devise
{
    public class DeviseExtract
    {
        public static async Task<List<DeviseModel>> ExtractDeviseAsync(string apiUrl, string token)//string loginUrl
        {
            using var httpClient = new HttpClient();

            // Set the Authorization header with the token
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await httpClient.GetStringAsync(apiUrl + "/Devise");
            var data = JsonConvert.DeserializeObject<List<DeviseModel>>(response);
            return data!;
        }
    }
}
