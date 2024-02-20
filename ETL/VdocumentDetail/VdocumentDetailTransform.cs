using TSI_ERP_ETL.Models;

namespace TSI_ERP_ETL.ETL.VdocumentDetail
{
    public class VdocumentDetailTransform
    {
        public static IEnumerable<VdocumentDetailModel> TransformVdocumentDetail(IEnumerable<VdocumentDetailModel> data)
        {
            decimal? sumNombreDevises = 0;
            sumNombreDevises = data.Sum(item => item.PrixUnitaire);
            Console.WriteLine($"The sum of NombreDevises is: {sumNombreDevises}");

            // Transform the data here
            return data;
        }
    }
}
