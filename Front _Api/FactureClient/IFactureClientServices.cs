using TSI_ERP_ETL.Models;

namespace TSI_ERP_ETL.Front__Api.FactureClient
{
    public interface IFactureClientServices
    {
        Task<IEnumerable<FactureClientModel>> GetFacturesClientsAsync();
    }
}