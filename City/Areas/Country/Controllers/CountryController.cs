using Microsoft.AspNetCore.Mvc;

namespace City.Areas.Country.Controllers
{
    [Area("Country")]
    public class CountryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult User()
        {
            return View();
        }
    }
}
