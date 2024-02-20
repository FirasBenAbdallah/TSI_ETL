    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace TSI_ERP_ETL.Models.GetAllPaged
    {
        public class FilterByProprety
        {
            public string? PropretyName { get; set; }

            public string? FilterValue { get; set; }

            public OperatorType? Operator { get; set; }

            public FilterByProprety(string propretyName, string filterValue, OperatorType @operator)
            {
                PropretyName = propretyName;
                FilterValue = filterValue;
                Operator = @operator;
            }
        }
    }
