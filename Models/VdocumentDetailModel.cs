using System.Xml;

namespace TSI_ERP_ETL.Models
{
    public struct VdocumentDetailModel
    {
        public string? CodeArticle { get; set; }
        public string? LibelleArticle { get; set; }
        public string? ObservationDocument { get; set; }
        public DateTime? DateDocument { get; set; }
        public string? TypeDocument { get; set; }
        public string? CodeAffectation { get; set; }
        public string? LibelleAffectation { get; set; }
        public Guid? UIDAffectation { get; set; }
        public Guid? UIDArticle { get; set; }
        public DateTime? DateLivraisonSouhaitee { get; set; }
        public decimal? PrixUnitaire { get; set; }
        public double? Quantite { get; set; }
        public float? TauxRemise { get; set; }
        public decimal? MontantHt { get; set; }
        public float? TauxFodec { get; set; }
        public decimal? MontantFodec { get; set; }
        public float? TauxTva { get; set; }
        public string? LibelleAffectationFR { get; set; }
        public Guid Uid { get; set; }
    }
}