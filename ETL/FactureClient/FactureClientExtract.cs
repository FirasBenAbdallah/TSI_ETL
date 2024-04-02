using Microsoft.Data.SqlClient;
using TSI_ERP_ETL.Models;

namespace TSI_ERP_ETL.ETL.FactureClient
{
    public class FactureClientExtract
    {
        public static async Task<List<FactureClientModel>> ExtractFactureClientAsync(string olmiConnectionString)
        {
            // Your SQL query.
            string query = @"
                        SELECT 
                            D.[NumDocument],
                            D.[Realisation],
                            D.[MontantTTC],
                            F.[Code],
                            F.[Nom],
                            F.[Libelle]
                        FROM 
                            [Document] AS D
                        INNER JOIN 
                            [VFicheFournisseurFinal] AS F
                        ON 
                            D.[NumDocument] = SUBSTRING(F.[Libelle], CHARINDEX(':', F.[Libelle]) + 2, LEN(F.[Libelle]))";

            List<FactureClientModel> factureClients = new();
            int id = 0;

            using (SqlConnection connection = new(olmiConnectionString))
            {
                // Open the connection
                await connection.OpenAsync();

                // Define your SQL command
                using SqlCommand command = new(query, connection);
                using SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    string numDocument = reader.IsDBNull(reader.GetOrdinal("NumDocument")) ? "" : reader.GetString(reader.GetOrdinal("NumDocument"));
                    string realisation = reader.IsDBNull(reader.GetOrdinal("Realisation")) ? "" : reader.GetString(reader.GetOrdinal("Realisation"));
                    decimal montantTTC = reader.IsDBNull(reader.GetOrdinal("MontantTTC")) ? 0 : reader.GetDecimal(reader.GetOrdinal("MontantTTC"));
                    string code = reader.IsDBNull(reader.GetOrdinal("Code")) ? "" : reader.GetString(reader.GetOrdinal("Code"));
                    string nom = reader.IsDBNull(reader.GetOrdinal("Nom")) ? "" : reader.GetString(reader.GetOrdinal("Nom"));
                    string libelle = reader.IsDBNull(reader.GetOrdinal("Libelle")) ? "" : reader.GetString(reader.GetOrdinal("Libelle"));
                    id++;

                    FactureClientModel factureClient = new(id, numDocument, realisation, montantTTC, code, nom, libelle);

                    //SharedResource.CodeFactureClientList.Add(code);
                    //SharedResource.NomFactureClientList.Add(nom);

                    factureClients.Add(factureClient);
                }
                await reader.CloseAsync();
                await connection.CloseAsync();
            }
            return factureClients;
        }
    }
}
