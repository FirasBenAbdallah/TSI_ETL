using Microsoft.EntityFrameworkCore;

namespace TSI_ERP_ETL.Models.ETLModel
{
    public class FournisseurETLModel
    {
        public Guid FournisseurId { get; set; } // Assuming an ID column exists
        public string? RaisonSocial { get; set; }
    }
}
