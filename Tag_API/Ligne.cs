﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag_API
{
    public class Ligne
    {
        public string id { get; set; }
        public string gtfsId { get; set; }
        public string shortname { get; set; }
        public string longName { get; set; }
        public string color { get; set; }
        public string textColor { get; set; }
        public string mode { get; set; }
        public string type { get; set; }
    }
}
