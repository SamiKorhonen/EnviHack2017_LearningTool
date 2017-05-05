using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iloa
{
    public class AppSettings
    {
        public string database { get; set; }
        public string collection { get; set; }

        public string endpoint { get; set; }
        public string authkey { get; set; }
    }
}
