﻿using Microsoft.EntityFrameworkCore;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.TableUtilities;

namespace TSI_ERP_ETL.ETL.Article
{
    public class ArticleProcess
    {
        public static async Task ProcessArticleAsync(string token, ErpApiClient erpApiClient)
        {
            {
                if (token is null)
                {
                    throw new ArgumentNullException(nameof(token));
                }

                {
                    // Configure DbContext
                    var optionsBuilder = new DbContextOptionsBuilder<ETLDbContext>();
                    optionsBuilder.UseSqlServer(erpApiClient.DbConnection!);
                    var context = new ETLDbContext(optionsBuilder.Options);

                    // Instantiate FournisseurLoad with DbContext
                    var articleLoad = new ArticleLoad(context);

                    // Utiliser BaseUrl de l'instance erpApiClient
                    string apiUrl = erpApiClient.BaseUrl!;

                    // Vérifier si la table "Document" existe
                    bool tableExists = await DatabaseHelper.TableExistsAsync(erpApiClient.DbConnection!, "Article");
                    if (!tableExists)
                    {
                        Console.WriteLine("La table n'existe pas. Procéder à l'initialisation.");

                        await TableCreate.CreateTable(erpApiClient.DbConnection!, "Article", "Id INT NOT NULL PRIMARY KEY, Uid NVARCHAR(255), DateDocument DATETIME, CodeClient NVARCHAR(50), NomClient NVARCHAR(150), Libelle NVARCHAR(MAX), FamilleArticle NVARCHAR(255), Quantite FLOAT, MontantTTC MONEY, ChiffreAffaire MONEY");
                    }
                    else
                    {
                        Console.WriteLine("La table existe déjà. Ignorer l'initialisation.");

                        // Tronquer la table avant de charger de nouvelles données
                        await TableTruncate.TruncateTable(erpApiClient.DbConnection!, "Article");
                    }
                    // Extraire les données à partir du point d'API
                    var extractedData = await ArticleExtract.ExtractArticleAsync(erpApiClient.DbOlmiConnection!);

                    // Transformer les données avant de les charger dans la base de données
                    var transformedData = ArticleTransform.ArticlesTransform(extractedData);

                    // Charger les données transformées dans la base de données
                    await articleLoad.LoadArticlelAsync(transformedData);

                    // Enregistrer le message de fin du processus ETL Document
                    Console.WriteLine("Le processus ETL Article s'est terminé avec succès.");
                }
            }
        }
    }
}
