using RestaurantOrderRouting.Domain.Entities;
using RestaurantOrderRouting.Domain.Interfaces.Services;


namespace RestaurantOrderRouting.Domain.Services
{
    public class PublisherService(IPublisherOrderService order) 
    {
        private readonly IPublisherOrderService _order = order;

        // Publish a message in a queue
        public void PublishAnOrder(Order order)
        {
            _order.PublishAnOrderToQueue(order);
        }       

        // Publish a message in an exchange that send to queues
        public void PublishAnOrderExchangeStack(Order order) 
        {
            _order.PublishAnOrderExchangeStack(order);
        }
    }
}
