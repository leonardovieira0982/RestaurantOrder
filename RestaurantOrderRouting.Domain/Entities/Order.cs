namespace RestaurantOrderRouting.Domain.Entities
{
    public class Order
    {               
        public string Description { get; set; } = string.Empty;

        public IList<string> Items { get; set;} = new List<string>();

        public IList<Items> FoodItem { get; set;} = new List<Items>();    
       
        public string PrepareOrderDetails()
        {
            return Description + ":" + Items.Aggregate("", (current, next) => current + ":" + next);
        }     
    }
}
