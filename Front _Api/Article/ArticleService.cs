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

        // Get all articles :
        public async Task<IEnumerable<ArticleETLModel>> GetArticlesAsync()
        {
            return await _context.Article.ToListAsync();
        }

        // New service method to get distinct NomClient values:
        public async Task<IEnumerable<string?>> GetDistinctNomClientAsync()
        {
            return await _context.Article
                .Select(article => article.NomClient)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<ClientInfoDTO>> GetClientInfoAsync()
        {
            return await _context.Article
                .Select(article => new ClientInfoDTO
                {
                    NomClient = article.NomClient,
                    CodeClient = article.CodeClient
                })
                .Distinct()
                .OrderByDescending(T => T.NomClient)
                .ToListAsync();
        }


        // Get articles by client code :
        public async Task<IEnumerable<ArticleETLModel>> GetArticlesByCodeClientAsync(string CodeClient)
        {
            return await _context.Article.Where(x => x.CodeClient == CodeClient).ToListAsync();
        }

        // Filter chiffre d'affaire by date range :
        public async Task<IEnumerable<ArticleETLModel>> FilterArticlesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Article
                .Where(x => x.DateDocument.HasValue &&
                            x.DateDocument.Value >= startDate &&
                            x.DateDocument.Value <= endDate)
                .OrderBy(x => x.DateDocument!.Value)
                .ToListAsync();
        }

        public async Task<(IEnumerable<ArticleETLModel> data, int totalCount)> GetArticlesPagedAsync(int pageNumber, int pageSize)
        {
            var totalCount = await _context.Article.CountAsync();
            var pagedData = await _context.Article
                                        .Skip((pageNumber - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();
            return (pagedData, totalCount);
        }
    }
}
