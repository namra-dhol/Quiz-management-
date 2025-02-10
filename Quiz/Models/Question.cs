using System.ComponentModel.DataAnnotations;

namespace Quiz.Models
{
    public class Question
    {
        [Required]
        public String questionText { get; set; }
        [Required]
        public String OptionA { get; set; }
        [Required]
        public String OptionB { get; set; }
        [Required]
        public String OptionC { get; set; }
        [Required]
        public String OptionD { get; set; }
        [Required]
        public int questionLevel { get; set; }
        [Required]
        public String correctOption { get; set; }
        [Required]
        public int questionMarks { get; set; }
        [Required]
        public int userId { get; set; }
    }
}

