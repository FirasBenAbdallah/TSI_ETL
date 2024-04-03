using TSI_ERP_ETL.Models;
using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.ETL.FactureClient
{
    public class FactureClientTransform
    {
        public static IEnumerable<FactureClientETLModel> FactureClientsTransform(IEnumerable<FactureClientModel> data) =>
            data.Select(item =>
            {
                string realisation;
                if (item.MontantRecouvrement == 0)
                {
                    realisation = "Non Payer";
                }
                else
                {
                    if (item.MontantTTC <= item.MontantRecouvrement)
                    {
                        realisation = "Payer";
                    }
                    else if (item.MontantTTC > item.MontantRecouvrement)
                    {
                        realisation = "Payer Partiellement";
                    }
                    else
                    {
                        realisation = "En Attente";
                    }
                }

                return new FactureClientETLModel(item.Id, item.NumDocument, realisation, item.MontantTTC, item.Code, item.Nom, item.Libelle, item.MontantRecouvrement);
            });
    }
}
