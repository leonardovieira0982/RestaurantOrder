namespace RestaurantOrderRouting.Domain.Interfaces.Services
{
    public interface IConsumerOrderService : IOrderService
    {
        Task<string> ConsumerAnOrderInQueue();
    }
}
