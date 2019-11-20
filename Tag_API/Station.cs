using System;
using System.Collections.Generic;

namespace Tag_API
{
    public class Station
    {
        public String id { get; set; }
        public String name { get; set; }
        public float lon { get; set; }
        public float lat { get; set; }
        public String zone { get; set; }
        public IList<string> lines { get; set; }
    }
}
