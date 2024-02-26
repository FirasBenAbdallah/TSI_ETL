using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TSI_ERP_ETL.Models;
using TSI_ERP_ETL.Models.GetAllPaged;

namespace TSI_ERP_ETL.ETL.Tier
{
    public class TierExtract
    {
        public static async Task<List<TierModel>> ExtractTierAsync(string apiUrl, string loginUrl)
        {
            using var httpClient = new HttpClient();
            var loginData = new LoginRequestModel("Administrateur", "");

            var loginContent = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");
            var loginResponse = await httpClient.PostAsync(loginUrl, loginContent);

            if (loginResponse.IsSuccessStatusCode)
            {
                var loginResponseContent = await loginResponse.Content.ReadAsStringAsync();
                var tokenResponse = JsonConvert.DeserializeObject<LoginResponse>(loginResponseContent);

                if (tokenResponse != null && tokenResponse.Token != null)
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.Token);

                    var getAllPagedRequest = new GetAllPagedRequest
                    {
                        MaxResultCount = 1,
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

            throw new Exception($"Login Error : {loginResponse.StatusCode} AT {loginResponse.Headers.Date}");
        }

    }
}



/*using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TSI_ERP_ETL.Models;

namespace TSI_ERP_ETL.ETL.Tier
{
    public class TierExtract
    {
        public static async Task<List<TierModel>> ExtractTierAsync(string apiUrl, string loginUrl)
        {
            using var httpClient = new HttpClient();
            var loginData = new LoginRequestModel("Administrateur", "");

            var loginContent = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");
            var loginResponse = await httpClient.PostAsync(loginUrl, loginContent);

            // If the login response is successful, extract the data
            if (loginResponse.IsSuccessStatusCode)
            {
                var loginResponseContent = await loginResponse.Content.ReadAsStringAsync();
                var tokenResponse = JsonConvert.DeserializeObject<LoginResponse>(loginResponseContent);

                // If the token is provided, extract the data
                if (tokenResponse != null && tokenResponse.Token != null)
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.Token);

                    var response = await httpClient.PostAsJsonAsync();
                    var data = JsonConvert.DeserializeObject<List<DeviseModel>>(response);
                    return data!;
                }
            }

            // If the login response is not successful, throw an exception
            throw new Exception($"Login Error : {loginResponse.StatusCode} AT {loginResponse.Headers.Date}");
        }
    }
}
*/