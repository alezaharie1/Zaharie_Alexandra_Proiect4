namespace Zaharie_Alexandra_Proiect4.Models
{
    public class CourseData
    {
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<CourseDepartment> CourseDepartments { get; set; }
    }
}
