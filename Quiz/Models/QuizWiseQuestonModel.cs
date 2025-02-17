using System.ComponentModel.DataAnnotations;

namespace Quiz.Models
{
    public class QuizWiseQuestonModel
    {
        [Required]
        public int QuizWiseQuestionsID { get; set; }
        [Required]
        public int QuizID { get; set; }
        [Required]
        public string QuizName { get; set; }
        [Required]
        public int QuestionID { get; set; }
        [Required]
        public string QuestionText { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
