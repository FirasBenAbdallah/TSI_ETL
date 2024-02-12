using System.Data.SqlClient;

namespace TSI_ERP_ETL.TableUtilities
{
    public class TableTruncate
    {
        public static async Task TruncateTable(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var truncateCommand = new SqlCommand("TRUNCATE TABLE devise", connection);
                await truncateCommand.ExecuteNonQueryAsync();
            }
        }
    }
}
