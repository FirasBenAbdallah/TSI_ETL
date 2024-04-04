using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.Front_Api.Article
{
    public interface IArticleService
    {
        Task<IEnumerable<ArticleETLModel>> GetArticlesAsync();
        Task<IEnumerable<ArticleETLModel>> GetArticlesByCodeClientAsync(string CodeClient);
        Task<IEnumerable<ArticleETLModel>> FilterArticlesByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}