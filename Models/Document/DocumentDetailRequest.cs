using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSI_ERP_ETL.Models.Document
{
    public class DocumentDetailRequest
    {
        public Guid? Article { get; set; }

        public Guid Uid { get; set; }

        public decimal? MontantTva { get; set; }

        public string? Observation { get; set; }

        public DateTime? DateLivraisonSouhaitee { get; set; }

        public Guid? Document { get; set; }

        public double? TauxTva { get; set; }

        public decimal? MontantAutreTaxe { get; set; }

        public decimal? MontantHt { get; set; }

        public double? Quantite { get; set; }

        public Guid? Couleur { get; set; }

        public Guid? DocumentDetailOrigine { get; set; }

        public int? NumLigne { get; set; }

        public decimal? PrixUnitaire { get; set; }

        public decimal? MontantFodec { get; set; }

        public Guid? Taille { get; set; }

        public double? TauxFodec { get; set; }

        public double? TauxAutreTaxe { get; set; }

        public double? TauxRemise { get; set; }

        public Guid? Affectation { get; set; }

        public decimal? CoutMoyenPondere { get; set; }

        public decimal? MontantHttransport { get; set; }

        public decimal? PrixUnitaireTransport { get; set; }

        public double? QuantiteTransport { get; set; }

        public double? TauxTvatr { get; set; }

        public double? NbrUnitePalette { get; set; }

        public string? NumTracabilite { get; set; }

        public Guid? Devise { get; set; }

        public double? TauxChange { get; set; }

        public decimal? PrixUnitaireDevise { get; set; }

        public Guid? BudgetRubrique { get; set; }

        public double? TauxDc { get; set; }

        public decimal? MontantDc { get; set; }

        public decimal? MontantTvatran { get; set; }

        public decimal? MontantEcolef { get; set; }

        public decimal? PrixUnitaireTransportAchat { get; set; }

        public decimal? MontantHttransportAchat { get; set; }

        public string? Champ01 { get; set; }

        public string? Champ02 { get; set; }

        public string? Champ03 { get; set; }

        public string? Champ04 { get; set; }

        public string? Champ05 { get; set; }

        public string? Champ06 { get; set; }

        public string? Champ07 { get; set; }

        public string? Champ08 { get; set; }

        public string? Champ09 { get; set; }

        public double? Quantite1 { get; set; }

        public double? Quantite2 { get; set; }

        public decimal? MontantTtc { get; set; }

        public decimal? MontantTimbreDetail { get; set; }

        public double? QuantiteEnlevee { get; set; }

        public string? ObservationArabe { get; set; }

        public double? ProrataDeductionTva { get; set; }

        public decimal? MontantTvacomptable { get; set; }

        public decimal? MontantHtcomptable { get; set; }

        public decimal? MontantHtavantRemise { get; set; }

        public decimal? MontantHtremise { get; set; }

        public Guid? Unite { get; set; }

        public Guid? EmplacementEntree { get; set; }

        public Guid? EmplacementSortie { get; set; }

        public decimal? PrixUnitaireMainOeuvre { get; set; }

        public decimal? PrixUnitaireMatierePremiere { get; set; }

    }
}
