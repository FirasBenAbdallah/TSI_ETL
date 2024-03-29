﻿namespace TSI_ERP_ETL.Models
{
    public record ArticleModel(
        Guid? UniteTemp,
        double? Poid,
        double? PoidNet,
        double? PrixUnitaireVente,
        Guid? NomenclatureCommerciale,
        string? Observations,
        double? TauxRemiseAchat,
        double? Hauteur,
        Guid? FamilleTaille,
        double? StockMaximum,
        double? Longueur,
        double? QuantiteMultipleFournisseur,
        string? Code,
        Guid? Unite,
        string? Presentation,
        double? TauxTva,
        int? DelaiFournisseur,
        Guid? Nomenclature,
        double? Diametre,
        Guid? CompteComptableAchat,
        double? StockMinimum,
        double? QuantiteMinimaleFournisseur,
        decimal? PrixUnitaireAchat,
        Guid? CompteComptableVente,
        double? DelaiObtention,
        string? TypeArticle,
        string? CodeFournisseur,
        Guid? Gamme,
        double? TauxRemiseVente,
        Guid? FamilleArticle,
        Guid? UnitePoids,
        string? Statut,
        string? Libelle,
        Guid? NomenclatureEtude,
        double? TauxFodec,
        Guid? UniteDimension,
        Guid Uid,
        double? Largeur,
        Guid? NomenclatureFabrication,
        Guid? Collection,
        Guid? Emballage,
        Guid? MarqueArticle,
        Guid? Categorie,
        int? Garantie,
        bool? SurPalette,
        double? UniteParPalette,
        double? PieceParEtage,
        double? PieceParM2,
        double? EtageParPalette,
        decimal? PrixUnitaireTransport,
        string? Usage,
        bool? Vendu,
        bool? Achete,
        byte[]? Photos,
        Guid? Atelier,
        Guid? Pays,
        bool? Active,
        decimal? Cout,
        string? CompteComptableAchatSage,
        string? CompteComptableVenteSage,
        Guid? BudgetRubrique,
        double? Volume,
        Guid? UniteVolume,
        Guid? Carburant,
        bool? BCarburant,
        string? CodeAbarres,
        double? Marge,
        decimal? PrixAchatHt,
        decimal? PrixVenteTtc,
        Guid? Modele,
        Guid? DeviseAchat,
        Guid? DeviseVente,
        double? TauxDc,
        decimal? MontantDc,
        double? TauxTvatran,
        decimal? MontantTvatran,
        decimal? PrixAchatTtc,
        decimal? MontantEcolef,
        decimal? PrixUnitaireTransportAchat,
        bool? GestionParLot,
        string? LibelleCommercial,
        double? TauxFodecVente,
        Guid? Client,
        Guid? SousFamilleArticles,
        double? PlafondRemise,
        string? TypePu,
        double? NombreUnitee,
        string? CodeImport,
        string? Colisage,
        Guid? FamilleImmobilisation,
        Guid? UniteAchat,
        Guid? UniteVente,
        string? CodeClient);
}
