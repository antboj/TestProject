using System.Collections.Generic;

namespace TestProject.QueryInfoService
{
    public class Rule
    {
        public string Property { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }
        public string Condition { get; set; }
        public List<Rule> Rules { get; set; }
    }
}
