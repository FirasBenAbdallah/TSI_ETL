using Microsoft.EntityFrameworkCore;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.Models;
using TSI_ERP_ETL.Models.ETLModel;
using TSI_ERP_ETL.Resource;

namespace TSI_ERP_ETL.ETL.VdocumentDetail
{
    public class VdocumentDetailLoad
    {
        private readonly ETLDbContext _context;

        public VdocumentDetailLoad(ETLDbContext context)
        {
            _context = context;
        }

        public async Task LoadVdocumentDetailAsync(IEnumerable<VdocumentDetailModel> data)

        {
            try
            {
                // Récupérer la liste des montants TTC
                var list = SharedResource.MontantTtcList;

                // Parcourir les données fournies
                foreach (var (item, index) in data.Select((item, index) => (item, index)))
                {
                    // Vérifier si l'index est inférieur à la taille de la liste
                    if (index < list.Count)
                    {
                        // Créer un nouvel objet DocumentDetailETLModel avec MontantTtc
                        var documentDetail = new DocumentDetailETLModel { Devise = item.Uid, Quantite = item.Quantite,DateFilter = item.DateDocument, MontantTtc = list[index] };
                        // Ajouter l'objet à la table DocumentDetail
                        await _context.DocumentDetail.AddAsync(documentDetail);
                    }
                    // Si l'index est supérieur à la taille de la liste
                    else
                    {
                        // Créer un nouvel objet DocumentDetailETLModel sans MontantTtc
                        var documentDetail = new DocumentDetailETLModel { Devise = item.Uid, Quantite = item.Quantite, DateFilter = item.DateDocument };
                        // Ajouter l'objet à la table DocumentDetail
                        await _context.DocumentDetail.AddAsync(documentDetail);
                    }
                }
                // Sauvegarder les changements dans la base de données
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Traiter l'exception DbUpdateException ici
                Console.WriteLine($"Une erreur s'est produite lors de l'enregistrement des modifications de l'entité : {ex.Message}");

                if (ex.InnerException != null)
                {
                    // Traiter l'exception interne ici si nécessaire
                    Console.WriteLine($"Exception interne : {ex.InnerException.Message}");
                }
                // Rejeter l'exception DbUpdateException
                throw;
            }
        }
    }
}