namespace TSI_ERP_ETL.Models.ETLModel
{
    public record ArticleETLModel(
        int? Id,
        string? FamilleArticle,
        string? Libelle,
        string? Uid,
        //Guid? Article,
        DateTime? DateDocument,
        double? Quantite,
        decimal? MontantTTC,
        decimal? ChiffreAffaire,
        string? CodeClient,
        string? NomClient
        /*Guid Uid,
        string? Code,
        string? CodeClient,
        string? NomClient,
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
        bool? Achete*/);
}
