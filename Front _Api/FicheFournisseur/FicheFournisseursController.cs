using Microsoft.AspNetCore.Mvc;
using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.Front_Api.FicheFournisseur
{
    [Route("api/[controller]")]
    [ApiController]
    public class FicheFournisseursController : ControllerBase
    {
        private readonly IFicheFournisseurService _ficheFournisseurService;

        public FicheFournisseursController(IFicheFournisseurService ficheFournisseurService)
        {
            _ficheFournisseurService = ficheFournisseurService;
        }

        [HttpGet("GetFicheFournisseurs")]
        public async Task<ActionResult<IEnumerable<FicheFournisseurETLModel>>> GetFicheFournisseurs()
        {
            var fournisseurs = await _ficheFournisseurService.GetFicheFournisseursAsync();
            return Ok(fournisseurs);
        }

        [HttpGet("GetPagedFicheFournisseurs")]
        public async Task<ActionResult> GetPagedFacturesClientAsync([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            if (pageNumber < 1 || pageSize < 1)
            {
                return BadRequest("PageNumber and PageSize must be greater than 0.");
            }

            var (ficheFournisseurs, totalCount) = await _ficheFournisseurService.GetFicheFournisseursPagedAsync(pageNumber, pageSize);

            var response = new
            {
                TotalCount = totalCount,
                PageSize = pageSize,
                PageNumber = pageNumber,
                Data = ficheFournisseurs
            };

            return Ok(response);
        }
    }
}