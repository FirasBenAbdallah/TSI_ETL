using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.ETL.VdocumentDetail;
using TSI_ERP_ETL.TableUtilities;

namespace TSI_ERP_ETL.ETL.FicheFournisseur
{
    public class FicheFournisseurProcess
    {
        public static async Task FicheFournisseurProcesslAsync(ErpApiClient erpApiClient)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ETLDbContext>();
            optionsBuilder.UseSqlServer(erpApiClient.DbConnection!);
            var context = new ETLDbContext(optionsBuilder.Options);

            // Instantiate FournisseurLoad with DbContext
            var ficheFournisseurLoad = new FicheFournisseurLoad(context);

            // Utiliser BaseUrl de l'instance erpApiClient
            string apiUrl = erpApiClient.BaseUrl!;

            // Tronquer la table avant de charger de nouvelles données
            // Vérifier si la table "Document" existe

            bool tableExists = await DatabaseHelper.TableExistsAsync(erpApiClient.DbConnection!, "FicheFournisseur");
            if (!tableExists)
            {
                Console.WriteLine("La table n'existe pas. Procéder à l'initialisation.");

                await TableCreate.CreateTable(erpApiClient.DbConnection!, "FicheFournisseur", "Id INT NOT NULL, Code NVARCHAR(50), Nom NVARCHAR(150), Debit decimal null, Credit decimal null, Solde decimal null");
            }
            else
            {
                Console.WriteLine("La table existe déjà. Ignorer l'initialisation.");

                // Tronquer la table avant de charger de nouvelles données
                await TableTruncate.TruncateTable(erpApiClient.DbConnection!, "FicheFournisseur");
            }
            // Extraire les données à partir du point d'API
            var extractedData = await FicheFournisseurExtract.ExtractFicheFournisseurExtractAsync(erpApiClient.DbOlmiConnection!);
            //var sss = await DocumentExtract.ExtractDocumentAsync(apiUrl, loginUrl);

            // Transformer les données avant de les charger dans la base de données
            var transformedData = FicheFournisseurTransform.TransformFicheFournisseur(extractedData);

            await ficheFournisseurLoad.FicheFournisseurLoadAsync(transformedData);

            //  await documentLoad.LoadDocumentAsync(transformedDataqqq);

            // Enregistrer le message de fin du processus ETL Document
            Console.WriteLine("Le processus ETL ficheFournisseur s'est terminé avec succès.");
        }
    }
}