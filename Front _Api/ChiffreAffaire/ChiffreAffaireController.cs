using Microsoft.AspNetCore.Mvc;
using TSI_ERP_ETL.Models.ETLModel;

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

        [HttpPost("FilterByYear")]
        public async Task<ActionResult<IEnumerable<DocumentDetailETLModel>>> FilterByYear([FromBody] ChiffreAffaireRequest request)
        {
            var chiffreAffaire = await _chiffreAffaireService.FilterChiffreAffaireByYearAsync(request.Year);
            if (chiffreAffaire == null || !chiffreAffaire.Any())
            {
                return NotFound($"No chiffre d'affaire found for year {request.Year}.");
            }

            return Ok(chiffreAffaire);
        }
    }
}
