using Microsoft.AspNetCore.Mvc;
using System.Globalization;
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

        [HttpPost("GetDate")]
        public async Task<ActionResult<IEnumerable<ArticleETLModel>>> FilterByDateRange([FromBody] ChiffreAffaireRequest request)
        {
            try
            {
                // Convertir les dates string en objets DateTime
                var startDate = DateTime.ParseExact(request.StartDate!, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var endDate = DateTime.ParseExact(request.EndDate!, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                // Appel de la méthode de service pour filtrer par plage de dates
                var articles = await _articleService.FilterArticlesByDateRangeAsync(startDate, endDate);

                if (articles == null || !articles.Any())
                {
                    return NotFound($"Aucun article trouvé pour la plage de dates spécifiée.");
                }

                return Ok(articles);
            }
            catch (Exception ex)
            {
                // En cas d'erreur inattendue, renvoyer une réponse avec le code d'erreur 500
                return StatusCode(500, $"Une erreur s'est produite lors du traitement de la requête : {ex.Message}");
            }
        }
    }
}
