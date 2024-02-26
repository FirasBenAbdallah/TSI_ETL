namespace TSI_ERP_ETL.Models
{
    public class ApiResponse<T>
    {
        public List<object>? Summaries { get; set; }
        public int? TotalCount { get; set; }
        public List<T>? Items { get; set; }
    }
}
