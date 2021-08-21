using System.Collections.Generic;

namespace EnumToStringOptimizer.Models
{
    public class EnumModel
    {
        public string EnumName { get; set; }
        public List<string> EnumMembers { get; set; }
        public string Namespace { get; set; }
    }
}
