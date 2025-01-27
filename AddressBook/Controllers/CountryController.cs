using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    public class CountryController : Controller
    {
        public IActionResult AddCountry()
        {
            return View();
        }

        public IActionResult TableCountry()
        {
            return View();
        }
    }
}
