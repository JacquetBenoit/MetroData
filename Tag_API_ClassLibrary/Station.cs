using System;
using System.Collections.Generic;

namespace Tag_API_ClassLibrary
{
    public class Station
    {
        public String id { get; set; }
        public String name { get; set; }
        public double lon { get; set; }
        public double lat { get; set; }
        public String zone { get; set; }
        public IList<string> lines { get; set; }
    }
}
