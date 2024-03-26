using TSI_ERP_ETL.Models;

namespace TSI_ERP_ETL.ETL.Article
{
    public class ArticleTransform
    {
        public static IEnumerable<ArticleModel> ArticlesTransform(IEnumerable<ArticleModel> data)
        {
            // Transform the data here
            return data;
        }
    }
}
