using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TSI_ERP_ETL.Models.Document;
using TSI_ERP_ETL.Models;
using TSI_ERP_ETL.Models.GetAllPaged;
using Azure.Core;

namespace TSI_ERP_ETL.ETL.Document
{
    public class DocumentExtract
    {
        public static async Task<List<DocumentModel>> ExtractDocumentAsync(string apiUrl, string token)
        {
            {
                using var httpClient = new HttpClient();

                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        var getAllPagedRequest = new GetAllPagedRequest
                        {
                            MaxResultCount = 10,
                            SkipCount = 0,
                            Sorting = new List<SortingByProperty>(),
                            Filters = new List<FilterByProprety>(), // { new("nom", "M", OperatorType.CONTAINS) },
                            GetAllData = true,
                            Summaries = new List<string>(),
                            // TypeTier = "F",
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

            }

        }
