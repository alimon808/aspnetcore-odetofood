using Microsoft.AspNet.Mvc;
using OdeToFood.Entities;
using OdeToFood.Services;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public ViewResult Index()
        {
            var model = _restaurantData.GetAll();
            return View(model);
        }

        // return default json
        public ObjectResult RestaurantJSON()
        {
            var model = _restaurantData.GetAll();
            return new ObjectResult(model);
        }


    }
}
