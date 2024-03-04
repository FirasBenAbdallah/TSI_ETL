using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TSI_ERP_ETL.Models.ETLModel;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.Models;

namespace TSI_ERP_ETL.Front_Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class FournisseursController : ControllerBase
    {
        private readonly ETLDbContext _context;

        public FournisseursController(ETLDbContext context)
        {
            _context = context;
        }

        // GET: api/Fournisseurs
        [HttpGet]
        [Route("/GetAll")]
        public async Task<ActionResult<IEnumerable<FournisseurETLModel>>> GetFournisseurs()
        {
            return await _context.Fournisseur.ToListAsync();
        }
    }
}
