namespace TSI_ERP_ETL.Models
{
    public record DeviseModel
    {
        public int NombreDecimales { get; set; }
        public string? Uid { get; set; }
        public string? CodeDevise { get; set; }
        public double NumeroDevise { get; set; }
        public string? LibelleDevise { get; set; }
        public int? NombreDevises { get; set; }
        public string? CompteBancaireDefaut { get; set; }
    }
}
