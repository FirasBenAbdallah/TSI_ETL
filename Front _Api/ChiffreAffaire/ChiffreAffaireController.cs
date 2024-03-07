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
    }
}
