using Microsoft.AspNetCore.Mvc;

namespace City.Areas.Country.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
