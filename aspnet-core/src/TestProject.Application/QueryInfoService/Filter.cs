using System.Collections.Generic;

namespace TestProject.QueryInfoService
{
    public class Filter
    {
        public string Condition { get; set; }
        public List<Rule> Rules { get; set; }
    }
}