
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Models
{
    public class QuestionModel
    {
        [Required(ErrorMessage = "QuestionText is Required")]
        public string QuestionText { get; set; }
        [Required(ErrorMessage = "Option A is Required")]
        public string OptionA { get; set; }
        [Required(ErrorMessage = "Option B is Required")]
        public string OptionB { get; set; }
        [Required(ErrorMessage = "Option C is Required")]
        public string OptionC { get; set; }
        [Required(ErrorMessage = "Option D is Required")]
        public string OptionD { get; set; }

        public string? QuestionLevel { get; set; }

        [Required(ErrorMessage = "Total Question mark is Required")]
        [Range(1, 100, ErrorMessage = "Total Questions must greater then 0.")]
        public int QuestionMarks { get; set; }

        [Required(ErrorMessage = "Correct Option is Required")]
        public string CorrectOption { get; set; }
        public int QuestionID { get; set; }
        public string? UserName { get; set; }

        [Required(ErrorMessage = "User name is required")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Question Level is required")]
        public int QuestionLevelID { get; set; }

        [Required]
        public bool IsActive {  get; set; }
    }
    public class QuestionDropdownModel
    {
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
    }
}