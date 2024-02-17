namespace Zaharie_Alexandra_Proiect4.Models
{
    public class Language
    {
        public int ID { get; set; }
        public string LanguageName { get; set; }
        public ICollection<Course>? Courses { get; set; }
    }
}
