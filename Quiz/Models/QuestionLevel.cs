using System.ComponentModel.DataAnnotations;

namespace Quiz.Models
{
    public class QuestionLevel
    {
        [Required]
        public String Questionlevel { get; set; }
        [Required]
        public int userId { get; set; }

    }
}
