using Microsoft.AspNetCore.Mvc;

namespace DemoTest.Controllers
{
    public class ExportPdfController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ExportPdfController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult DownloadPdf()
        {
            // Build the full path
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "AtmiyaBrocer.pdf");

            var contentType = "application/pdf";
            var fileName = "AtmiyaBrocer.pdf";

            // Read the file into memory
            var fileBytes = System.IO.File.ReadAllBytes(filePath);

            return File(fileBytes, contentType, fileName);
        }
    }
}