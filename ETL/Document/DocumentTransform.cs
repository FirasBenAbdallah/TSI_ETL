using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSI_ERP_ETL.Models;
using TSI_ERP_ETL.Models.Document;

namespace TSI_ERP_ETL.ETL.Document
{
    public class DocumentTransform
    {

        public static IEnumerable<DocumentModel> TransformDocument(IEnumerable<DocumentModel> data)
        {
            foreach (var item in data)
            {
                item.NumDocument += " Country";
                //Console.WriteLine(item.RaisonSociale);
            }

            List<int?> list = new List<int?>();
            // Assuming 'data' is a collection of objects with a property 'Code'
            foreach (var item in data)
            {
                //int NumeroEtablissement = int.Parse(item.NumeroEtablissement!);
                int? VariationStock = item.VariationStock + 1;
                list.Add(VariationStock);
                //Console.WriteLine("\n", item.NumeroEtablissement);
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