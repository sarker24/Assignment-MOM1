using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client.Events;
using System.Threading.Tasks;

namespace MOMBank
{
    class Program
    {
      

      public static void Main(string[] args)
        {
            new Program().RunProgram();
          
        }
        private void RunProgram()
        {
            var bankID = Guid.NewGuid();
            createQueue();
        }
        private void createQueue()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);

                var message = GetMessage(args);
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "logs",
                                     routingKey: "",
                                     basicProperties: null,
                                     body: body);

            }
        }

            private void createoffer(string body)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);

                var message = GetMessage(args);
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "offer",
                                     routingKey:Id,
                                     basicProperties: null,
                                     body: body);

            }

            
        }

      

    }

   
}

