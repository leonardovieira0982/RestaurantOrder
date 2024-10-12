using RestaurantOrderRouting.Domain.Entities;

namespace RestaurantOrderRouting.Domain.Interfaces.Services
{
    public interface IPublisherOrderService : IOrderService
    {
        void PublishAnOrderToQueue(Order order);

        void PublishAnOrderExchangeStack(Order order);
    }
}