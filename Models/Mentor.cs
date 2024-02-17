namespace Zaharie_Alexandra_Proiect4.Models
{
    public class Mentor
    {
        public int ID { get; set; }
        public string MentorName { get; set; }
        public ICollection<Course>? Courses { get; set; }
    }
}
