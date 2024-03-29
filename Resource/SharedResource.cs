namespace TSI_ERP_ETL.Resource
{
    public static class SharedResource
    {
        public static List<decimal> MontantTtcList { get; set; } = new List<decimal>();
        public static List<string> CodeClientList { get; set; } = new List<string>();
        public static List<string> NomClientList { get; set; } = new List<string>();
    }
}