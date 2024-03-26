using Microsoft.EntityFrameworkCore;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.Front_Api.Article
{
    public class ArticleService : IArticleService
    {
        private readonly ETLDbContext _context;

        public ArticleService(ETLDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ArticleETLModel>> GetArticlesAsync()
        {
            return await _context.Article.ToListAsync();
        }
    }
}
