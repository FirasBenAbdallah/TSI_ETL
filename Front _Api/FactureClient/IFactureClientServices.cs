using TSI_ERP_ETL.Models;
using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.Front_Api.FactureClient
{
    public interface IFactureClientServices
    {
        Task<IEnumerable<FactureClientETLModel>> GetFacturesClientsAsync();
        Task<IEnumerable<FactureClientETLModel>> GetFacturesByCodeClientAsync(string Code);
        Task<(IEnumerable<FactureClientETLModel> data, int totalCount)> GetFacturesClientsPagedAsync(int pageNumber, int pageSize);
    }
}