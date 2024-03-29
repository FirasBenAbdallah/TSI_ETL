using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using TSI_ERP_ETL.Models.ETLModel;
using TSI_ERP_ETL.Models.Requests;

namespace TSI_ERP_ETL.Front_Api.ChiffreAffaire
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiffreAffaireController : ControllerBase
    {
        private readonly ChiffreAffaireService _chiffreAffaireService;

        public ChiffreAffaireController(ChiffreAffaireService chiffreAffaireService)
        {
            _chiffreAffaireService = chiffreAffaireService;
        }

        [HttpGet("GetChiffreAffaire")]
        public async Task<ActionResult<IEnumerable<DocumentDetailETLModel>>> GetChiffreAffaire()
        {
            var chiffreAffaire = await _chiffreAffaireService.GetChiffreAffaireAsync();
            return Ok(chiffreAffaire);
        }

        [HttpPost("GetDate")]
        public async Task<ActionResult<IEnumerable<DocumentDetailETLModel>>> FilterByMonth([FromBody] ChiffreAffaireRequest request)
        {
            try
            {
                // Convertir les dates string en objets DateTime
                var startDate = DateTime.ParseExact(request.StartDate!, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var endDate = DateTime.ParseExact(request.EndDate!, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                // Appel de la méthode de service pour filtrer par plage de dates
                var chiffreAffaire = await _chiffreAffaireService.FilterChiffreAffaireByDateRangeAsync(startDate, endDate);

                if (chiffreAffaire == null || !chiffreAffaire.Any())
                {
                    return NotFound($"Aucun chiffre d'affaire trouvé pour la plage de dates spécifiée.");
                }

                return Ok(chiffreAffaire);
            }
            catch (Exception ex)
            {
                // En cas d'erreur inattendue, renvoyer une réponse avec le code d'erreur 500
                return StatusCode(500, $"Une erreur s'est produite lors du traitement de la requête : {ex.Message}");
            }
        }
    }
}
