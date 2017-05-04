using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iloa
{
    public class AppSettings
    {
        public string Database { get; set; }
        public string Collection { get; set; }

        public string EndPoint { get; set; }
        public string AuthKey { get; set; }
    }
}
