namespace Zaharie_Alexandra_Proiect4.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<CourseDepartment>? CourseDepartment { get; set; }
    }
}
