namespace TSI_ERP_ETL.Models.GetAllPaged
{
    public record GetAllPagedRequest(List<SortingByProperty>? Sorting, string? Keyword, List<FilterByProprety>? Filters, bool? GetAllData, List<string>? Summaries, string? TypeTier, int TypeTierEnum)
    {
        public int? MaxResultCount { get; set; } = 10;
        public int? SkipCount { get; set; } = 0;
        public List<SortingByProperty>? Sorting { get; internal set; } = Sorting;
        public string? TypeTier { get; internal set; } = TypeTier;
        public int TypeTierEnum { get; internal set; } = TypeTierEnum;

        public GetAllPagedRequest() : this(null, null, null, null, null, null, default)
        {
            if (Filters == null)
            {
                _ = Filters = new List<FilterByProprety>();
            }

            if (Summaries == null)
            {
                _ = Summaries = new List<string>();
            }
        }
    }
}
