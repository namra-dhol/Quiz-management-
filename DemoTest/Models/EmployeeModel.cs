namespace DemoTest.Models
{
    public class EmployeeModel
    {
        public int       EmpID {  get; set; }
        public string    EmpName { get; set; }

        public string    department          { get; set; }  

        public int       salary          { get; set; } 

        public DateTime  created { get; set; }
    }
}
