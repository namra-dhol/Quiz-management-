using Microsoft.AspNetCore.Mvc;

namespace Quiz.Controllers
{
    public class Login : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
