using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSI_ERP_ETL.Front_Api.Fournisseur;
using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.Front_Api.ChiffreAffairesParClient
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiffreAffaireParClientController : ControllerBase
    {
        private readonly ChiffreAffaireParClientService _chiffreAffaireParClientService;

        public ChiffreAffaireParClientController(ChiffreAffaireParClientService chiffreAffaireParClientService)
        {
            _chiffreAffaireParClientService = chiffreAffaireParClientService;
        }
        [HttpGet("GetChiffreAffaireParClient")]
        public async Task<ActionResult<IEnumerable<ChiffreAffairesParClientETLModel>>> GetChiffreAffairesParClient()
        {
            var chiffreAffaireClient = await _chiffreAffaireParClientService.GetChiffreAffairesParClientAsync();
            return Ok(chiffreAffaireClient);
        }

        [HttpGet("GetPagedChiffreAffaireParClient")]
        public async Task<ActionResult> GetPagedFacturesClientAsync([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            if (pageNumber < 1 || pageSize < 1)
            {
                return BadRequest("PageNumber and PageSize must be greater than 0.");
            }

            var (chiffreAffaireParClient, totalCount) = await _chiffreAffaireParClientService.GetChiffreAffairesParClientPagedAsync(pageNumber, pageSize);

            var response = new
            {
                TotalCount = totalCount,
                PageSize = pageSize,
                PageNumber = pageNumber,
                Data = chiffreAffaireParClient
            };

            return Ok(response);
        }
    }
}
