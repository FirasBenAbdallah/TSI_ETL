namespace TSI_ERP_ETL.Models.ETLModel
{
    public record FactureClientETLModel(
        string? NumDocument,
        string? Realisation,
        decimal? MontantTTC,
        string? Code,
        string? Nom,
        string? Libelle);
}
