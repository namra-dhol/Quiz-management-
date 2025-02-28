using System.ComponentModel.DataAnnotations;

namespace Quiz.Models
{
    public class UserModel
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required] 
        public string Mobile { get; set; }
        [Required]
        public Boolean IsActive { get; set; }
        [Required]
        public Boolean IsAdmin { get; set; }
      
        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime Modified {  get; set; }
    }
    public class UserDropdownModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
    }
}
