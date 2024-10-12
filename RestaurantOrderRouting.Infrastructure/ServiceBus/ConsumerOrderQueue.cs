using RestaurantOrderRouting.Domain.Interfaces.Services;

namespace RestaurantOrderRouting.Infrastructure.ServiceBus
{
    public class ConsumerOrderQueue : IConsumerOrderService
    {      
        public async Task<string> ConsumerAnOrderInQueue()
        {
            return await RabbitFacade.GetMessageInQueue();
        }
    }
}