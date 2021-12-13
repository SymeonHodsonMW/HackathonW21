using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElmerFudd.Messages {
    public class DemoMessage2 : IDemoMessage2 {
        public string Title { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Comment { get; set; }

    }
}
