using RabbitMQ.Client;
using RestaurantOrderRouting.Domain.Entities;
using System.Text;

namespace RestaurantOrderRouting.Infrastructure.ServiceBus
{
    public static class RabbitFacade 
    {
        private static IModel Channel { get; set; } 

        public static void SendMessageToQueue(Order order)
        {
            InitializeQueueConnection();
            CreateChannel("route-order");
            PublishMessageInQueue(order.PrepareOrderDetails());
        }

        public async static Task<string> GetMessageInQueue()
        {           
            return await ConsumeMessageInQueue();
        }

        #region Private methods

        private static void InitializeQueueConnection()
        {
            var factory = new ConnectionFactory { HostName = "172.30.208.1" };
            var connection = factory.CreateConnection();
            Channel = connection.CreateModel();
        }

        // TO:DO a parameter to define queue dynamic
        private static void CreateChannel(string queue)
        {
            Channel.QueueDeclare(queue: queue,
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);
        }

        private static void PublishMessageInQueue(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            Channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "route-order",
                                 basicProperties: null,
                                 body: body);
        }

        private async static Task<string> ConsumeMessageInQueue()
        {            
            var queueReturn = Channel.BasicGet("route-order", false);
            var body = queueReturn.Body.ToArray();

            await Task.CompletedTask;

            return Encoding.UTF8.GetString(body);
        }

        #endregion
    }
}
