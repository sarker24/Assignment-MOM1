using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOMClient
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private void loanInformation(user user)
        {
            Console.WriteLine("Loan amount");
            int amount = int.Parse()(Console.ReadLine());
            JObject loan = new JObject();
            loan.add("amount", amount);
            loan.add("id", id);
            createQueue(loan.ToString());

        }

        private void createQueue(string message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);

                var message = GetMessage(args);
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "request",
                                     routingKey: "",
                                     basicProperties: null,
                                     body: body);

            }
        }
    }
}
