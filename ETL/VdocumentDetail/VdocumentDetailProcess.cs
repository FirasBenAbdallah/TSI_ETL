using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.ETL.Document;
using TSI_ERP_ETL.ETL.Tier.Fournisseur;
using TSI_ERP_ETL.TableUtilities;

namespace TSI_ERP_ETL.ETL.VdocumentDetail
{
    public class VdocumentDetailProcess
    {
        // Configure DbContext
        public static async Task ProcessVdocumentDetailAsync(string token, ErpApiClient erpApiClient)
        {
            {
                // Configure DbContext
                var optionsBuilder = new DbContextOptionsBuilder<ETLDbContext>();
                optionsBuilder.UseSqlServer(erpApiClient.DbConnection!);
                var context = new ETLDbContext(optionsBuilder.Options);

                // Instantiate FournisseurLoad with DbContext
                var documentDetailLoad = new VdocumentDetailLoad(context);

                // Utiliser BaseUrl de l'instance erpApiClient
                string apiUrl = erpApiClient.BaseUrl!;

                // Tronquer la table avant de charger de nouvelles données
                // Vérifier si la table "Document" existe

                bool tableExists = await DatabaseHelper.TableExistsAsync(erpApiClient.DbConnection!, "DocumentDetail");
                if (!tableExists)
                {
                    Console.WriteLine("La table n'existe pas. Procéder à l'initialisation.");

                    await TableCreate.CreateTable(erpApiClient.DbConnection!, "DocumentDetail", "Devise uniqueidentifier PRIMARY KEY, Quantite float null, MontantTtc decimal null, RowIndex int");
                }
                else
                {
                    Console.WriteLine("La table existe déjà. Ignorer l'initialisation.");
                    // Tronquer la table avant de charger de nouvelles données
                    await TableTruncate.TruncateTable(erpApiClient.DbConnection!, "DocumentDetail");
                }
                // Extraire les données à partir du point d'API
                var extractedData = await VdocumentDetailExtract.ExtractVdocumentDetailAsync(apiUrl, token);
                //var sss = await DocumentExtract.ExtractDocumentAsync(apiUrl, loginUrl);

                // Transformer les données avant de les charger dans la base de données
                var transformedData = VdocumentDetailTransform.documentDetailTransform(extractedData);

                await documentDetailLoad.LoadVdocumentDetailAsync(transformedData);

                //  await documentLoad.LoadDocumentAsync(transformedDataqqq);

                // Enregistrer le message de fin du processus ETL Document
                Console.WriteLine("Le processus ETL Document s'est terminé avec succès.");
            }
        }
    }
}
