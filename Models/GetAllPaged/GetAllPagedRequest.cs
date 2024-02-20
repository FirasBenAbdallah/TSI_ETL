    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace TSI_ERP_ETL.Models.GetAllPaged
    {
        public class GetAllPagedRequest
        {
            public int? MaxResultCount { get; set; } = 10;
            public int? SkipCount { get; set; } = 0;
            public List<SortingByProperty>? Sorting { get; internal set; }
            public virtual string? Keyword { get; set; }

            public virtual List<FilterByProprety>? Filters { get; set; }

            public bool? GetAllData { get; set; }

            public virtual List<string>? Summaries { get; set; }
            public string? TypeTier { get; internal set; }
            public int TypeTierEnum { get; internal set; }

            public GetAllPagedRequest()
            {
                if (Filters == null)
                {
                    List<FilterByProprety> list2 = (Filters = new List<FilterByProprety>());
                }

                if (Summaries == null)
                {
                    List<string> list4 = (Summaries = new List<string>());
                }
            }
        }
    }
