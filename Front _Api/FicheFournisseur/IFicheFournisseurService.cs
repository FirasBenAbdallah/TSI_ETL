using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.Front_Api.FicheFournisseur
{
    public interface IFicheFournisseurService
    {
        Task<IEnumerable<FicheFournisseurETLModel>> GetFicheFournisseursAsync();
    }
}