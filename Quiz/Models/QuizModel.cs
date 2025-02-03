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
        public int TotalQuestions { get; set; }

        [Required]
        public DateTime QuizDate { get; set; }

        [Required]
        //[ForeignKey("User")]
        public string  UserName { get; set; }

        [Required]
        public DateTime modified { get; set; }

    }
}
