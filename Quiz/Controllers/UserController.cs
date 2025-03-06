using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Quiz.Models;

namespace Quiz.Controllers
{
    [CheckAccess]

    //[Route("User")]
    public class UserController : Controller
    {

        private IConfiguration configuration;
        //private object _logger;

        public UserController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IActionResult UserList()
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PR_MST_User_SelectAll";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);
                        return View(table);
                    }
                }
            }
        }

        public IActionResult UserDelete(int UserID)
        {
            try
            {
                string connectionString = this.configuration.GetConnectionString("ConnectionString");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PR_MST_User_Delete";
                    command.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;


                    command.ExecuteNonQuery();
                }

                TempData["SuccessMessage"] = "table QuizList deleted successfully.";
                return RedirectToAction("UserList");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while deleting the Quiz: " + ex.Message;
                return RedirectToAction("UserList");
            }
        }

        #region UserAdd

        public IActionResult AddUser(int UserID)
        {
            string connectionString = this.configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_MST_User_SelectByID";
            command.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            UserModel model = new UserModel();
            foreach (DataRow row in dataTable.Rows)
            {
                model.UserID = Convert.ToInt32(@row["UserID"]);
                model.Username = @row["UserName"].ToString();
                model.Email = @row["Email"].ToString();
                model.Password = @row["Password"].ToString();
                model.Mobile = @row["Mobile"].ToString();
                model.IsAdmin = Convert.ToBoolean(@row["IsAdmin"]);
            }
            return View("AddUser", model);
        }
        #endregion UserAdd 

        #region User Save
        public IActionResult UserSave(UserModel model)
        {
            if (ModelState.IsValid)
            {
                string connectionString = this.configuration.GetConnectionString("ConnectionString");
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                if (model.UserID == 0)
                {
                    command.CommandText = "PR_MST_User_Insert";
                }
                else
                {
                    command.CommandText = "PR_MST_User_Update";
                    command.Parameters.Add("@UserID", SqlDbType.Int).Value = model.UserID;
                }
                command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = model.Username;
                command.Parameters.Add("@Email", SqlDbType.VarChar).Value = model.Email;
                command.Parameters.Add("@Password", SqlDbType.VarChar).Value = model.Password;
                command.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = model.Mobile;
                command.Parameters.Add("@IsAdmin", SqlDbType.Bit).Value = model.IsAdmin;
                command.ExecuteNonQuery();
                return RedirectToAction("UserList");
            }
            return View("AddUser", model);
        }
        #endregion user save


      
        //public IActionResult Login(UserLoginModel model)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            TempData["ErrorMessage"] = "Please provide valid login details.";
        //            return RedirectToAction("SignIn");
        //        }

        //        string connectionString = this.configuration.GetConnectionString("ConnectionString");

        //        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //        {
        //            sqlConnection.Open();
        //            using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
        //            {
        //                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //                sqlCommand.CommandText = "PR_MST_User_Login";
        //                sqlCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = model.Username;
        //                sqlCommand.Parameters.Add("@password", SqlDbType.VarChar).Value = model.Password;

        //                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        //                using (DataTable dataTable = new DataTable())
        //                {
        //                    dataTable.Load(sqlDataReader);

        //                    if (dataTable.Rows.Count > 0)
        //                    {
        //                        DataRow dr = dataTable.Rows[0];

        //                        // Store user details in session
        //                        HttpContext.Session.SetString("UserId", dr["UserId"].ToString());
        //                        HttpContext.Session.SetString("Username", dr["Username"].ToString());

        //                        // ✅ Redirect to HomeController → Index (Dashboard)
        //                        return RedirectToAction("Index");

        //                    }
        //                    else
        //                    {
        //                        TempData["ErrorMessage"] = "Invalid username or password.";
        //                        return RedirectToAction("SignIn");
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        //_logger.LogError(e, "Error occurred during user login. Exception: {Message}, StackTrace: {StackTrace}", e.Message, e.StackTrace);

        //        TempData["ErrorMessage"] = "An error occurred. Please try again later.";
        //    }

        //    return RedirectToAction("SignIn");
        //}

        //public IActionResult SignIn()
        //{
        //    return View("SignIn", "Login");
        //}

        //public IActionResult Index()
        //{
        //    return View("Index", "Home");
        //}
        //public IActionResult Logout()
        //{
        //    HttpContext.Session.Clear();
        //    return RedirectToAction("SignIn", "Login");
        //}
    }
}
   