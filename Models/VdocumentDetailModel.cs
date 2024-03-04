namespace TSI_ERP_ETL.Models
{
    public struct VdocumentDetailModel
    {
        public string? CodeArticle { get; set; }//TODO Take it
        public string? LibelleArticle { get; set; }//TODO Take it
        public DateTime? DateDocument { get; set; }//TODO Take it
        public decimal? PrixUnitaire { get; set; }//TODO Take it
        public double? Quantite { get; set; }//TODO Take it
        public decimal? MontantHt { get; set; }//TODO Take it
        public Guid? Uidaffectation { get; set; }//TODO Take it
        public Guid? Uidarticle { get; set; }//TODO Take it
        public Guid Uid { get; set; }//TODO Take it
    }
}