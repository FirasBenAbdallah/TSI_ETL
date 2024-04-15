using Microsoft.AspNetCore.Mvc;

namespace TSI_ERP_ETL.Models.Requests
{
    public record ChiffreAffaireRequest(
        string? StartDate,
        string? EndDate,
        int PageNumber,
        int PageSize);
}
