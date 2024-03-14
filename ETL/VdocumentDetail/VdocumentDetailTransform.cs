using TSI_ERP_ETL.Models;

namespace TSI_ERP_ETL.ETL.VdocumentDetail
{
    public class VdocumentDetailTransform
    {
        public static IEnumerable<VdocumentDetailModel> documentDetailTransform(IEnumerable<VdocumentDetailModel> data)
        {
            double? sumNombreDevises = 0;
            sumNombreDevises = data.Sum(item => item.Quantite);

            decimal? sumNombreDevi = 0;
            //sumNombreDevi = data.Sum(item => item.MontantTtc);

            Console.WriteLine($"The sum of NombreDevises is: {sumNombreDevi}");
            Console.WriteLine($"The sum of NombreDevises is: {sumNombreDevi}");

            // Transform the data here
            return data;
        }
    }
}