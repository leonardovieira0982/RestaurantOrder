using RestaurantOrderRouting.Domain.Entities;
using RestaurantOrderRouting.Domain.Interfaces.Services;
using System.Reflection.Metadata.Ecma335;

namespace RestaurantOrderRouting.Infrastructure.ServiceBus
{
    public class ProducerOrderQueue : IPublisherOrderService
    {        
        public void PublishAnOrderToQueue(Order order)
        {
            RabbitFacade.SendMessageToQueue(order);                                  
        }

        public void PublishAnOrderExchangeStack(Order order)
        {
            RabbitExchangeFacade.PublishExchangeMessage(order);
        }
    }
}