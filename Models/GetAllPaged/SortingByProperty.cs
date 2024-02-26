using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSI_ERP_ETL.Models.GetAllPaged
{
    public class SortingByProperty
    {
        public string? PropertyName { get; set; }
        public string? Order { get; set; }

        public SortingByProperty(string propertyName, string order)
        {
            PropertyName = propertyName;
            Order = order;
        }
    }
}
