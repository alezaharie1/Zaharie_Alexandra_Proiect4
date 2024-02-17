using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Zaharie_Alexandra_Proiect4.Data;
using Zaharie_Alexandra_Proiect4.Migrations;
using Zaharie_Alexandra_Proiect4.Models;

namespace Zaharie_Alexandra_Proiect4.Pages.Courses
{
    public class CreateModel : CourseDepartmentsPageModel
    {
        private readonly Zaharie_Alexandra_Proiect4.Data.Zaharie_Alexandra_Proiect4Context _context;

        public CreateModel(Zaharie_Alexandra_Proiect4.Data.Zaharie_Alexandra_Proiect4Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["MentorID"] = new SelectList(_context.Set<Models.Mentor>(), "ID",
"MentorName");
            var course = new Course();
            course.CourseDepartments = new List<Models.CourseDepartment>();
            PopulateAssignedDepartmentData(_context, course);
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedDepartments)
        {
            var newCourse = new Course();
            if (selectedDepartments != null)
            {
                newCourse.CourseDepartments = new List<Models.CourseDepartment>();
                foreach (var dep in selectedDepartments)
                {
                    var depToAdd = new Models.CourseDepartment 
                    {
                        DepartmentID = int.Parse(dep)
                    };
                    newCourse.CourseDepartments.Add(depToAdd);
                }
            }
            Course.CourseDepartments = newCourse.CourseDepartments;
            _context.Course.Add(Course);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
