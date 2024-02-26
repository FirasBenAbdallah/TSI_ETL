using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TSI_ERP_ETL.Models.Document;
using TSI_ERP_ETL.Models;
using Azure.Core;
using TSI_ERP_ETL.Models.GetAllPaged;

namespace TSI_ERP_ETL.ETL.Document
{
    public class DocumentExtract
    {
        public static async Task<List<DocumentModel>> ExtractDocumentAsync(string apiUrl, string loginUrl)
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

                    var getAllPagedRequest = new GetAllPagedRequest
                    {
                        MaxResultCount = 1,
                        SkipCount = 0,
                        Sorting = new List<SortingByProperty>(),
                        Filters = new List<FilterByProprety>(), // { new("nom", "M", OperatorType.CONTAINS) },
                        GetAllData = false,
                        Summaries = new List<string>(),
                    };
                    var requestContent = new StringContent(JsonConvert.SerializeObject(getAllPagedRequest), Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(apiUrl + "/Document/getallpaged", requestContent);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var apiResponse = JsonConvert.DeserializeObject<ApiResponse<DocumentModel>>(responseContent);
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
            // If the login response is not successful, throw an exception
            throw new Exception("Authentication failed or token was not provided.");
        }
    }
}

