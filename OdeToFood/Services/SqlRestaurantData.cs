using System.Collections.Generic;
using System.Linq;
using OdeToFood.Entities;

namespace OdeToFood.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToFoodDbContext _context;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            _context = context;
        }
        public void Add(Restaurant newRestaurant)
        {
            _context.Add(newRestaurant);
            _context.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.ToList();
        }
    }
}
