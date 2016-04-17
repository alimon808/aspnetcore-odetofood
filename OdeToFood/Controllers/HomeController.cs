using Microsoft.AspNet.Mvc;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        public ObjectResult Index()
        {
            var model = new Restaurant { Id = 1, Name = "Sabatino's" };
            return new ObjectResult(model);
        }

        // return default json
        public ObjectResult RestaurantJSON()
        {
            var model = new Restaurant { Id = 1, Name = "Sabatino's" };
            return new ObjectResult(model);
        }
    }
}
