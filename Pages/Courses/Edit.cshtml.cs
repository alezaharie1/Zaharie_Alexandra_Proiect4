using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zaharie_Alexandra_Proiect4.Data;
using Zaharie_Alexandra_Proiect4.Models;


namespace Zaharie_Alexandra_Proiect4.Pages.Courses
{
    public class EditModel : CourseDepartmentsPageModel
    {
        private readonly Zaharie_Alexandra_Proiect4.Data.Zaharie_Alexandra_Proiect4Context _context;

        public EditModel(Zaharie_Alexandra_Proiect4.Data.Zaharie_Alexandra_Proiect4Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Course Course { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _context.Course .Include(b => b.Mentor)
                .Include(b => b.CourseDepartments).ThenInclude(b => b.Department)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);


            if (Course == null)
            {
                return NotFound();
            }

            PopulateAssignedDepartmentData(_context, Course);
            //Course = course;
            ViewData["MentorID"] = new SelectList(_context.Set<Mentor>(), "ID",
"MentorName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedDepartments)
        {
            if (id == null)
            {
                return NotFound();
            }
            var courseToUpdate = await _context.Course
              .Include(i => i.Mentor)
              .Include(i => i.CourseDepartments)
              .ThenInclude(i => i.Department)
              .FirstOrDefaultAsync(s => s.ID == id);
            if (courseToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Course>(
                        courseToUpdate,
                         "Course",
                    i => i.Name, 
                    i => i.Description, i => i.StartDate, i => i.MentorID))
            {
                UpdateCourseDepartments(_context, selectedDepartments, courseToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(Course.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            UpdateCourseDepartments(_context, selectedDepartments, courseToUpdate);
            PopulateAssignedDepartmentData(_context, courseToUpdate);
            return RedirectToPage("./Index");






        }
        


        private bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.ID == id);
        }
 

    }
}

