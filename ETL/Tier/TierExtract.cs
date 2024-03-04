using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TSI_ERP_ETL.Models;
using TSI_ERP_ETL.Models.GetAllPaged;

namespace TSI_ERP_ETL.ETL.Tier
{
    public class TierExtract
    {
        public static async Task<List<TierModel>> ExtractTierAsync(string apiUrl, string token)
        {
            using var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var getAllPagedRequest = new GetAllPagedRequest
            {
                MaxResultCount = 1000,
                SkipCount = 0,
                Sorting = new List<SortingByProperty>(),
                Filters = new List<FilterByProprety>(), // { new("nom", "M", OperatorType.CONTAINS) },
                GetAllData = false,
                Summaries = new List<string>(),
                TypeTier = "F",
            };

            var requestContent = new StringContent(JsonConvert.SerializeObject(getAllPagedRequest), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiUrl + "/Tier/getallpaged", requestContent);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<TierModel>>(responseContent);
                string newJson = JsonConvert.SerializeObject(apiResponse, Formatting.Indented);
                //Console.WriteLine(newJson);
                return apiResponse!.Items!;
            }
            else
            {
                throw new Exception($"API Error : {response.StatusCode} AT {response.Headers.Date}");
            }
        }

    }
}