using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Quiz.Models;

namespace Quiz.Controllers
{
    [CheckAccess]
    public class QuizWiseQuestionController : Controller
    {
        private IConfiguration configuration;

        public QuizWiseQuestionController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IActionResult QuizWiseQuestionList()
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_MST_QuizWiseQuestions_SelectAll";
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            return View(table);
        }
        #region Quiz wise Question Save
        public IActionResult QuizWiseQuestionSave(QuizWiseQuestionModel model)
        {
            if (ModelState.IsValid)
            {
                UserDropDown();
                QuizDropDown();
                QuestionDropDown();
                string connectionString = configuration.GetConnectionString("ConnectionString");
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand command = sqlConnection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                if (model.QuizWiseQuestionsID == 0)
                {
                    command.CommandText = "PR_MST_QuizWiseQuestions_Insert";
                }
                else
                {
                    command.CommandText = "PR_MST_QuizWiseQuestions_Update";
                    command.Parameters.Add("@QuizWiseQuestionsID", SqlDbType.Int).Value = model.QuizWiseQuestionsID;
                }
                command.Parameters.Add("@QuizID", SqlDbType.Int).Value = model.QuizID;
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = model.UserID;
                command.Parameters.Add("@QuestionID", SqlDbType.Int).Value = model.QuestionID;
                command.ExecuteNonQuery();

                return RedirectToAction("QuizWiseQuestionList");
            }
            else
            {
                QuizDropDown();
                QuestionDropDown();
                UserDropDown();
                return View("AddQuizWiseQuestion", model);
            }
        }
        #endregion

        public IActionResult AddQuizWiseQuestion(int QuizWiseQuestionsID)
        {
            UserDropDown(); // Ensure User dropdown is populated
            QuizDropDown();
            QuestionDropDown();

            string connectionString = configuration.GetConnectionString("ConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PR_MST_QuizWiseQuestions_SelectByID";
                    command.Parameters.AddWithValue("@QuizWiseQuestionsID", QuizWiseQuestionsID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        QuizWiseQuestionModel model = new QuizWiseQuestionModel();
                        foreach (DataRow row in dataTable.Rows)
                        {
                            model.QuizID = Convert.ToInt32(row["QuizID"]);
                            model.QuestionID = Convert.ToInt32(row["QuestionID"]);
                            model.UserID = Convert.ToInt32(row["UserID"]);
                        }
                        return View("AddQuizWiseQuestion", model);
                    }
                }
            }
        }


        #region Quiz Wise Question Delete
        public IActionResult QuizWiseQuestionDelete(int QuizWiseQuestionsID)
        {
            try
            {
                string connectionString = configuration.GetConnectionString("ConnectionString");
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PR_MST_QuizWiseQuestions_Delete";
                command.Parameters.AddWithValue("@QuizWiseQuestionsID", QuizWiseQuestionsID);
                command.ExecuteNonQuery();

                return RedirectToAction("QuizWiseQuestionList");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while deleting the Quiz Wise Question: " + ex.Message;
                return RedirectToAction("QuizWiseQuestionList");
            }
        }
        #endregion

        #region Question DropDown
        public void QuestionDropDown()
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Dropdown_MST_Question";
            SqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            List<QuestionDropdownModel> list = new List<QuestionDropdownModel>();
            foreach (DataRow data in dataTable.Rows)
            {
                QuestionDropdownModel model = new QuestionDropdownModel();
                model.QuestionID = Convert.ToInt32(data["QuestionID"]);
                model.QuestionText = data["QuestionText"].ToString();
                list.Add(model);
            }
            ViewBag.Question = list;
        }
        #endregion

        #region Quiz DropDown
        public void QuizDropDown()
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Dropdown_MST_Quiz";
            SqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            List<QuizDropdownModel> list = new List<QuizDropdownModel>();
            foreach (DataRow data in dataTable.Rows)
            {
                QuizDropdownModel model = new QuizDropdownModel();
                model.QuizID = Convert.ToInt32(data["QuizID"]);
                model.QuizName = data["QuizName"].ToString();
                list.Add(model);
            }
            ViewBag.Quiz = list;
        }
        #endregion
        #region User_Dropdown
        public void UserDropDown()
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

        public IActionResult ExportToExcel()
        {
            try
            {
                string connectionString = configuration.GetConnectionString("ConnectionString");
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "PR_MST_QuizWiseQuestions_SelectAll";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                DataTable data = new DataTable();
                data.Load(sqlDataReader);

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("QuizWiseQuestions");

                    // Add headers
                    worksheet.Cells[1, 1].Value = "QuizWiseQuestionsID";
                    worksheet.Cells[1, 2].Value = "QuizID";
                    worksheet.Cells[1, 3].Value = "QuizName";
                    worksheet.Cells[1, 4].Value = "QuestionID";
                    worksheet.Cells[1, 5].Value = "QuestionText";
                    worksheet.Cells[1, 6].Value = "UserID";
                    worksheet.Cells[1, 7].Value = "UserName";
                    worksheet.Cells[1, 8].Value = "Created";
                    worksheet.Cells[1, 9].Value = "Modified";

                    // Add data
                    int row = 2;
                    foreach (DataRow item in data.Rows)
                    {
                        worksheet.Cells[row, 1].Value = item["QuizWiseQuestionsID"];
                        worksheet.Cells[row, 2].Value = item["QuizID"];
                        worksheet.Cells[row, 3].Value = item["QuizName"];
                        worksheet.Cells[row, 4].Value = item["QuestionID"];
                        worksheet.Cells[row, 5].Value = item["QuestionText"];
                        worksheet.Cells[row, 6].Value = item["UserID"];
                        worksheet.Cells[row, 7].Value = item["UserName"];
                        worksheet.Cells[row, 8].Value = Convert.ToDateTime(item["Created"]).ToString("yyyy-MM-dd HH:mm:ss");
                        worksheet.Cells[row, 9].Value = Convert.ToDateTime(item["Modified"]).ToString("yyyy-MM-dd HH:mm:ss");

                        row++;
                    }

                    var stream = new MemoryStream();
                    package.SaveAs(stream);
                    stream.Position = 0;

                    string excelName = $"QuizWiseQuestions-{DateTime.Now:yyyyMMddHHmmss}.xlsx";
                    return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while exporting data: " + ex.Message;
                return RedirectToAction("QuizWiseQuestionsList");
            }
        }



    }
}
