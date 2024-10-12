namespace RestaurantOrderRouting.Domain.Entities
{
    public class Items
    {
        public string Exchange { get; set; } = string.Empty;
        
        public string Queue { get; set; } = string.Empty;

        public string Item { get; set; } = string.Empty;

        public string RouteKey { get; set; } = string.Empty;
    }
}
