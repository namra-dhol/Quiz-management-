using System.ComponentModel.DataAnnotations;

namespace Quiz.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        public int UserID { get; set; }

        public bool RememberMe { get; set; }
    }
}
