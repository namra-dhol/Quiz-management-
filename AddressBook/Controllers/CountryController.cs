using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    public class CountryController : Controller
    {
        private IConfiguration configuration;
       
        public CountryController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IActionResult  TableCountry()
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[PR_GetAllCountries]";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);
                        return View(table);
                    }
                }
            }
        }

        public IActionResult AddCountry()
        {
            return View();
        }
    }
}
