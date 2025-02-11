using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Product()
        {
            return View();
        }

    }

}
