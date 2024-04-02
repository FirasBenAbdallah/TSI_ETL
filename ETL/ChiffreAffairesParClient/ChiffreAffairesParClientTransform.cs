using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSI_ERP_ETL.Models;

namespace TSI_ERP_ETL.ETL.ChiffreAffairesParClient
{
    public class ChiffreAffairesParClientTransform
    {
        public static IEnumerable<ChiffreAffairesParClientModel> TransformChiffreAffairesParClient(IEnumerable<ChiffreAffairesParClientModel> data)
        {
            /*decimal? sumMontantTtc = 0;
            sumMontantTtc = data.Sum(item => item.MontantTtc);
            decimal? sumMontanstTtc = 0;
            Console.WriteLine($"The sum of NombreDevises is: {sumMontanstTtc}");*/
            return data;
        }
    }
}
