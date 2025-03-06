using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Quiz.Models;

namespace Quiz.Controllers
{
    [CheckAccess]
    public class QuestionController : Controller
    {
        private IConfiguration configuration;

        public QuestionController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IActionResult QuestionList()
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PR_MST_Question_SelectAll";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);
                        return View(table);
                    }
                }
            }
        }

        public IActionResult QuestionDelete(int questionId)
        {
            try
            {
                string connectionString = this.configuration.GetConnectionString("ConnectionString");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PR_MST_Question_Delete";
                    command.Parameters.Add("@questionId", SqlDbType.Int).Value = questionId;


                    command.ExecuteNonQuery();
                }

                TempData["SuccessMessage"] = "table QuizList deleted successfully.";
                return RedirectToAction("QuestionList");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while deleting the Quiz: " + ex.Message;
                return RedirectToAction("QuestionList");
            }
        }
        #region Question Add

        public IActionResult QuestionSave(QuestionModel model)
        {
            if (ModelState.IsValid)
            {
                QuestionLevelDropDown();
                QuestionUserDropDown();
                string connectionString = configuration.GetConnectionString("ConnectionString");
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand command = sqlConnection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                if (model.QuestionID == 0)
                {
                    command.CommandText = "PR_MST_Question_Insert";
                }
                else
                {
                    command.CommandText = "PR_MST_Question_Update";
                    command.Parameters.Add("@QuestionID", SqlDbType.Int).Value = model.QuestionID;
                }
                command.Parameters.Add("@QuestionText", SqlDbType.VarChar).Value = model.QuestionText;
                command.Parameters.Add("@OptionA", SqlDbType.VarChar).Value = model.OptionA;
                command.Parameters.Add("@OptionB", SqlDbType.VarChar).Value = model.OptionB;
                command.Parameters.Add("@OptionC", SqlDbType.VarChar).Value = model.OptionC;
                command.Parameters.Add("@OptionD", SqlDbType.VarChar).Value = model.OptionD;
                command.Parameters.Add("@QuestionLevelID", SqlDbType.VarChar).Value = model.QuestionLevelID;
                command.Parameters.Add("@QuestionMarks", SqlDbType.Int).Value = model.QuestionMarks;
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = model.UserID;
                command.Parameters.Add("@CorrectOption", SqlDbType.VarChar).Value = model.CorrectOption;

                command.ExecuteNonQuery();

                return RedirectToAction("QuestionList");
            }
            else
            {
                QuestionLevelDropDown();
                QuestionUserDropDown();
                return View("AddQuestion", model);
            }
        }
        #endregion Question Add

        #region Question Edit
        public IActionResult AddQuestion(int QuestionID)
        {
            QuestionLevelDropDown();
            QuestionUserDropDown();
            string connectionString = configuration.GetConnectionString("ConnectionString");
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();
            SqlCommand command = Connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_MST_Question_SelectByID";
            command.Parameters.AddWithValue("@QuestionID", QuestionID);
            SqlDataReader reader = command.ExecuteReader();
            DataTable datatable = new DataTable();
            datatable.Load(reader);
            QuestionModel model = new QuestionModel();
            foreach (DataRow row in datatable.Rows)
            {
                model.QuestionID = Convert.ToInt32(@row["QuestionID"]);
                model.QuestionText = @row["QuestionText"].ToString();
                model.OptionA = @row["OptionA"].ToString();
                model.OptionB = @row["OptionB"].ToString();
                model.OptionC = @row["OptionC"].ToString();
                model.OptionD = @row["OptionD"].ToString();
                model.QuestionLevel = @row["QuestionLevel"].ToString();
                model.QuestionMarks = Convert.ToInt32(@row["QuestionMarks"]);
                model.CorrectOption = @row["CorrectOption"].ToString();
                model.QuestionLevelID = Convert.ToInt32(@row["QuestionLevelID"]);
                model.UserID = Convert.ToInt32(@row["UserID"]);
                //command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = model.IsActive;
            }
            return View("AddQuestion", model);
        }
        #endregion Question Edit

        #region Question level Dropdown
        public void QuestionLevelDropDown()
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Dropdown_MST_QuestionLevel";
            SqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            List<QuestionLevelDropdownModel> list = new List<QuestionLevelDropdownModel>();
            foreach (DataRow data in dataTable.Rows)
            {
                QuestionLevelDropdownModel model = new QuestionLevelDropdownModel();
                model.QuestionLevelID = Convert.ToInt32(data["QuestionLevelID"]);
                model.QuestionLevel = data["QuestionLevel"].ToString();
                list.Add(model);
            }
            ViewBag.QuestionLevel = list;
        }
        #endregion Question Dropdown

        #region User Dropdown
        public void QuestionUserDropDown()
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
        #endregion User Dropdown
    
    }
}
