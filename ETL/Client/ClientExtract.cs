using Microsoft.Data.SqlClient;
using TSI_ERP_ETL.Models;
using TSI_ERP_ETL.Resource;

namespace TSI_ERP_ETL.ETL.Client
{
    public class ClientExtract
    {
        public static async Task<List<ClientModel>> ExtractClientAsync(string olmiConnectionString)
        {
            List<ClientModel> clients = new();

            using (SqlConnection connection = new(olmiConnectionString))
            {
                // Open the connection
                await connection.OpenAsync();

                // Define your SQL command
                using SqlCommand command = new("SELECT Code,Nom FROM VClient", connection);
                using SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    string code = reader.IsDBNull(reader.GetOrdinal("Code")) ? "" : reader.GetString(reader.GetOrdinal("Code"));
                    string nom = reader.IsDBNull(reader.GetOrdinal("Nom")) ? "" : reader.GetString(reader.GetOrdinal("Nom"));

                    ClientModel client = new(code, nom);

                    SharedResource.CodeClientList.Add(code);
                    SharedResource.NomClientList.Add(nom);

                    clients.Add(client);
                }
                await reader.CloseAsync();
                await connection.CloseAsync();
            }
            return clients;
        }
    }
}
