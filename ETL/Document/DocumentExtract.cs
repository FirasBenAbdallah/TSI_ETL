﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TSI_ERP_ETL.Models.Document;
using TSI_ERP_ETL.Models;

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

                    var response = await httpClient.GetStringAsync(apiUrl + "/Document");
                    var data = JsonConvert.DeserializeObject<List<DocumentModel>>(response);
                    return data!;
                }
            }
            // If the login response is not successful, throw an exception
            throw new Exception("Authentication failed or token was not provided.");
        }
    }
}
