using System.ComponentModel.DataAnnotations;

namespace AddressBook.Models
{
    public class CityModel
    {
       
            [Required]
            public string countryId { get; set; }
            [Required]
            public string stateId { get; set; }
            [Required]
            public string cityId { get; set; }
            [Required]
            public string cityName { get; set; }
            [Required]
            public int stdCode { get; set; }
            [Required]
            public int pinCode { get; set; }
            [Required]
            public DateTime creationDate { get; set; }
            [Required]
            public string userId { get; set; }
        }
}
