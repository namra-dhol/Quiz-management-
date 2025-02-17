using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Models
{
    public class Question
    {
        [Required(ErrorMessage="Enter question text")]
        public String questionText { get; set; }

        [Required]
        public int questionId { get; set; } 

        [Required(ErrorMessage ="enter optionA")]
        public String OptionA { get; set; }
        [Required(ErrorMessage = "enter optionB")]
        public String OptionB { get; set; }
        [Required]
        public String OptionC { get; set; }
        [Required]
        public String OptionD { get; set; }
        [Required(ErrorMessage = "enter questionlevel")]
        [DisplayName("questionLevel")]
        public int questionLevel { get; set; }
        [Required]
        public String correctOption { get; set; }
        [Required]
        public int questionMarks { get; set; }
        [Required]
        public int userId { get; set; }
        [Required]
        public DateTime  modified { get; set; }
    }
}

