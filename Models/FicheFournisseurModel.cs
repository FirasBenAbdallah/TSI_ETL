using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSI_ERP_ETL.Models
{
    public record FicheFournisseurModel(string? Code, string? Nom, decimal? Debit, decimal? Credit);
}