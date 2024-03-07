using Microsoft.AspNetCore.Mvc;
using TSI_ERP_ETL.Models.ETLModel;
using TSI_ERP_ETL.Front_Api;

namespace TSI_ERP_ETL.Front_Api.Fournisseur
{
    [Route("api/[controller]")]
    [ApiController]
    public class FournisseursController : ControllerBase
    {
        private readonly FournisseurService _fournisseurService;

        public FournisseursController(FournisseurService fournisseurService)
        {
            _fournisseurService = fournisseurService;
        }

        [HttpGet("GetFournisseurs")]
        public async Task<ActionResult<IEnumerable<FournisseurETLModel>>> GetFournisseurs()
        {
            var fournisseurs = await _fournisseurService.GetFournisseursAsync();
            return Ok(fournisseurs);
        }
    }
}