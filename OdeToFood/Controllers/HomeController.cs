using Microsoft.AspNet.Mvc;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        Restaurant _restaurant = new Restaurant { Id = 1, Name = "Sabatino's" };

        public ViewResult Index()
        {
            var model = _restaurant;
            return View(model);
        }

        // return default json
        public ObjectResult RestaurantJSON()
        {
            var model = _restaurant;
            return new ObjectResult(model);
        }


    }
}
