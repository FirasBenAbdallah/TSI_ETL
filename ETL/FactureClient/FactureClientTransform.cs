using TSI_ERP_ETL.Models;

namespace TSI_ERP_ETL.ETL.FactureClient
{
    public class FactureClientTransform
    {
        public static IEnumerable<FactureClientModel> FactureClientsTransform(IEnumerable<FactureClientModel> data)
        {
            return data;
        }
    }
}
