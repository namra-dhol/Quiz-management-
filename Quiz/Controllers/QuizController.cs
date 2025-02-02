using Microsoft.AspNetCore.Mvc;

namespace Quiz.Controllers
{
    public class QuizController : Controller
    {
        public IActionResult QuizList()
        {
            return View();
        }

        public IActionResult AddQuiz()
        {
            return View();
        }
    }
}
