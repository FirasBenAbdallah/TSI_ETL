using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TSI_ERP_ETL.Models;
using TSI_ERP_ETL.Models.GetAllPaged;
using TSI_ERP_ETL.Resource;

namespace TSI_ERP_ETL.ETL.FicheFournisseur
{
    public class FicheFournisseurExtract
    {
        public static async Task<List<FicheFournisseurModel>> ExtractFicheFournisseurExtractAsync(string olmiConnectionString)
        {
            List<FicheFournisseurModel> FicheFournisseurs = new();

            using (SqlConnection connection = new(olmiConnectionString))
            {
                // Open the connection
                await connection.OpenAsync();
                // Define your SQL command
                using SqlCommand command = new("SELECT Code,Nom,Debit,Credit FROM VFicheFournisseurFinal", connection);
                using SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    string code = reader.IsDBNull(reader.GetOrdinal("Code")) ? "" : reader.GetString(reader.GetOrdinal("Code"));
                    string nom = reader.IsDBNull(reader.GetOrdinal("Nom")) ? "" : reader.GetString(reader.GetOrdinal("Nom"));
                    decimal debit = reader.IsDBNull(reader.GetOrdinal("Debit")) ? 0 : reader.GetFieldValue<decimal>(reader.GetOrdinal("Debit"));
                    decimal credit = reader.IsDBNull(reader.GetOrdinal("Credit")) ? 0 : reader.GetFieldValue<decimal>(reader.GetOrdinal("Credit"));
                    //decimal solde = reader.IsDBNull(reader.GetOrdinal("Solde")) ? 0 : reader.GetFieldValue<decimal>(reader.GetOrdinal("Solde"));

                    FicheFournisseurModel ficheFournisseur = new(code, nom, debit, credit);

                    //SharedResource.CodeClientList.Add(code);
                    //SharedResource.NomClientList.Add(nom);
                    //SharedResource.debitFicheFournisseur.Add(debit);
                    //SharedResource.creditFicheFournisseur.Add(credit);
                    //SharedResource.SoldeFicheFournisseur.Add(solde);
                    FicheFournisseurs.Add(ficheFournisseur);
                }
                await reader.CloseAsync();
                await connection.CloseAsync();
            }
            return FicheFournisseurs;
        }
    }
}
