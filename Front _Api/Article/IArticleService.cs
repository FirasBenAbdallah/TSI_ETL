using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.Front_Api.Article
{
    public interface IArticleService
    {
        Task<IEnumerable<ArticleETLModel>> GetArticlesAsync();
        Task<IEnumerable<ArticleETLModel>> GetArticlesByCodeClientAsync(string CodeClient);
        Task<(IEnumerable<ArticleETLModel> data, int totalCount)> FilterArticlesByDateRangeAsync(DateTime startDate, DateTime endDate, int pageNumber, int pageSize);
        Task<(IEnumerable<ArticleETLModel> data, int totalCount)> GetArticlesPagedAsync(int pageNumber, int pageSize);
        Task<IEnumerable<string?>> GetDistinctNomClientAsync();
        Task<IEnumerable<ClientInfoDTO>> GetClientInfoAsync();
    }
}