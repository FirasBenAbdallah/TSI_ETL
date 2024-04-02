using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSI_ERP_ETL.Models.ETLModel
{
    public record FicheFournisseurETLModel(int? Id,string? Code, string? Nom, decimal? Debit, decimal? Credit, decimal? Solde);
}
