namespace TSI_ERP_ETL.Models
{
    public record FactureClientModel(
        int? Id,
        string? NumDocument,
        string? Realisation,
        decimal? MontantTTC,
        string? Code,
        string? Nom,
        string? Libelle);
}
