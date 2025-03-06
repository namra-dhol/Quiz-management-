using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Models
{
    public class QuizModel
    {
      
        [Required]
        [StringLength(100)]
        public string QuizName { get; set; }

        [Required]
        public int QuizId { get; set; } 

        [Required]
        [Range(1,100)]
        public int TotalQuestions { get; set; }

        [Required]
        public DateTime QuizDate { get; set; }

        [Required]
        public int UserID { get; set; }

        public DateTime modified { get; set; }
        public DateTime Created { get; set; }

    }
    public class QuizDropdownModel
    {
        public int QuizID { get; set; }
        public string QuizName { get; set; }
    }
}
