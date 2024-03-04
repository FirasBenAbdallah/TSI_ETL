using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TSI_ERP_ETL.Models;

namespace TSI_ERP_ETL.ETL.VdocumentDetail
{
    public class VdocumentDetailExtract
    {
        public static async Task<List<VdocumentDetailModel>> ExtractVdocumentDetailAsync(string apiUrl, string token)
        {
            using var httpClient = new HttpClient();

            // Set the Authorization header with the token
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await httpClient.GetStringAsync(apiUrl + "/VdocumentDetail");
            var data = JsonConvert.DeserializeObject<List<VdocumentDetailModel>>(response);
            return data!;
        }
    }
}
