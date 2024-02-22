using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSI_ERP_ETL.Models;

namespace TSI_ERP_ETL.ETL.Tier.Fournisseur
{
    public class FournisseurLoad
    {
        public static async Task LoadDataAsync(IEnumerable<TierModel> data, string connectionString)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();
            foreach (var item in data)
            {
                var command = new SqlCommand("INSERT INTO Fournisseur (RaisonSociale) VALUES (@Value1)", connection);
                command.Parameters.AddWithValue("@Value1", item.RaisonSociale);
                //command.Parameters.AddWithValue("@Value2", item.LibelleDevise ?? string.Empty);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
