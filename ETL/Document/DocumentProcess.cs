using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.ETL.Tier.Fournisseur;
using TSI_ERP_ETL.ETL.VdocumentDetail;
using TSI_ERP_ETL.TableUtilities;
using TSI_ERP_ETL.Erp_ApiEndpoints;

namespace TSI_ERP_ETL.ETL.Document
{
    public class DocumentProcess
    {
        public static async Task ProcessDocumentAsync(string token, ErpApiClient erpApiClient)
        {
            if (token is null)
            {

                throw new ArgumentNullException(nameof(token));
            }

            {
                // Construire la configuration à partir du fichier appsettings.json
                var optionsBuilder = new DbContextOptionsBuilder<ETLDbContext>();
                optionsBuilder.UseSqlServer(erpApiClient.DbConnection!);
                var context = new ETLDbContext(optionsBuilder.Options);
               
                // Instancier DocumentLoad avec DbContext
                var documentLoad = new DocumentLoad(context);

                // Utiliser BaseUrl de l'instance erpApiClient
                string apiUrl = erpApiClient.BaseUrl!;

                // Tronquer la table avant de charger de nouvelles données
                // Vérifier si la table "Document" existe

                bool tableExists = await DatabaseHelper.TableExistsAsync(erpApiClient.DbConnection!, "Document");
                if (!tableExists)
                {
                    Console.WriteLine("La table n'existe pas. Procéder à l'initialisation.");
                    await TableCreate.CreateTable(erpApiClient.DbConnection!, "Document", "Devise uniqueidentifier PRIMARY KEY, MontantTtc decimal null ");
                }
                else
                {
                    Console.WriteLine("La table existe déjà. Ignorer l'initialisation.");
                    // Tronquer la table avant de charger de nouvelles données
                    await TableTruncate.TruncateTable(erpApiClient.DbConnection!, "document");
                }
                // Extraire les données à partir du point d'API
                var extractedData = await DocumentExtract.ExtractDocumentAsync(apiUrl, token);
                //var sss = await DocumentExtract.ExtractDocumentAsync(apiUrl, loginUrl);

                // Transformer les données avant de les charger dans la base de données

                var transformedData = DocumentTransform.TransformDocument(extractedData);
               // var transformedDataqqq = DocumentTransform.TransformDocument(extractedData);

                // Charger les données dans la base de données
                await documentLoad.LoadDocumentAsync(transformedData);
              //  await documentLoad.LoadDocumentAsync(transformedDataqqq);

                // Enregistrer le message de fin du processus ETL Document
                Console.WriteLine("Le processus ETL Document s'est terminé avec succès.");
            }
        }
    }
}
