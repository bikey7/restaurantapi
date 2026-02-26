using RestaurantUI.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantUI.Services
{
    public class FakeRestaurantService
    {
        private List<Restaurant> _restaurants = new List<Restaurant>()
        {
            new Restaurant
            {
                Id = 1,
                Name = "Himalayan Cafe",
                Location = "Kathmandu",
                CuisineType = "Nepali",
                Rating = 5,
                Review = new List<Review>
                {
                    new Review { Id = 1, Reviewer = "Sita", Comment = "Excellent food", Rating = 5, RestaurantId = 1 }
                }
            },
            new Restaurant
            {
                Id = 2,
                Name = "Everest Diner",
                Location = "Pokhara",
                CuisineType = "Continental",
                Rating = 4,
                Review = new List<Review>()
            }
        };

        // ✅ Public property for pages & controller
        public List<Restaurant> Restaurants => _restaurants;

        public Restaurant? GetRestaurantById(int id)
            => _restaurants.FirstOrDefault(r => r.Id == id);

        public void AddRestaurant(Restaurant r) => _restaurants.Add(r);

        public void DeleteRestaurant(int id)
        {
            var r = GetRestaurantById(id);
            if (r != null) _restaurants.Remove(r);
        }

        public void UpdateRestaurant(Restaurant r)
        {
            var existing = GetRestaurantById(r.Id);
            if (existing != null)
            {
                existing.Name = r.Name;
                existing.Location = r.Location;
                existing.CuisineType = r.CuisineType;
                existing.Rating = r.Rating;
                existing.Review = r.Review;
            }
        }

        public void AddReview(int restaurantId, Review review)
        {
            var r = GetRestaurantById(restaurantId);
            if (r != null)
            {
                review.Id = r.Review.Count + 1;
                review.RestaurantId = restaurantId;
                r.Review.Add(review);
                r.Rating = (int)r.Review.Average(rv => rv.Rating);
            }
        }
    }
}