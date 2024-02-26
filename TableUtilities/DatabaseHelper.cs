using System.Data.SqlClient;

namespace TSI_ERP_ETL.TableUtilities
{
    public class DatabaseHelper
    {
        public static async Task<bool> TableExistsAsync(string connectionString, string tableName)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                await connection.OpenAsync();
                var command = new SqlCommand(
                    "SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME = @TableName",
                    connection);
                command.Parameters.AddWithValue("@TableName", tableName);

                var result = await command.ExecuteScalarAsync();
                return result != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
    }
}