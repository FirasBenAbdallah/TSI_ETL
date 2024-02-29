using Newtonsoft.Json;
using System.Text;
using TSI_ERP_ETL.Models;

namespace TSI_ERP_ETL.ETL
{
    public class Login
    {
        public static async Task<string> GetTokenAsync(string loginUrl)
        {
            using var httpClient = new HttpClient();
            var loginData = new LoginRequestModel("Administrateur", "");

            var loginContent = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");
            var loginResponse = await httpClient.PostAsync(loginUrl, loginContent);

            // If the login response is successful, extract the token
            if (loginResponse.IsSuccessStatusCode)
            {
                var loginResponseContent = await loginResponse.Content.ReadAsStringAsync();
                var tokenResponse = JsonConvert.DeserializeObject<LoginResponse>(loginResponseContent);

                // If the token is provided, return it
                if (tokenResponse != null && tokenResponse.Token != null)
                {
                    return tokenResponse.Token;
                }
            }

            // If the login response is not successful, throw an exception
            throw new Exception($"Login Error : {loginResponse.StatusCode} AT {loginResponse.Headers.Date}");
        }
    }
}
