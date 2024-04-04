using TSI_ERP_ETL.Models;
using TSI_ERP_ETL.Models.ETLModel;

namespace TSI_ERP_ETL.ETL.Article
{
    public class ArticleTransform
    {
        public static IEnumerable<ArticleETLModel> ArticlesTransform(IEnumerable<ArticleModel> data)
        {
            return data.Select(item =>
            {
                decimal? ChiffreAffaire;
                // Check if both values are not null
                if (item.MontantTTC.HasValue && item.Quantite.HasValue)
                {
                    // Convert double? to decimal for the multiplication.
                    // Note: This conversion can throw an OverflowException if the value is outside the range of a decimal.
                    decimal quantiteAsDecimal = (decimal)item.Quantite.Value;

                    // Perform the multiplication.
                    ChiffreAffaire = item.MontantTTC.Value * quantiteAsDecimal;
                }
                else
                {
                    ChiffreAffaire = 0;
                }

                // Return a new ArticleETLModel for each item, including the calculated ChiffreAffaire
                return new ArticleETLModel(
                    item.Id,
                    item.FamilleArticle,
                    item.Libelle,
                    item.Uid,
                    item.DateDocument,
                    item.Quantite,
                    item.MontantTTC,
                    ChiffreAffaire,
                    null, // Assuming these are placeholders for properties not shown in your example
                    null
                );
            });
        }

        /*public static IEnumerable<ArticleETLModel> ArticlesTransform(IEnumerable<ArticleModel> data)
        {
            decimal? ChiffreAffaire = 0;
            foreach (var item in data)
            {
                // Check if both values are not null
                if (item.MontantTTC.HasValue && item.Quantite.HasValue)
                {
                    decimal quantiteAsDecimal = (decimal)item.Quantite.Value;

                    // Perform the multiplication.
                    ChiffreAffaire = item.MontantTTC.Value * quantiteAsDecimal;
                }
                else { ChiffreAffaire = 0; }
            }
            return data.Select(item => new ArticleETLModel(item.Id, item.FamilleArticle, item.Libelle, item.Uid, item.DateDocument, item.Quantite, item.MontantTTC, ChiffreAffaire, null, null));
        }*/
    }
}
