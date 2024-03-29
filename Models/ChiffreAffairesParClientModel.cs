using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSI_ERP_ETL.Models
{
    public class ChiffreAffairesParClientModel
    {
        public Guid UIDTier { get; set; }

        public string Code { get; set; } = string.Empty;

        public string? Nom { get; set; }

        public string TypeTier { get; set; } = null!;

        public decimal? MontantHt { get; set; }

        public decimal? MontantDc { get; set; }

        public decimal? MontantHttransport { get; set; }

        public decimal? MontantTvatransport { get; set; }

        public decimal? MontantTtctransport { get; set; }

        public decimal? MontantFodec { get; set; }

        public decimal? MontantTva { get; set; }

        public decimal? MontantTaxes { get; set; }

        public decimal? MontantTimbre { get; set; }

        public decimal? MontantTtc { get; set; }

        public decimal? Reliquat { get; set; }

        public decimal? MontantRegle { get; set; }
    }
}
