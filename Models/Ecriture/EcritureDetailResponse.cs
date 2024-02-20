namespace TSI_ERP_ETL.Models.Ecriture
{
    public record EcritureDetailResponse
    {
        public Guid Uid { get; set; }
        public Guid Ecriture { get; set; }
        public int? Numero { get; set; }
        public int Nligne { get; set; }
        public Guid Compte { get; set; }
        public string? CompteLibelle { get; set; }
        public string? LibelleEd { get; set; }
        public Guid? Tier { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public Guid? AffectationTresorerie { get; set; }
        public string? Nsequence { get; set; }
        public string? Client { get; set; }
        public string? Reference { get; set; }
        public Guid Affectation { get; set; }
        public DateTime? DateEcheance { get; set; }
        public string? Observation { get; set; }
        public string? Lettree { get; set; }
        public int? Indice { get; set; }
        public string? JournalLibelle { get; set; }
        public string? AffectationLibelle { get; set; }
        public DateTime? DateEcriture { get; set; }
        public string? JournalCode { get; set; }
        public string? Npiece { get; set; }
    }
}
