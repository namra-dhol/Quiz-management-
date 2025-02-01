using System.ComponentModel.DataAnnotations;

namespace City.Areas.Country.Models
{
    public class Country
    {
        [Required(ErrorMessage = "Please enter an ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the country name")]
        public string CountryName { get; set; }
    }
}
