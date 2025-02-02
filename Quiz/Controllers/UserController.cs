using Microsoft.AspNetCore.Mvc;

namespace Quiz.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UserList()
        {
            return View();
        }
        public IActionResult AddUser()
        {
            return View();
        }

    }
}
