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

        //[HttpPost("FilterByYear")]
        //public async Task<ActionResult<IEnumerable<DocumentDetailETLModel>>> FilterByYear([FromBody] ChiffreAffaireRequest request)
        //{
        //    var chiffreAffaire = await _chiffreAffaireService.FilterChiffreAffaireByYearAsync(request.sYear);
        //    if (chiffreAffaire == null || !chiffreAffaire.Any())
        //    {
        //        return NotFound($"No chiffre d'affaire found for year {request.Year}.");
        //    }

        //    return Ok(chiffreAffaire);
        //}

        

        [HttpPost("FilterByMonth")]
        public async Task<ActionResult<IEnumerable<DocumentDetailETLModel>>> FilterByMonth([FromBody] ChiffreAffaireRequest request)
        {
            if (request.StartYear > request.EndYear ||
                (request.StartYear == request.EndYear && request.StartMonth > request.EndMonth))
            {
                return BadRequest("Invalid start and end dates.");
            }

            var chiffreAffaire = await _chiffreAffaireService.FilterChiffreAffaireByDateRangeAsync(request.StartYear, request.StartMonth, request.EndYear, request.EndMonth);

            if (chiffreAffaire == null || !chiffreAffaire.Any())
            {
                return NotFound($"No chiffre d'affaire found for the specified date range.");
            }

            return Ok(chiffreAffaire);
        }


    }
}
