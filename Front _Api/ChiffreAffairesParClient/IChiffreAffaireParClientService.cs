using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.Front_Api.ChiffreAffairesParClient
{
    public interface IChiffreAffaireParClientService
    {
        Task<IEnumerable<ChiffreAffairesParClientETLModel>> GetChiffreAffairesParClientAsync();
        Task<(IEnumerable<ChiffreAffairesParClientETLModel> data, int totalCount)> GetChiffreAffairesParClientPagedAsync(int pageNumber, int pageSize);
    }
}