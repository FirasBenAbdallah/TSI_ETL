using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSI_ERP_ETL.Models;

namespace TSI_ERP_ETL.ETL.Tier.Fournisseur
{
    public class FournisseurTransform
    {
        public static IEnumerable<TierModel> TransformFournisseurData(IEnumerable<TierModel> data)
        {
            foreach (var item in data)
            {
                item.RaisonSociale += " Country";
                Console.WriteLine(item.RaisonSociale);
            }

            List<int?> list = new List<int?>();
            // Assuming 'data' is a collection of objects with a property 'Code'
            foreach (var item in data)
            {
                //int NumeroEtablissement = int.Parse(item.NumeroEtablissement!);
                int? NumeroEtablissement = item.NumeroEtablissement + 1;
                list.Add(NumeroEtablissement);
                Console.WriteLine("\n", item.NumeroEtablissement);
            }
            // Calculating the sum of elements in the 'list'
            int? sumOfList = 0;
            sumOfList = list.Sum();
            /*foreach (var element in list)
            {
                sumOfList += element;
            }*/
            Console.WriteLine($"Sum of elements in the list: {sumOfList}");
            // Transform the data here
            return data;
        }
    }
}
