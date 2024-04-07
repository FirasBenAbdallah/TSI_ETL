using Microsoft.AspNetCore.Mvc;
using TSI_ERP_ETL.Models.ETLModel;
using TSI_ERP_ETL.Models.Requests;

namespace TSI_ERP_ETL.Front_Api.FactureClient
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactureClientController : ControllerBase
    {
        private readonly IFactureClientServices _factureClientServices;

        public FactureClientController(IFactureClientServices factureClientServices)
        {
            _factureClientServices = factureClientServices;
        }

        [HttpGet("GetFacturesClient")]
        public async Task<ActionResult<IEnumerable<FactureClientETLModel>>> GetFacturesClientsAsync()
        {
            var facturesClients = await _factureClientServices.GetFacturesClientsAsync();
            return Ok(facturesClients);
        }

        [HttpPost("GetFacturesByCodeClient")]
        public async Task<ActionResult<IEnumerable<FactureClientETLModel>>> GetFacturesByCodeClientAsync([FromBody] FactureClientRequest FactureClient)
        {
            var facturesClients = await _factureClientServices.GetFacturesByCodeClientAsync(FactureClient.Code!);
            return Ok(facturesClients);
        }

        [HttpGet("GetPagedFacturesClient")]
        public async Task<ActionResult> GetPagedFacturesClientAsync([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var (facturesClients, totalCount) = await _factureClientServices.GetFacturesClientsPagedAsync(pageNumber, pageSize);
            
            if (pageNumber < 1 || pageSize < 1)
            {
                return BadRequest("PageNumber and PageSize must be greater than 0.");
            }

            var response = new
            {
                TotalCount = totalCount,
                PageSize = pageSize,
                PageNumber = pageNumber,
                Data = facturesClients
            };

            return Ok(response);
        }
    }
}
