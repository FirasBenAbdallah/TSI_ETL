namespace TSI_ERP_ETL.Resource
{
    public static class SharedResource
    {
        public static List<decimal> MontantTtcList { get; set; } = new List<decimal>();
        public static List<string> CodeClientList { get; set; } = new List<string>();
        public static List<string> NomClientList { get; set; } = new List<string>();
        public static List<decimal> SoldeFicheFournisseur { get; set; } = new List<decimal>();
        public static List<string> CodeFicheFournisseur { get; set; } = new List<string>();
        public static List<string> NomFicheFournisseur { get; set; } = new List<string>();
        public static List<decimal> debitFicheFournisseur { get; set; } = new List<decimal>();
        public static List<decimal> creditFicheFournisseur { get; set; } = new List<decimal>();

    }
}