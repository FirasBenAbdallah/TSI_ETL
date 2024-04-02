using TSI_ERP_ETL.Models;

namespace TSI_ERP_ETL.Front_Api.FactureClient
{
    public interface IFactureClientServices
    {
        Task<IEnumerable<FactureClientModel>> GetFacturesClientsAsync();
    }
}