using Microsoft.AspNetCore.Mvc;
using TSI_ERP_ETL.Models;

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
        public async Task<ActionResult<IEnumerable<FactureClientModel>>> GetFacturesClientsAsync()
        {
            var facturesClients = await _factureClientServices.GetFacturesClientsAsync();
            return Ok(facturesClients);
        }
    }
}
