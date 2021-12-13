using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElmerFudd.Messages {
    public class DemoMessage1 : IDemoMessage1 {
        public string Title { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}