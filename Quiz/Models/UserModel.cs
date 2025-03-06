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
        public bool IsActive { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
      
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

    public class UserRegisterModel
    {
        public int? UserID { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile Number is required.")]
        public string MobileNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
    }
}
