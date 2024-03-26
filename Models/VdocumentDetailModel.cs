namespace TSI_ERP_ETL.Models
{
    public record VdocumentDetailModel(
        string? CodeArticle,
        string? LibelleArticle,
        string? ObservationDocument,
        DateTime? DateDocument,
        string? TypeDocument,
        string? CodeAffectation,
        string? LibelleAffectation,
        Guid? UIDAffectation,
        Guid? UIDArticle,
        DateTime? DateLivraisonSouhaitee,
        decimal? PrixUnitaire,
        double? Quantite,
        float? TauxRemise,
        decimal? MontantHt,
        float? TauxFodec,
        decimal? MontantFodec,
        float? TauxTva,
        string? LibelleAffectationFR,
        Guid Uid);
}