using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Lab1.Models
{
    public class CityModel
    {
        public int? CityID { get; set; }
        [Required]
        [DisplayName("City Name")]
        public string CityName { get; set; }
        [Required]
        [DisplayName("Country Name")]
        public int CountryID { get; set; }
        [Required]
        [DisplayName("State Name")]
        public int StateID { get; set; }
        [Required]
        [DisplayName("City Code")]
        public string CityCode { get; set; }
    }
}
