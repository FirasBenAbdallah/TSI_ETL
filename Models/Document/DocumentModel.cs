using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSI_ERP_ETL.Models.Document
{
    public class DocumentModel
    {

        public int? VariationStock { get; set; }
        public decimal? MontantTimbre { get; set; }
        public double? TauxChange { get; set; }
        public decimal? MontantTva { get; set; }
        public Guid? Tier { get; set; }
        public decimal? MontantTaxes { get; set; }
        public decimal? MontantTtcdevise { get; set; }
        public bool? Avoir { get; set; }
        public DateTime? DateDocument { get; set; }
        public string? Objet { get; set; }
        public decimal? MontantFodec { get; set; }
        public DateTime? DateFinValidite { get; set; }
        public string? Observation { get; set; }
        public decimal? Reliquat { get; set; }
        public decimal? MontantRegle { get; set; }
        public string? NumDocument { get; set; }
        public string? Realisation { get; set; }
        public Guid? Devise { get; set; }
        public decimal? MontantHt { get; set; }
        public decimal? MontantTtc { get; set; }
        public string? NumChezTiers { get; set; }
        public Guid? Affectation { get; set; }
        public decimal? MontantHttransport { get; set; }
        public decimal? MontantTvatransport { get; set; }
        public bool? TransportSociete { get; set; }
        public bool? LivraisonPalette { get; set; }
        public bool? Consignation { get; set; }
        public double? NbrColis { get; set; }
        public double? PoidBrutColis { get; set; }
        public double? PoidNetColis { get; set; }
        public double? ValeurMatiere { get; set; }

        public bool? Dont { get; set; }
        public string? Adresse { get; set; }
        public int? Dossier { get; set; }
        public string? Declaration { get; set; }
        public DateTime? DateDeclaration { get; set; }
        public string? Bureau { get; set; }
        public string? Fournisseur { get; set; }
        public string? Pays { get; set; }
        public string? Valeur { get; set; }
        public string? Poids { get; set; }
        public string? NbColisNatMarchantise { get; set; }
        public string? ModeTransport { get; set; }
        public string? Lta { get; set; }
        public string? Ss { get; set; }
        public DateTime? DateSs { get; set; }
        public string? PonumMsr { get; set; }
        public string? TypeConvention { get; set; }
        public string? OriginePrixUnitaire { get; set; }
        public double? Volume { get; set; }
        public Guid? AdresseLivraisonUid { get; set; }
        public decimal? MontantDc { get; set; }
        public decimal? MontantTtctransport { get; set; }
        public decimal? MontantEcolef { get; set; }
        public Guid? TypeOperation { get; set; }
        public bool? Echantillon { get; set; }
        public bool? ProFormat { get; set; }
        public bool? IsExonore { get; set; }
        public Guid? Personne { get; set; }
        public decimal? MontantTtchorsTimbre { get; set; }
        public string? Colonne1 { get; set; }
        public string? Colonne2 { get; set; }
        public string? Colonne3 { get; set; }
        public string? Colonne4 { get; set; }
        public string? Colonne5 { get; set; }
        public string? NumeroFactureOrigine { get; set; }
        public string? CodeImportDocument { get; set; }
        public string? NomPrenomChauffeur { get; set; }
        public string? ImmatriculeVehicule { get; set; }
        public string? NumeroExonoration { get; set; }

        public string? Nsequence { get; set; }
        public string? Reference { get; set; }

        public DateTime? DateDebutValidite { get; set; }
        public Guid? ConventionClient { get; set; }
        public DateTime? DateDocumentTier { get; set; }
        public DateTime? DateLivraison { get; set; }
        public string? AdresseLivraison { get; set; }
        public string? PhraseDouane { get; set; }
        public string? DeviseColis { get; set; }
        public Guid? NatureDocument { get; set; }
        public Guid? AdresseFacturationUid { get; set; }
        public Guid? TypeSortie { get; set; }
        public DateTime? DateImport { get; set; }
        public DateTime? DateDebutExonoration { get; set; }
        public DateTime? DateFinExonoration { get; set; }
        public string? MontantEnToutesLettres { get; set; }
        public double? TauxRetenueGarantie { get; set; }
        public decimal? MntRetenueGarantie { get; set; }
        public decimal? MntNet { get; set; }
        public DateTime? DateValidationEngagement { get; set; }
        public decimal? MontantHtavantRemise { get; set; }
        public decimal? MontantHtremise { get; set; }
        public decimal? ReliquatRg { get; set; }
        public decimal? MontantRegleRg { get; set; }
        public bool? ImpactBudget { get; set; }
        public Guid? ModePaiementDocument { get; set; }
        public Guid? ClientLivre { get; set; }
        public decimal? MontantAvanceSurImpot { get; set; }
        public decimal? PourcAvanceSurImpotDoc { get; set; }
        public decimal? AssietteRetenueAlaSource { get; set; }
        public IEnumerable<DocumentDetailRequest> DocumentDetails { get; set; } = Enumerable.Empty<DocumentDetailRequest>();


    }
}
