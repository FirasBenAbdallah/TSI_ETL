using TSI_ERP_ETL.Models;

namespace TSI_ERP_ETL.ETL.Client
{
    public class ClientTransform
    {
        public static IEnumerable<ClientModel> ClientsTransform(IEnumerable<ClientModel> data)
        {
            // Transform the data here
            return data;
        }
    }
}
