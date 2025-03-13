using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Quiz.Models;
using static Quiz.Models.UserModel;
using OfficeOpenXml;

namespace Quiz.Controllers
{
    [CheckAccess]
    public class QuizController : Controller
    {
        private IConfiguration configuration;

        public QuizController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IActionResult QuizList()
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PR_MST_Quiz_SelectAll";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);
                        return View(table);
                    }
                }
            }
        }

        public IActionResult AddQuiz(int QuizID)
        {
            string connectionString = this.configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_MST_Quiz_SelectByID";
            command.Parameters.AddWithValue("@QuizID", QuizID);
            SqlDataReader reader = command.ExecuteReader();
            DataTable datatable = new DataTable();
            datatable.Load(reader);
            QuizModel model = new QuizModel();
            foreach (DataRow row in datatable.Rows)
            {
                model.QuizId = Convert.ToInt32(@row["QuizID"]);
                model.QuizName = @row["QuizName"].ToString();
                model.TotalQuestions = Convert.ToInt32(@row["TotalQuestions"]);
                model.QuizDate = Convert.ToDateTime(@row["QuizDate"]);
                model.UserID = Convert.ToInt32(@row["UserID"]);
            }
            QuizUserDropDown();
            return View("AddQuiz", model);

        }
        public IActionResult QuizSave(QuizModel model)
        {
            if (ModelState.IsValid)
            {
                string connectionString = this.configuration.GetConnectionString("connectionString");
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                if (model.QuizId == 0)
                {
                    command.CommandText = "PR_MST_Quiz_Insert";
                }
                else
                {
                    command.CommandText = "PR_MST_Quiz_Update";
                    command.Parameters.Add("@QuizID", SqlDbType.Int).Value = model.QuizId;
                }
                command.Parameters.Add("@QuizName", SqlDbType.VarChar).Value = model.QuizName;
                command.Parameters.Add("@TotalQuestions", SqlDbType.Int).Value = model.TotalQuestions;
                command.Parameters.Add("@QuizDate", SqlDbType.DateTime).Value = model.QuizDate;
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = model.UserID;

                command.ExecuteNonQuery();
                return RedirectToAction("QuizList");

            }
            if (ModelState.IsValid)
            {
                return RedirectToAction("QuizList");
            }
            QuizUserDropDown();
            return View("AddQuiz", model);
        }
      
        public IActionResult QuizDelete(int QuizID)
        {
            try
            {
                string connectionString = this.configuration.GetConnectionString("ConnectionString");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PR_MST_Quiz_Delete";
                    command.Parameters.Add("@QuizID", SqlDbType.Int).Value = QuizID;


                    command.ExecuteNonQuery();
                }

                TempData["SuccessMessage"] = "table QuizList deleted successfully.";
                return RedirectToAction("QuizList");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while deleting the Quiz: " + ex.Message;
                return RedirectToAction("QuizList");
            }
        }
        #region User_Dropdown
        public void QuizUserDropDown()
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
            string connectionString = configuration.GetConnectionString("ConnectionString");
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "PR_MST_Quiz_SelectAll";
            //sqlCommand.Parameters.Add("@CityID", SqlDbType.Int).Value = CommonVariable.CityID();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(sqlDataReader);

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("DataSheet");

                // Add headers
                worksheet.Cells[1, 1].Value = "QuizId";
                worksheet.Cells[1, 2].Value = "QuizName";
                worksheet.Cells[1, 3].Value = "TotalQuestions";
                worksheet.Cells[1, 4].Value = "created";
                worksheet.Cells[1, 5].Value = "modified";

                // Add data
                int row = 2;
                foreach (DataRow item in data.Rows)
                {
                    worksheet.Cells[row, 1].Value = item["QuizId"];
                    worksheet.Cells[row, 2].Value = item["QuizName"];
                    worksheet.Cells[row, 3].Value = item["TotalQuestions"];
                    worksheet.Cells[row, 4].Value = Convert.ToDateTime(item["Created"]).ToString("yyyy-MM-dd HH:mm:ss");
                    worksheet.Cells[row, 5].Value = Convert.ToDateTime(item["Modified"]).ToString("yyyy-MM-dd HH:mm:ss");
                    row++;
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                string excelName = $"QuizData-{DateTime.Now:yyyyMMddHHmmss}.xlsx";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
            }
        }

        public IActionResult QuizFilter(IFormCollection fc)
        {
            //CountryDropDown();
            //StateDropDown(null);

            string connectionString = this.configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "PR_MST_Quiz_Search";
            //command.Parameters.Add("@UserID", SqlDbType.Int).Value = CommonVariable.UserID();
            command.Parameters.Add("@QuizName", SqlDbType.VarChar).Value = fc["QuizName"].ToString();
            //command.Parameters.Add("@CityCode", SqlDbType.VarChar).Value = fc["CityCode"].ToString();

            SqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            return View("QuizList", dataTable);
        }

    }
}
