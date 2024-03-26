using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.Front_Api.ChiffreAffaire
{
    public interface IChiffreAffaireService
    {
        Task<IEnumerable<DocumentDetailETLModel>> FilterChiffreAffaireByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<DocumentDetailETLModel>> FilterChiffreAffaireByYearAsync(int year);
        Task<IEnumerable<DocumentDetailETLModel>> GetChiffreAffaireAsync();
    }
}