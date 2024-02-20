using System.Data.SqlClient;
using TSI_ERP_ETL.Models;

namespace TSI_ERP_ETL.ETL.VdocumentDetail
{
    public class VdocumentDetailLoad
    {
        public static async Task LoadVdocumentDetailAsync(IEnumerable<VdocumentDetailModel> data, string connectionString)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();
            foreach (var item in data)
            {
                var command = new SqlCommand("INSERT INTO documentDetail (PrixUnitaire) VALUES (@Value1)", connection);
                command.Parameters.AddWithValue("@Value1", item.PrixUnitaire);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
