namespace TSI_ERP_ETL.Models
{
    public class TierModel
    {
        public DateTime? DateCin { get; set; }
        public string? LieuCin { get; set; }
        public string? NomPersonnePhysique { get; set; }
        public string? ReferenceExonerationFodec { get; set; }
        public DateTime? DateDebutExonerationFodec { get; set; }
        public string? Email { get; set; }
        public Guid? Devise { get; set; }
        public string? LieuPasseport { get; set; }
        public Guid TypeTier { get; set; }
        public string? Pays { get; set; }
        public bool? AppliquerTimbre { get; set; }
        public string? Code { get; set; }
        public string? NomAgence { get; set; }
        public string? Ville { get; set; }
        public Guid? Region { get; set; }
        public string? NomBanque { get; set; }
        public string? AutreInfo { get; set; }
        public DateTime? DateFinExonerationTimbre { get; set; }
        public DateTime? DateFinExonerationTva { get; set; }
        public Guid? TypeOperationParDefaut { get; set; }
        public decimal? CreditMax { get; set; }
        public string? CodePatente { get; set; }
        public Guid? Contacts { get; set; }
        public string? RegistreCommerce { get; set; }
        public string? NumeroCin { get; set; }
        public DateTime? DateDebutExonerationTva { get; set; }
        public string? TelephoneDomicilePraticien { get; set; }
        public string? Rib { get; set; }
        public string? ReferenceExonerationTimbre { get; set; }
        public bool? AppliquerFodec { get; set; }
        public string? NumPasseport { get; set; }
        public string? Compte { get; set; }
        public DateTime? DateDebutExonerationTimbre { get; set; }
        public bool? TiersDouteux { get; set; }
        public Guid Uid { get; set; }
        public string? Observations { get; set; }
        public string? SpecialitePraticien { get; set; }
        public string? Telephone { get; set; }
        public string? PrenomPersonnePhysique { get; set; }
        public string? Nom { get; set; }
        public string? ReferenceExonerationTva { get; set; }
        public string? Telecopie { get; set; }
        public string? PraticienClinique { get; set; }
        public string? RaisonSociale { get; set; }
        public string? Adresse { get; set; }
        public double? TauxRemise { get; set; }
        public bool? AccepterAssuranceVoiture { get; set; }
        public DateTime? DateObtentionPermis { get; set; }
        public string? AdresseDomicilePraticien { get; set; }
        public Guid? ModaliteReglement { get; set; }
        public string? NumeroPermis { get; set; }
        public string? AdresseLocale { get; set; }
        public DateTime? DateNaissance { get; set; }
        public string? SiteWeb { get; set; }
        public string? MatriculeFiscal { get; set; }
        public string? LieuObtentionPermis { get; set; }
        public DateTime? DatePasseport { get; set; }
        public bool? AccepterAssuranceAccompagnant { get; set; }
        public string? AdressePermanente { get; set; }
        public string? AdresseLivraison { get; set; }
        public DateTime? DateFinExonerationFodec { get; set; }
        public string? CodePostal { get; set; }
        public double? RetenueImpots { get; set; }
        public int? Nombre { get; set; }
        public string? Contact { get; set; }
        public DateTime? EcheancePaiement { get; set; }
        public string? Activite { get; set; }
        public byte[]? Sigle { get; set; }
        public int? Delai { get; set; }
        public string? TypeIdentifiant { get; set; }
        public double? TauxTva { get; set; }
        public double? TauxFodec { get; set; }
        public double? TauxDc { get; set; }
        public Guid? Agence { get; set; }
        public Guid? ModePaiement { get; set; }
        public Guid? ModeReglement { get; set; }
        public string? Tel { get; set; }
        public double? Retenue { get; set; }
        public string? Fax { get; set; }
        public bool? Exonore { get; set; }
        public string? CleMatriculeFiscal { get; set; }
        public string? CategorieContribuable { get; set; }
        public int? NumeroEtablissement { get; set; }
        public string? CodeTva { get; set; }
        public string? Notes { get; set; }
        public bool? IsEtranger { get; set; }
        public Guid? CompteComptable { get; set; }
        public string? LibelleCompteComptable { get; set; }
        public bool? ChequeGarantie { get; set; }
        public bool? LimiteCredit { get; set; }
        public bool? TiersAuComptant { get; set; }
        public bool? PrendreConsChequePort { get; set; }
        public bool? PrendreConsTraitPort { get; set; }
        public decimal? MntCheGar { get; set; }
        public decimal? MntLimiteCredit { get; set; }
        public Guid? BanqueCheGar { get; set; }
        public string? NumCheGar { get; set; }
        public bool? ChequeBlanc { get; set; }
        public Guid? Banque { get; set; }
        public Guid? CategorieTiers { get; set; }
        public bool? PrendreConsTraitEsc { get; set; }
        public string? CodeImport { get; set; }
        public bool? FinMois { get; set; }
        public DateTime? DateChangementIdentifiant { get; set; }
        public decimal? PourcAvanceSurImpot { get; set; }

        /*public IEnumerable<TierExonorationResponse> TierExonorations { get; set; } = Enumerable.Empty<TierExonorationResponse>();
        public IEnumerable<ContactsResponse> ContactsNavigations { get; set; } = Enumerable.Empty<ContactsResponse>();
        public IEnumerable<ContratMaintenanceResponse> ContratMaintenances { get; set; } = Enumerable.Empty<ContratMaintenanceResponse>();
        public IEnumerable<TierExonorationFodecResponse> TierExonorationFodecs { get; set; } = Enumerable.Empty<TierExonorationFodecResponse>();
        public IEnumerable<AdressesResponse> Adressess { get; set; } = Enumerable.Empty<AdressesResponse>();
        public IEnumerable<InterventionResponse> Interventions { get; set; } = Enumerable.Empty<InterventionResponse>();
        public IEnumerable<ProjetResponse> Projets { get; set; } = Enumerable.Empty<ProjetResponse>();
        public IEnumerable<TimeSheetResponse> TimeSheets { get; set; } = Enumerable.Empty<TimeSheetResponse>();
        public IEnumerable<DetailMatriculeFiscalResponse> DetailMatriculeFiscals { get; set; } = Enumerable.Empty<DetailMatriculeFiscalResponse>();*/

    }
}
