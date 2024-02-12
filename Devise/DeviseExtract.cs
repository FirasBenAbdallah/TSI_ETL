using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TSI_ERP_ETL.Models;

namespace TSI_ERP_ETL.Devise
{
    public class DeviseExtract
    {
        public static async Task<List<DeviseModel>> ExtractDataAsync(string apiUrl)
        {
            //string loginUrl = "https://erp.back.tsi.com.tn:5555/api/Authentication/Login";
            var loginUrl = apiUrl + "/Authentication/Login";

            using (var httpClient = new HttpClient())
            {
                var loginData = new
                {
                    userName = "Administrateur",
                    password = ""
                };
                var loginContent = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");

                var loginResponse = await httpClient.PostAsync(loginUrl, loginContent);
                if (loginResponse.IsSuccessStatusCode)
                {
                    var loginResponseContent = await loginResponse.Content.ReadAsStringAsync();
                    var tokenResponse = JsonConvert.DeserializeObject<LoginResponse>(loginResponseContent);

                    if (tokenResponse != null && tokenResponse.Token != null)
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.Token);

                        var response = await httpClient.GetStringAsync(apiUrl + "/Devise");
                        var data = JsonConvert.DeserializeObject<List<DeviseModel>>(response);
                        return data!;
                    }
                }

                throw new Exception("Authentication failed or token was not provided.");
            }
        }
    }
}
