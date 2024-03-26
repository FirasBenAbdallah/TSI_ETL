namespace TSI_ERP_ETL.Models.ETLModel
{
    public record DocumentDetailETLModel(
        Guid Devise,
        double? Quantite,
        decimal? MontantTtc,
        DateTime? DateFilter);
}
