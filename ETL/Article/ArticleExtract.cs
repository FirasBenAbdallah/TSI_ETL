using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TSI_ERP_ETL.Models.GetAllPaged;
using TSI_ERP_ETL.Models;

namespace TSI_ERP_ETL.ETL.Article
{
    public class ArticleExtract
    {
        public static async Task<List<ArticleModel>> ExtractArticleAsync(string apiUrl, string token)
        {

            using var httpClient = new HttpClient();

            // Set the Authorization header with the token
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var getAllPagedRequest = new GetAllPagedRequest
            {
                MaxResultCount = 10,
                SkipCount = 0,
                Sorting = new List<SortingByProperty>(),
                Filters = new List<FilterByProprety>(), // { new("nom", "M", OperatorType.CONTAINS) },
                GetAllData = true,
                Summaries = new List<string>(),
            };

            var requestContent = new StringContent(JsonConvert.SerializeObject(getAllPagedRequest), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiUrl + "/Article/getallpaged", requestContent);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<ArticleModel>>(responseContent);
                string newJson = JsonConvert.SerializeObject(apiResponse, Formatting.Indented);
                return apiResponse!.Items!;
            }
            else
            {
                throw new Exception($"API Error : {response.StatusCode} AT {response.Headers.Date}");
            }
        }
    }
}
