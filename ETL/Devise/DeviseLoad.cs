using System.Data.SqlClient;
using TSI_ERP_ETL.Models;

namespace TSI_ERP_ETL.ETL.Devise
{
    public class DeviseLoad
    {
        public static async Task LoadDataAsync(IEnumerable<DeviseModel> data, string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                foreach (var item in data)
                {
                    var command = new SqlCommand("INSERT INTO Devise (Column1, Column2) VALUES (@Value1, @Value2)", connection);
                    command.Parameters.AddWithValue("@Value1", item.NumeroDevise);
                    command.Parameters.AddWithValue("@Value2", item.LibelleDevise ?? string.Empty);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
