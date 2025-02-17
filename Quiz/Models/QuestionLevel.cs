using System.ComponentModel.DataAnnotations;

namespace Quiz.Models
{
    public class QuestionLevel
    {
        [Required]
        public String Questionlevel { get; set; }
        [Required]
        public String UserName { get; set; }
        [Required]
        public int userId{ get; set; }
        [Required]
        public int QuestionLevelID { get; set; }
        [Required]
        public DateTime created {  get; set; }  
        [Required]
        public DateTime modified { get; set; }

    }
}
