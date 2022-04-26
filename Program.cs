using Jp.Models;
using RabbitMQ.Client;
using System;
using System.Text;

namespace JPS
{
    public class Program
    {
        static void Main(string[] args)
        {
            SaleItem.CreateSaleItems();


            for (int i = 0; i < SaleItem.SaleItems.Count; i++)
            {
                SendMessage(SaleItem.SaleItems[i]);
            }

        }



        public static void SendMessage(SaleItem sim)
        {


            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "qSalesItems",
                                     durable: false, exclusive: false,
                                     autoDelete: false, arguments: null);



                var body = Encoding.UTF8.GetBytes(sim.ToXml());

                channel.BasicPublish(exchange: "",
                                     routingKey: "qSalesItems",
                                     basicProperties: null,
                                     body: body);

                Console.WriteLine(" [x] Sent " + sim.ProductType);
            }


        }


    }
}
