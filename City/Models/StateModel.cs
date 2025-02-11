using System.ComponentModel.DataAnnotations;

namespace City.Models
{
    public class StateModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
