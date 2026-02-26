namespace RestaurantUI.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? CuisineType { get; set; }
        public int Rating { get; set; }
        public string? Review { get; set; }
    }
}
