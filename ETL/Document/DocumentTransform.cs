using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSI_ERP_ETL.Models.Document;

namespace TSI_ERP_ETL.ETL.Document
{
    public class DocumentTransform
    {
        public static IEnumerable<DocumentModel> TransformDocument(IEnumerable<DocumentModel> data)
        {
            decimal? sumNombreDocuments = 0;
            sumNombreDocuments = data.Sum(item => item.MontantTimbre);
            //Console.WriteLine($"The sum of NombreDevises is: {sumNombreDocuments}");

            // Transform the data here
            return data;
        }
    }
}
