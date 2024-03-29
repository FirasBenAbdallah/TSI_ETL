using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.ETL.Document;
using TSI_ERP_ETL.TableUtilities;

namespace TSI_ERP_ETL.ETL.ChiffreAffairesParClient
{
    public class ChiffreAffairesParClientProcess
    {



        public static async Task ProcessChiffreAffairesParClientAsync(string token, ErpApiClient erpApiClient)
        {
            if (token is null)
            {

                throw new ArgumentNullException(nameof(token));
            }

            {
                var optionsBuilder = new DbContextOptionsBuilder<ETLDbContext>();
                optionsBuilder.UseSqlServer(erpApiClient.DbConnection!);
                var context = new ETLDbContext(optionsBuilder.Options);
                var chiffreAffairesParClientLoad = new ChiffreAffairesParClientLoad(context);
                string apiUrl = erpApiClient.BaseUrl!;
                bool tableExists = await DatabaseHelper.TableExistsAsync(erpApiClient.DbConnection!, "ChiffreAffairesParClient");
                if (!tableExists)
                {
                    Console.WriteLine("La table n'existe pas. Procéder à l'initialisation.");
                    await TableCreate.CreateTable(erpApiClient.DbConnection!, "ChiffreAffairesParClient", "UIDTier uniqueidentifier PRIMARY KEY, Nom NVARCHAR(255) null, MontantTtc decimal null ");
                }
                else
                {
                    Console.WriteLine("La table existe déjà. Ignorer l'initialisation.");
                    await TableTruncate.TruncateTable(erpApiClient.DbConnection!, "chiffreAffairesParClient");
                }
                var extractedData = await ChiffreAffairesParClientExtract.ExtractChiffreAffairesParClientlAsync(apiUrl, token);
                var transformedData = ChiffreAffairesParClientTransform.TransformChiffreAffairesParClient(extractedData);
                await chiffreAffairesParClientLoad.LoadChiffreAffairesParClientAsync(transformedData);
                Console.WriteLine("Le processus ETL Document s'est terminé avec succès.");
            }
        }
    }
}
