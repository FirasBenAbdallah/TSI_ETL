using Microsoft.AspNetCore.Mvc;
using TSI_ERP_ETL.Models.ETLModel;
using TSI_ERP_ETL.Models.Requests;

namespace TSI_ERP_ETL.Front_Api.Article
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("GetArticles")]
        public async Task<ActionResult<IEnumerable<ArticleETLModel>>> GetArticles()
        {
            var articles = await _articleService.GetArticlesAsync();
            return Ok(articles);
        }

        [HttpPost("GetArticlesByCodeClient")]
        public async Task<ActionResult<IEnumerable<ArticleETLModel>>> GetArticlesByCodeClient([FromBody] CodeClientRequest CodeClient)
        {
            var articles = await _articleService.GetArticlesByCodeClientAsync(CodeClient.CodeClient!);
            return Ok(articles);
        }
    }
}
