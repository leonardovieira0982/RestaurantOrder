using Microsoft.AspNetCore.Mvc;
using RestaurantOrderRouting.Domain.Entities;
using RestaurantOrderRouting.Domain.Interfaces.Services;

namespace RestaurantOrderRouting.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublisherOrderController(ILogger<PublisherOrderController> logger, IPublisherOrderService orderService) : ControllerBase
    {
        private readonly IPublisherOrderService _orderService = orderService;
              
        private readonly ILogger<PublisherOrderController> _logger = logger;

        [HttpPost(Name = "SendAnOrder")]
        public async Task TargetARequest([FromBody] Order order)
        {
            _logger.LogInformation("Target a request to queue");
            _orderService.PublishAnOrderToQueue(order);
            _logger.LogInformation("Request to queue finished");

            await Task.CompletedTask;
        }

        [HttpPost(Name = "SendAnOrderToStacks")]
        public async Task PublishOrderToQueue([FromBody] Order order)
        {            
            _orderService.PublishAnOrderExchangeStack(order);              
            await Task.CompletedTask;
        }
    }
}
