using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.Front_Api.Client
{
    public interface IClientService
    {
        Task<IEnumerable<ClientETLModel>> GetClientsWithArticlesAsync();
    }
}