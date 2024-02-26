using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
