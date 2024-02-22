using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSI_ERP_ETL.Models.Document;

namespace TSI_ERP_ETL.ETL.Document
{
    public class DocumentLoad
    {
        public static async Task LoadDocumentAsync(IEnumerable<DocumentModel> data, string connectionString)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();
            foreach (var item in data)
            {
                var command = new SqlCommand("INSERT INTO Document (MontantTimbre) VALUES (@Value1)", connection);
                command.Parameters.AddWithValue("@Value1", item.MontantTimbre);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
