using Microsoft.AspNetCore.Mvc;
using RestaurantOrderRouting.Domain.Interfaces.Services;

namespace RestaurantOrderRouting.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsumerOrderController(IConsumerOrderService consumer) : ControllerBase
    {
        private readonly IConsumerOrderService _consumer = consumer;

        [HttpGet(Name = "GetOrderItems")]
        public async Task<string> ConsumeOrderItems()  
        {
            return await _consumer.ConsumerAnOrderInQueue();            
        }
    }
}
