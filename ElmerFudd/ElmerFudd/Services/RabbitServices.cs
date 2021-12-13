using ElmerFudd.Messages;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmerFudd.Services {
    public class RabbitServices : IRabbitServices {

        private readonly IDemoMessageBusControl _demoMessageBusControl;
        public RabbitServices(IDemoMessageBusControl demoMessageBusControl) {
            _demoMessageBusControl = demoMessageBusControl;
        }

        //These two methods use MassTransit to publish the message created
        public void CreateDemoMessage1(string title) {
            IDemoMessage1 demoMessage = new DemoMessage1() {
                Title = title,
                TimeStamp = DateTime.Now
            };
            _demoMessageBusControl.Publish(demoMessage);
        }

        public void CreateDemoMessage2(string title, string comment) {
            IDemoMessage2 demoMessage = new DemoMessage2() {
                Title = title,
                TimeStamp = DateTime.Now,
                Comment = comment
            };
            _demoMessageBusControl.Publish(demoMessage);
        }

        //This method uses RabbitMQ to get one message from the queue IDemoMessage_ElmerFudd
        public string GetDemoMessage(bool acknowledge) {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };

            using (var connection = factory.CreateConnection()) {
                using (var channel = connection.CreateModel()) {
                    var resp = channel.BasicGet("IDemoMessage_ElmerFudd", acknowledge);
                    var body = resp.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    return message;
                }
            }
        }

        public void PublishMessage(string message) {

        }
    }
}
