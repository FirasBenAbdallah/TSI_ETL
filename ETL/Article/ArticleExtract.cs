using TSI_ERP_ETL.Models;
using System.Data.SqlClient;

namespace TSI_ERP_ETL.ETL.Article
{
    public class ArticleExtract
    {
        public static async Task<List<ArticleModel>> ExtractArticleAsync(string olmiConnectionString)
        {
            // Your SQL query.
            string query = @"
                            SELECT 
                                A.[FamilleArticle],
                                A.[Libelle],
                                A.[UID],
                                DD.[Article],
                                DD.[Quantite],
                                DD.[MontantTTC],
                                DD.[Document],
                                D.[UID],
                                D.[DateDocument]
                            FROM 
                                [Article] AS A
                            INNER JOIN 
                                [DocumentDetail] AS DD
                            ON 
                                A.[UID] = DD.[Article]
                            INNER JOIN
                                [Document] AS D
                            ON
                                DD.[Document] = D.[UID]";

            List<ArticleModel> articles = new();
            int id = 0;

            using (SqlConnection connection = new(olmiConnectionString))
            {
                // Open the connection
                await connection.OpenAsync();

                // Define your SQL command
                using SqlCommand command = new(query, connection);
                using SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    string? familleArticle = reader.IsDBNull(reader.GetOrdinal("FamilleArticle")) ? null : reader.GetString(reader.GetOrdinal("FamilleArticle"));
                    string libelle = reader.IsDBNull(reader.GetOrdinal("Libelle")) ? "" : reader.GetString(reader.GetOrdinal("Libelle"));
                    string uid = reader.IsDBNull(reader.GetOrdinal("UID")) ? "" : reader.GetGuid(reader.GetOrdinal("UID")).ToString();
                    Guid article = reader.IsDBNull(reader.GetOrdinal("Article")) ? Guid.Empty : reader.GetGuid(reader.GetOrdinal("Article"));
                    DateTime dateDocument = reader.IsDBNull(reader.GetOrdinal("DateDocument")) ? DateTime.Now : reader.GetDateTime(reader.GetOrdinal("DateDocument"));
                    double quantite = reader.IsDBNull(reader.GetOrdinal("Quantite")) ? 0 : reader.GetDouble(reader.GetOrdinal("Quantite"));
                    decimal montantTTC = reader.IsDBNull(reader.GetOrdinal("MontantTTC")) ? 0 : reader.GetDecimal(reader.GetOrdinal("MontantTTC"));
                    id++;

                    ArticleModel factureClient = new(id, familleArticle, libelle, uid, article, dateDocument, quantite, montantTTC);

                    articles.Add(factureClient);
                }
                await reader.CloseAsync();
                await connection.CloseAsync();
            }
            return articles;

            /*            using var httpClient = new HttpClient();

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
                        }*/
        }
    }
}
