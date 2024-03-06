﻿using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.Models;
using TSI_ERP_ETL.Models.Document;
using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.ETL.VdocumentDetail
{
    public class VdocumentDetailLoad
    {
        private readonly ETLDbContext _context;

        public VdocumentDetailLoad(ETLDbContext context)
        {
            _context = context;
        }

        public  async Task LoadVdocumentDetailAsync(IEnumerable<VdocumentDetailModel> data)

        {

            try
            {



                // Parcourir les données fournies
                foreach (var item in data)
                {

                    // Créer une instance de FournisseurETLModel à partir des données TierModel
                    var documentDetail = new DocumentDetailETLModel { Devise = item.Uid, Quantite = item.Quantite };
                    var document = new DocumentETLModel { MontantTtc = item.MontantTtc };

                    // Ajouter l'entité nouvellement créée au DbSet du contexte
                    await _context.DocumentDetail.AddAsync(documentDetail);
                    await _context.Document.AddAsync(document);
                }


                // Sauvegarder les changements dans la base de données
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Gérer les erreurs lors de la sauvegarde des changements dans la base de données
                // Enregistrez l'erreur ou inspectez l'exception interne
                Console.WriteLine($"Une erreur s'est produite lors de l'enregistrement des modifications de l'entité : {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Exception interne : {ex.InnerException.Message}");
                }

                // Éventuellement, relancer l'exception si vous ne pouvez pas la gérer ici
                throw;
            }
        }



    }
}