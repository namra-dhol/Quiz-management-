using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Quiz.Models;

namespace Quiz.Controllers
{
    [CheckAccess]
    public class QuestionLevelController : Controller
    {
        private IConfiguration configuration;

        public QuestionLevelController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public IActionResult QuestionLevelList()
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_MST_QuestionLevel_SelectAll";
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            return View(table);
        }
        public IActionResult QuestionLevelSave(QuestionLevelModel model)
        {
            if (ModelState.IsValid)
            {
                string connectionString = configuration.GetConnectionString("ConnectionString");
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                if (model.QuestionLevelID == 0)
                {
                    command.CommandText = "[dbo].[PR_MST_QuestionLevel_Insert]";
                }
                else
                {
                    command.CommandText = "[dbo].[PR_MST_QuestionLevel_Update]";
                    command.Parameters.AddWithValue("@QuestionLevelID", model.QuestionLevelID);
                }
                command.Parameters.AddWithValue("@QuestionLevel", model.Questionlevel);
                command.Parameters.AddWithValue("@UserID", model.UserID);
                command.ExecuteNonQuery();
                return RedirectToAction("QuestionLevelList");
            }
            QuestionLevelUserDropDown();
            return View("AddEditQuestionLevel", model);
        }
        public IActionResult AddEditQuestionLevel(int QuestionLevelID)  
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "[dbo].[PR_MST_QuestionLevel_SelectByID]";
            command.Parameters.AddWithValue("@QuestionLevelID", QuestionLevelID);
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            QuestionLevelModel questionLevelModel = new QuestionLevelModel();
            foreach (DataRow row in table.Rows)
            {
                questionLevelModel.Questionlevel = @row["QuestionLevel"].ToString();
                questionLevelModel.UserID = Convert.ToInt32(@row["UserID"]);
            }
            QuestionLevelUserDropDown();
            return View("AddEditQuestionLevel", questionLevelModel);
        }
        public IActionResult DeleteQuestionLevel(int QuestionLevelID)
        {
            string connectionString = this.configuration.GetConnectionString("ConnectionString");
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "[dbo].[PR_MST_QuestionLevel_Delete]";
            sqlCommand.Parameters.Add("@QuestionLevelID", SqlDbType.Int).Value = QuestionLevelID;
            sqlCommand.ExecuteNonQuery();
            return RedirectToAction("QuestionLevelList");
        }

        #region User_Dropdown
        public void QuestionLevelUserDropDown()
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Dropdown_MST_User";
            SqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            List<UserDropdownModel> list = new List<UserDropdownModel>();
            foreach (DataRow data in dataTable.Rows)
            {
                UserDropdownModel model = new UserDropdownModel();
                model.UserID = Convert.ToInt32(data["UserID"]);
                model.UserName = data["UserName"].ToString();
                list.Add(model);
            }
            ViewBag.User = list;
        }
        #endregion User_Dropdown
    }
}