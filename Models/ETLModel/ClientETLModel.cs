namespace TSI_ERP_ETL.Models.ETLModel
{
    public record ClientETLModel (
        Guid Uid,
        string? Code,
        string? CodeClient,
        string? Libelle);
}
