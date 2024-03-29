using Microsoft.AspNetCore.Mvc;
using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.Front_Api.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("GetClientsWithArticles")]
        public async Task<ActionResult<IEnumerable<ClientETLModel>>> GetClientsWithArticles()
        {
            var clients = await _clientService.GetClientsWithArticlesAsync();
            return Ok(clients);
        }
    }
}
