using ElmerFudd.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElmerFudd.Services {
    public interface IRabbitServices {
        string GetDemoMessage(bool acknowledge);
        void CreateDemoMessage1(string title);
        void CreateDemoMessage2(string title, string comment);
        void PublishMessage(string message);
    }
}
