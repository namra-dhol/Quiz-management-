using System.ComponentModel.DataAnnotations;

namespace Quiz.Models
{
    public class QuizWiseQuestionModel
    {
        [Required]
        public int QuizWiseQuestionsID { get; set; }
        [Required]
        public int QuizID { get; set; }
       
        public string? QuizName { get; set; }
        [Required]
        public int QuestionID { get; set; }
      
        public string? QuestionText { get; set; }
        [Required]
        public int UserID { get; set; }
        
        public string? UserName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
