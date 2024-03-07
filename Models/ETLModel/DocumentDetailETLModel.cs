using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSI_ERP_ETL.Models.ETLModel
{
    public class DocumentDetailETLModel
    {
        public Guid Devise { get; set; } // Assuming an ID column exists
        public double? Quantite { get; set; }
        public decimal? MontantTtc { get; set; }

        //public int RowIndex { get; set; }  // Add this property

    }
}
