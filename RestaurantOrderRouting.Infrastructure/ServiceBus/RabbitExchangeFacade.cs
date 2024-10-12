using Newtonsoft.Json;
using RabbitMQ.Client;
using RestaurantOrderRouting.Domain.Entities;
using System.Text;
using System.Threading.Channels;

namespace RestaurantOrderRouting.Infrastructure.ServiceBus
{
    public class RabbitExchangeFacade
    {
        private static IModel channel { get; set; }

        public static void PublishExchangeMessage(Order order)
        {
            RabbitExchangeFacade.OpenRabbitConnection(order);           
        }

        private static void OpenRabbitConnection(Order order)
        {
            var factory = new ConnectionFactory { HostName = "172.30.208.1" };
            using var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.ExchangeDeclare("order-direct-exchange", ExchangeType.Direct, durable: true, autoDelete: false);
            foreach (var item in order.FoodItem)
            {
                channel.QueueDeclare(item.Queue, durable: true, exclusive: false, autoDelete: false);
                channel.QueueBind(item.Queue, item.Exchange, item.RouteKey);

                var messageBody = Encoding.UTF8.GetBytes(item.Item);
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                channel.BasicPublish(item.Exchange, item.RouteKey, basicProperties: properties, body: messageBody);
            }

        }       
    }
}
