using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zaharie_Alexandra_Proiect4.Data;
using Zaharie_Alexandra_Proiect4.Models;

namespace Zaharie_Alexandra_Proiect4.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly Zaharie_Alexandra_Proiect4.Data.Zaharie_Alexandra_Proiect4Context _context;

        public IndexModel(Zaharie_Alexandra_Proiect4.Data.Zaharie_Alexandra_Proiect4Context context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; } = default!;
        public CourseData CourseD { get; set; }
        public int CourseID { get; set; }
        public int DepartmentID { get; set; }


        public async Task OnGetAsync(int? id, int? departmentID)
        {
            CourseD = new CourseData();

            CourseD.Courses = await _context.Course
            .Include(b => b.Mentor)
            .Include(b => b.CourseDepartments)
            .ThenInclude(b => b.Department)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();
            if (id != null)
            {
                CourseID = id.Value;
                Course course = CourseD.Courses
                .Where(i => i.ID == id.Value).Single();
                CourseD.Departments = course.CourseDepartments.Select(s => s.Department);
            }
        }
    }
}
