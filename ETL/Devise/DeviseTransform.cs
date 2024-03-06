using TSI_ERP_ETL.Models;

namespace TSI_ERP_ETL.ETL.Devise
{
    public class DeviseTransform
    {
        public static IEnumerable<DeviseModel> TransformData(IEnumerable<DeviseModel> data)
        {
            double? sumNombreDevises = 0;
            foreach (var item in data)
            {
                item.LibelleDevise += " Devise";
            }
            sumNombreDevises = data.Sum(item => item.NumeroDevise);
            //Console.WriteLine($"The sum of NombreDevises is: {sumNombreDevises}");

            // Transform the data here
            return data;
        }
    }
}
