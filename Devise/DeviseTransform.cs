using TSI_ERP_ETL.Models;

namespace TSI_ERP_ETL.Devise
{
    public class DeviseTransform
    {
        public static IEnumerable<DeviseModel> TransformData(IEnumerable<DeviseModel> data)
        {
            foreach (var item in data)
            {
                item.numeroDevise = item.numeroDevise + 0.62;
            }

            return data;
        }
    }
}
