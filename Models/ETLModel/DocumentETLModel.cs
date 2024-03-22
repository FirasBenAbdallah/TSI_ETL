using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSI_ERP_ETL.Models.ETLModel
{
    public class DocumentETLModel
    {
        public Guid Devise { get; set; } // Assuming an ID column exists
        public decimal? MontantTtc { get; set; }
    }
}
