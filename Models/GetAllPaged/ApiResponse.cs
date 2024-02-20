namespace TSI_ERP_ETL.Models
{
    public class ApiResponse
    {
        public List<object>? Summaries { get; set; }
        public int? TotalCount { get; set; }
        public List<TierModel>? Items { get; set; }
    }
}
