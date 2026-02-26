using RestaurantUI.Models;

namespace RestaurantUI.Services
{
    public class FakeRestaurantService
    {
        public List<Restaurant> Restaurants = new List<Restaurant>
        {
            new Restaurant { Id = 1, Name = "Himalayan Grill", Location = "Kathmandu", CuisineType = "Nepali", Rating = 5, Review = "Excellent food" },
            new Restaurant { Id = 2, Name = "Pizza World", Location = "Pokhara", CuisineType = "Italian", Rating = 4, Review = "Very good pizza" }
        };
    }
}
