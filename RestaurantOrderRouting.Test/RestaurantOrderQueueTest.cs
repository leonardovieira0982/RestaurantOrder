using RestaurantOrderRouting.Domain.Entities;
using RestaurantOrderRouting.Infrastructure.ServiceBus;
using System.Collections.Generic;

namespace RestaurantOrderRouting.Test
{
    public class RestaurantOrderQueueTest
    {
        [Fact]
        public void PublishAnOrderToQueueDevTest()
        {
            ProducerOrderQueue producer = new();
            producer.PublishAnOrderToQueue(
                _ = new Order()
                {
                    Description = "Publisher Message Queue",
                    Items = 
                    { 
                        "Big Mac", 
                        "Coke", 
                        "Fresh Fries" 
                    }                  
                }    
            );
        }

        [Fact]
        public void ConsumerAnOrderInQueueDevTest()
        {
           ConsumerOrderQueue consumer = new();
           var result = consumer.ConsumerAnOrderInQueue();

           Assert.NotNull(result);
        }

        [Fact]
        public void PrepareOrderDetailsDevTest()
        {
            Order order = new()
            {
                Description = "Description Head Message",
                Items =
                {
                    "Mc Fish",
                    "Sprite",
                    "Nuggets",
                    "Fresh Fries"
                }
            };

            var result = order.PrepareOrderDetails();

            Assert.NotNull(result);
        }

        [Fact]
        public void ProducerDirectExchangeDevtest()
        {

            Order order = new Order();
            order.Description = "McLunch";
            order.FoodItem.Add(new Items() { Exchange = "order-direct-exchange", Queue = "meat-queue", RouteKey = "routing-key-1", Item = "Big Mac" });
            order.FoodItem.Add(new Items() { Exchange = "order-direct-exchange", Queue = "meat-queue", RouteKey = "routing-key-1", Item = "Double Cheedar" });
            order.FoodItem.Add(new Items() { Exchange = "order-direct-exchange", Queue = "drink-queue", RouteKey = "routing-key-2", Item = "Coke" });
            order.FoodItem.Add(new Items() { Exchange = "order-direct-exchange", Queue = "drink-queue", RouteKey = "routing-key-2", Item = "Sprite" });
            order.FoodItem.Add(new Items() { Exchange = "order-direct-exchange", Queue = "fries-queue", RouteKey = "routing-key-3", Item = "Apple Tie" });

            RabbitExchangeFacade.PublishExchangeMessage(order);
        }
    }
}