using System.ComponentModel.DataAnnotations;

namespace Quiz.Models
{
    public class QuestionLevelModel
    {
        [Required]
        public String Questionlevel { get; set; }
       
        public String? UserName { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int QuestionLevelID { get; set; }
        [Required]
        public DateTime created {  get; set; }  
        [Required]
        public DateTime modified { get; set; }

    }
    public class QuestionLevelDropdownModel
    {
        public int QuestionLevelID { get; set; }
        public string QuestionLevel { get; set; }
    }
}
