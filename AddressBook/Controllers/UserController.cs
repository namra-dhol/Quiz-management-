using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    public class UserController : Controller
    {
        public IActionResult TableUser()
        {
            return View();
        }

        public IActionResult AddUser()
        {
            return View();
        }
    }
}
