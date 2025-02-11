using System.ComponentModel.DataAnnotations;

namespace AddressBook.Models
{
    public class Country
    {
        [Required]
        public int CountryId { get; set; }
        [Required]
        public string CountryName { get; set; }
        [Required]
        public string CountryCode { get; set; }

        [Required]
        public DateTime creationdate { get; set; }
        
        [Required]
        public int UserId { get; set; }
        
    }
}
