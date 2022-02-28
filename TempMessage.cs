using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_Message_Tally
{
    public class TempMessage
    {
        public class Log
        {
            public string email { get; set; }
            private int privateTally { get ; set; }
            [DefaultValue(0)]
            public int total { get { return privateTally; } set { privateTally = value; } }
        }

        public class Root
        {
            public List<Log> logs { get; set; }
            public string id { get; set; }
        }

    }
}
