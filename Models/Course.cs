using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Zaharie_Alexandra_Proiect4.Models
{
    public class Course
    {
        public int ID { get; set; }

        [Display(Name = "Course Name")]
        public string Name { get; set; }

        public string Description { get; set; }
        public int Credits { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        public int? MentorID { get; set; }
        public Mentor? Mentor { get; set; }
    }
}
