namespace TSI_ERP_ETL.Models
{
    public record ApiResponse<T>(List<object>? Summaries, int? TotalCount, List<T>? Items);
}
