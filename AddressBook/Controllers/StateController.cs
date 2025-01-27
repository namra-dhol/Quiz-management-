using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    public class StateController : Controller
    {
        public IActionResult AddState()
        {
            return View();
        }
        public IActionResult TableState()
        {
            return View();
        }

    }
}
