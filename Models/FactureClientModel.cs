namespace TSI_ERP_ETL.Models
{
    public record FactureClientModel(
        int? Id,
        string? NumDocument,
        decimal? MontantTTC,
        string? Code,
        string? Nom,
        string? Libelle,
        decimal? MontantRecouvrement);
}
