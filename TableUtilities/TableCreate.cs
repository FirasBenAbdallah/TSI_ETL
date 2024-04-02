using Microsoft.Data.SqlClient;

namespace TSI_ERP_ETL.TableUtilities
{
    public class TableCreate
    {
        public static async Task CreateTable(string connectionString, string table, string columns)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();
            var createCommand = new SqlCommand($"CREATE TABLE {table} ({columns})", connection);
            await createCommand.ExecuteNonQueryAsync();
        }
    }
}
