using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    public class CityController : Controller
    {
        public IActionResult AddCity()
        {
            return View();
        }

        public IActionResult TableCity()
        {
            return View();
        }
    }
}
