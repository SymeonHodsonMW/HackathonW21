using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElmerFudd.Messages {
    public interface IDemoMessage1 {
        string Title { get; set; }
        DateTime TimeStamp { get; set; }
    }
}
