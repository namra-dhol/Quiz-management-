using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;

namespace AddressBook.Controllers
{
    public class ExportToExcleController : Controller
    {
        private IConfiguration configuration;

        public ExportToExcleController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IActionResult ExportToExcleDemo()
        {
            return View();
        }
        public IActionResult ExportToExcel()
        {
            string connectionString = configuration.GetConnectionString("ConnectionString");
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "PR_GetAllCities";
            //sqlCommand.Parameters.Add("@CityID", SqlDbType.Int).Value = CommonVariable.CityID();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(sqlDataReader);

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("DataSheet");

                // Add headers
                worksheet.Cells[1, 1].Value = "CityID";
                worksheet.Cells[1, 2].Value = "CityName";
                worksheet.Cells[1, 3].Value = "CreationDate";

                // Add data
                int row = 2;
                foreach (DataRow item in data.Rows)
                {
                    worksheet.Cells[row, 1].Value = item["CityID"];
                    worksheet.Cells[row, 2].Value = item["CityName"];
                    worksheet.Cells[row, 3].Value = item["CreationDate"];
                    row++;
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                string excelName = $"Data-{DateTime.Now:yyyyMMddHHmmss}.pdf";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
            }
        }
    }
}
