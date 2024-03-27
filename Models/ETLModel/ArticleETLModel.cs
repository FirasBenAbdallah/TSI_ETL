namespace TSI_ERP_ETL.Models.ETLModel
{
    public record ArticleETLModel(
        Guid Uid,
        string? Code,
        string? CodeClient,
        string? CodeAbarres,
        string? Libelle,
        decimal? PrixUnitaireAchat,
        double? TauxTva,
        double? PrixUnitaireVente,
        decimal? PrixVenteTtc,
        Guid? FamilleArticle,
        string? CodeFournisseur,
        bool? Active,
        bool? Vendu,
        bool? Achete);
}
