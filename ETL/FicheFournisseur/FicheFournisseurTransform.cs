using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSI_ERP_ETL.Models;
using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.ETL.FicheFournisseur
{
    public class FicheFournisseurTransform
    {
        public static IEnumerable<FicheFournisseurETLModel> TransformFicheFournisseur(IEnumerable<FicheFournisseurModel> data)
        {
            List<FicheFournisseurETLModel> transformedData = new();
            int id = 0;

            foreach (var item in data)
            {
                decimal soldeItem = (decimal)(item.Debit ?? 0) - (decimal)(item.Credit ?? 0); // Explicitly cast to decimal
                id++;
                //Console.WriteLine($"Solde for item {item.Code}: {soldeItem}");

                // Ajoutez l'élément transformé à la liste
                transformedData.Add(new FicheFournisseurETLModel(id, item.Code, item.Nom, item.Debit, item.Credit, soldeItem));
            }

            return transformedData;
        }
    }
}
