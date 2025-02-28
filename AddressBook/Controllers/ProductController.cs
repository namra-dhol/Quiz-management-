using Microsoft.AspNetCore.Mvc;
using AddressBook.Models;
namespace AddressBook.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Product()
        {
            return View();
        }
        public IActionResult ProductList()
        {
            return View();
        }
        public IActionResult ProductSave(ProductModel product)
        {
            return View(product);
        }

    }

}
