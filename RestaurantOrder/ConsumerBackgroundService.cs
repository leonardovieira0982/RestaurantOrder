
using RestaurantOrderRouting.Domain.Interfaces.Services;

namespace RestaurantOrderRouting.Api
{
    // I did this class to work as a background service consumer, but I dont used it
    public sealed class ConsumerBackgroundService(IConsumerOrderService consumer) : IHostedService
    {
        private readonly Timer _timer;

        private readonly IConsumerOrderService _consumer = consumer;              

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //_timer = new Timer(ConsumerHostedService, null, TimeSpan.Zero, TimeSpan.FromSeconds(60));           
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {         
            return Task.CompletedTask;
        }

        private void ConsumerHostedService(object? state)
        {
            _consumer.ConsumerAnOrderInQueue();
        }
    }
}
