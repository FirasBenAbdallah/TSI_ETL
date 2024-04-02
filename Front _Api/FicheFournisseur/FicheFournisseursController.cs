using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSI_ERP_ETL.Front_Api.Fournisseur;
using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.Front__Api.FicheFournisseur
{
    [Route("api/[controller]")]
    [ApiController]
    public class FicheFournisseursController : ControllerBase
    {
        private readonly FicheFournisseurService _ficheFournisseurService;
        public FicheFournisseursController(FicheFournisseurService ficheFournisseurService)
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
