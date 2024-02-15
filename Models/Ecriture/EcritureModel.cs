namespace TSI_ERP_ETL.Models.Ecriture
{
    public record EcritureModel
    {
        public Guid Uid { get; set; }
        public Guid Journal { get; set; }
        public Guid? Exercice { get; set; }
        public string? Compte { get; set; }
        public int Numero { get; set; }
        public string? Origine { get; set; }
        public DateTime DateEcriture { get; set; }
        public string? Npiece { get; set; }
        public DateTime? DatePiece { get; set; }
        public string? Npiece2 { get; set; }
        public DateTime? DatePiece2 { get; set; }
        public IEnumerable<EcritureDetailResponse>? EcritureDetails { get; set; }
    }
}
