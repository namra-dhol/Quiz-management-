using System.ComponentModel.DataAnnotations;

namespace AddressBook.Models
{
    public class ProductModel
    {
        public int productID { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        
        public string productName { get; set; }


        [Required(ErrorMessage = "Price is required.")]
      
        public decimal price { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string category { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        public int rating { get; set; }

        [Required(ErrorMessage = "Product Company is required.")]
        public string productCompany { get; set; }
    }
}
