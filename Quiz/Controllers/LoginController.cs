using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Quiz.Models;

namespace Quiz.Controllers
{
    public class LoginController : Controller
    {
        private IConfiguration configuration;

        public LoginController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IActionResult SignIn()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        
        
        //public IActionResult Index()
        //{
        //    return View("Index", "Home");
        //}

        public IActionResult Login(UserLoginModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["ErrorMessage"] = "Please provide valid login details.";
                    return RedirectToAction("SignIn");
                }

                string connectionString = this.configuration.GetConnectionString("ConnectionString");

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                    {
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.CommandText = "PR_MST_User_Login";
                        sqlCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = model.Username;
                        sqlCommand.Parameters.Add("@password", SqlDbType.VarChar).Value = model.Password;

                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        using (DataTable dataTable = new DataTable())
                        {
                            dataTable.Load(sqlDataReader);

                            if (dataTable.Rows.Count > 0)
                            {
                                DataRow dr = dataTable.Rows[0];

                               
                                HttpContext.Session.SetString("UserID", dr["UserID"].ToString());
                                HttpContext.Session.SetString("Username", dr["Username"].ToString());

                             
                                return RedirectToAction("Index","Home");

                            }
                            else
                            {
                                TempData["ErrorMessage"] = "Invalid username or password.";
                                return RedirectToAction("SignIn");
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                
                TempData["ErrorMessage"] = "An error occurred. Please try again later.";
            }
            return RedirectToAction("SignIn");
        }

        #region User Regrestration
        public IActionResult UserRegister(UserRegisterModel userRegisterModel)
        {
            if (ModelState.IsValid)
            {
                string connectionString = configuration.GetConnectionString("ConnectionString");
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "PR_MST_User_Insert";
                sqlCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userRegisterModel.UserName;
                sqlCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = userRegisterModel.Password;
                sqlCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = userRegisterModel.Email;
                //sqlCommand.Parameters.Add("@IsActive", SqlDbType.Bit).Value = userRegisterModel.IsActive;
                sqlCommand.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = userRegisterModel.MobileNo;
                sqlCommand.Parameters.Add("@IsAdmin", SqlDbType.Bit).Value = userRegisterModel.IsAdmin;
                sqlCommand.ExecuteNonQuery();
                return RedirectToAction("SignIn");
            }
            return RedirectToAction("Register");
        }

        #endregion
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("SignIn", "Login");
        }
    }
}
