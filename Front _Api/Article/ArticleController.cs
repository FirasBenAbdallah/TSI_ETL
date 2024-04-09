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
                var pageNumber = request.PageNumber;
                var pageSize = request.PageSize;

                // Appel de la méthode de service pour filtrer par plage de dates
                var (articles, totalCount) = await _articleService.FilterArticlesByDateRangeAsync(startDate, endDate, pageNumber, pageSize);

                if (articles == null || !articles.Any())
                {
                    return NotFound($"Aucun article trouvé pour la plage de dates spécifiée.");
                }

                var response = new
                {
                    TotalCount = totalCount,
                    PageSize = pageSize,
                    PageNumber = pageNumber,
                    Data = articles
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                // En cas d'erreur inattendue, renvoyer une réponse avec le code d'erreur 500
                return StatusCode(500, $"Une erreur s'est produite lors du traitement de la requête : {ex.Message}");
            }
        }

        [HttpGet("GetPagedArticles")]
        public async Task<ActionResult> GetPagedFacturesClientAsync([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            if (pageNumber < 1 || pageSize < 1)
            {
                return BadRequest("PageNumber and PageSize must be greater than 0.");
            }

            var (articles, totalCount) = await _articleService.GetArticlesPagedAsync(pageNumber, pageSize);

            var response = new
            {
                TotalCount = totalCount,
                PageSize = pageSize,
                PageNumber = pageNumber,
                Data = articles
            };

            return Ok(response);
        }

        [HttpGet("GetDistinctNomClient")]
        public async Task<ActionResult<IEnumerable<string?>>> GetDistinctNomClient()
        {
            var distinctNomClients = await _articleService.GetDistinctNomClientAsync();
            return Ok(distinctNomClients);
        }

        [HttpGet("GetClientInfo")]
        public async Task<ActionResult<IEnumerable<ClientInfoDTO>>> GetClientInfo()
        {
            var clientInfo = await _articleService.GetClientInfoAsync();
            return Ok(clientInfo);
        }
    }
}
