using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSI_ERP_ETL.Models;
using TSI_ERP_ETL.Models.Document;

namespace TSI_ERP_ETL.ETL.Document
{
    public class ChiffreAffaire
    {

        public static IEnumerable<DocumentDetailRequest> TransformChiffreAffaire(IEnumerable<DocumentDetailRequest> data)
        {
            List<double> CAList = new List<double>();
            double Chiffre_Affaire = 0;

            foreach (var item in data)
            {
                // Transformation des éléments de la liste
                decimal? quantite = (decimal)item.Quantite;
                decimal? Montant = item.MontantTtc;

                Chiffre_Affaire = (double)(quantite * Montant);
                // Calcul de la somme des NumeroFactureOrigine

            }
            Console.WriteLine($"Sum of Chiffre_Affaire list: {Chiffre_Affaire}");

            return data;

        }

    }
}
