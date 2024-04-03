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
    }
}