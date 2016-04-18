using System.Collections.Generic;
using OdeToFood.Entities;

namespace OdeToFood.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string CurrentGreeting { get; set; }
    }
}
