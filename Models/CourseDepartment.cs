namespace Zaharie_Alexandra_Proiect4.Models
{
    public class CourseDepartment
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
    }
}
