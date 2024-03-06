using Azure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSI_ERP_ETL.Models;
using TSI_ERP_ETL.Models.Document;
using TSI_ERP_ETL.Models.GetAllPaged;

namespace TSI_ERP_ETL.ETL.Document
{
    public class DocumentTransform
    {
        public static IEnumerable<DocumentModel> TransformDocument(IEnumerable<DocumentModel> data)
        {
            List<string> stringList = new List<string>();
            int sumOfStringList = 0;

            foreach (var item in data)
            {
                // Transformation des éléments de la liste
                //string NumeroFactureOrigine = (item.NumeroFactureOrigine + 1).ToString();
                //stringList.Add(NumeroFactureOrigine);

                // Calcul de la somme des NumeroFactureOrigine
                //if (int.TryParse(NumeroFactureOrigine, out int num))
                {
                    //sumOfStringList += num;
                }
            }

            // Affichage de la somme des NumeroFactureOrigine
            Console.WriteLine($"Sum of elements in the Document list: {sumOfStringList}");
            return data;
        }
    }
}