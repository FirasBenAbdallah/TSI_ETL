using Microsoft.Data.SqlClient;
using System.Data.Common;

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
        public static async Task<bool> ColumnExistsAsync(DbConnection connection, string tableName, string columnName)
        {
            var query = @"
                SELECT 
                    CASE WHEN EXISTS (
                        SELECT * 
                        FROM INFORMATION_SCHEMA.COLUMNS 
                        WHERE TABLE_NAME = @TableName AND COLUMN_NAME = @ColumnName
                    ) 
                    THEN 1 
                    ELSE 0 
                    END";

            using var command = connection.CreateCommand();
            connection.Open();
            command.CommandText = query;
            command.Parameters.Add(new SqlParameter("@TableName", tableName));
            command.Parameters.Add(new SqlParameter("@ColumnName", columnName));
            bool exists = (await command.ExecuteScalarAsync())!.ToString() == "1";
            connection.Close();
            return exists;
        }
    }
}