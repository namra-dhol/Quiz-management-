using Microsoft.AspNetCore.Mvc;

namespace Quiz.Controllers
{
    public class QuestionController : Controller
    {
        public IActionResult QuestionList()
        {
            return View();
        }

        public IActionResult AddQuestion()
        {
            return View();
        }
    }
}
