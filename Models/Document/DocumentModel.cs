using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSI_ERP_ETL.Models.Document
{
    public class DocumentModel
    {
        public Guid Uid { get; set; }
        public Guid? Tier { get; set; }
        public string? LibelleTiers { get; set; } = string.Empty;
        public DateTime? DateDocument { get; set; }
        public string? NumDocument { get; set; }
        public Guid? NatureDocumentGuid { get; set; }
        public string? NatureDocument { get; set; }
        public string? NumChezTiers { get; set; }
        public string? AffectationLibelle { get; set; }
        public DateTime? DateEcheance { get; set; }
        public decimal MontantHt { get; set; }
        public decimal MontantFodec { get; set; }
        public decimal MontantTva { get; set; }
        public decimal MontantTtc { get; set; }
        public decimal MontantRg { get; set; }
        public decimal NetApayer { get; set; }
        public decimal MontantRegle { get; set; }
        public decimal ReliquatNet { get; set; }
        public bool Payee { get; set; }
        public decimal MontantRegleRg { get; set; }
        public decimal ReliquatRg { get; set; }
        public bool Rgpayee { get; set; }
        public string Observation { get; set; } = string.Empty;
        public string Objet { get; set; } = string.Empty;
        public string PersonneLibelle { get; set; } = string.Empty;
        public string Moderegldef { get; set; } = string.Empty;
        public string Workflow { get; set; } = string.Empty;
        public string Etat { get; set; } = string.Empty;

    }
}
