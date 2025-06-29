using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Quiz.Models;
using System.Configuration;

namespace Quiz.Controllers
{
    [CheckAccess]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            string connectionstr = this._configuration.GetConnectionString("ConnectionString");
            //PrePare a connection
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connectionstr);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_MST_Total_QestionLevelCount";

            SqlDataReader objSDR = objCmd.ExecuteReader();
            dt.Load(objSDR);
            conn.Close();
            return View("Privacy", dt);
        }

        public IActionResult GetLevelWiseQuestion(int QuestionLevelID)
        {
            string connectionString = _configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_MST_QuestionLevelByQuestions";
            command.Parameters.AddWithValue("@QuestionLevelID", QuestionLevelID);
            DataTable dt = new DataTable();
            SqlDataReader objSDR = command.ExecuteReader();
            dt.Load(objSDR);
            connection.Close();
            return View("~/Views/Question/QuestionList.cshtml", dt);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
