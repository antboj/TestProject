using System.Collections.Generic;

namespace TestProject.QueryInfoService
{
    public class QueryInfo
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public string SearchText { get; set; }
        public List<string> SearchProperties { get; set; }
        public List<Sort> Sorters { get; set; }
        public Filter Filter { get; set; }
    }
}
