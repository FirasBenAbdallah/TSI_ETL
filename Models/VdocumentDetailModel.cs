namespace TSI_ERP_ETL.Models
{
    public struct VdocumentDetailModel
    {
        public string? CodeArticle { get; set; }//TODO Take it
        public string? LibelleArticle { get; set; }//TODO Take it
        public DateTime? DateDocument { get; set; }//TODO Take it
        public decimal? PrixUnitaire { get; set; }//TODO Take it
        public double? Quantite { get; set; }//TODO Take it
        public decimal? MontantHt { get; set; }//TODO Take it
        public Guid? Uidaffectation { get; set; }//TODO Take it
        public Guid? Uidarticle { get; set; }//TODO Take it
        public Guid Uid { get; set; }//TODO Take it
    }
}

/*X
 * 
Not used
public string? ObservationDocument { get; protected set; }
public string? TypeDocument { get; protected set; }
public string? CodeAffectation { get; protected set; }
public string? LibelleAffectation { get; protected set; }
public DateTime? DateLivraisonSouhaitee { get; protected set; }
public double? TauxRemise { get; protected set; }
public double? TauxFodec { get; protected set; }
public decimal? MontantFodec { get; protected set; }
public double? TauxTva { get; protected set; }
public decimal? MontantTva { get; protected set; }
public Guid? Uidtier { get; protected set; }
public decimal? MontantTaxes { get; protected set; }
public string? LibelleFamille { get; protected set; }
public string? LibelleAffectationAr { get; protected set; }
public string? LibelleAffectationFr { get; protected set; }
public string? LibelleUnite { get; protected set; }
public string? CodeUnite { get; protected set; }
public string? NumOrigine { get; protected set; }
public double? MontantRemise { get; protected set; }
public string? ObservationArticle { get; protected set; }
public string? ArticleLibelleObvservation { get; protected set; }
public int? NumLigne { get; protected set; }
public string? NumDocument { get; protected set; }
public DateTime? DateDocumentOrigine { get; protected set; }
public string? Colonne1 { get; protected set; }
public string? Colonne2 { get; protected set; }
public string? Colonne3 { get; protected set; }
public string? Colonne4 { get; protected set; }
public string? Colonne5 { get; protected set; }
public string? ImmatriculeVehicule { get; protected set; }
public string? NomPrenomChauffeur { get; protected set; }
public string? NumeroExonoration { get; protected set; }
public DateTime? DateDebutExonoration { get; protected set; }
public DateTime? DateFinExonoration { get; protected set; }
public decimal? PrixVenteTtc { get; protected set; }
public string? CodeFournisseur { get; protected set; }
public double? PrixUnitaireVente { get; protected set; }
public string? CodeEmplacementSortie { get; protected set; }
public string? LibelleEmplacementSortie { get; protected set; }
public string? CodeEmplacementEntree { get; protected set; }
public string? LibelleEnplacementEntree { get; protected set; }
public string? Ngparticle { get; protected set; }
public decimal? PrixUnitaireMainOeuvre { get; protected set; }
public decimal? PrixUnitaireMatierePremiere { get; protected set; }
public string? CodeAbarres { get; protected set; }
public string? LibelleCommercial { get; protected set; }
*/