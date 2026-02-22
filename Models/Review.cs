namespace RestaurantUI.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Reviewer { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; }
        public int RestaurantId { get; set; }
    }
}