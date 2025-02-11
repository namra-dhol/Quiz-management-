using Microsoft.AspNetCore.Mvc;

namespace City.Controllers
{
    public class StateController : Controller
    {
        public IActionResult State()
        {
            return View();
        }
    }
}
