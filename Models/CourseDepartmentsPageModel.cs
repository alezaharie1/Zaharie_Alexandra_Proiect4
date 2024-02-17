using Microsoft.AspNetCore.Mvc.RazorPages;
using Zaharie_Alexandra_Proiect4.Data;
using Zaharie_Alexandra_Proiect4.Migrations;
namespace Zaharie_Alexandra_Proiect4.Models
{
    public class CourseDepartmentsPageModel : PageModel
    {
        public List<AssignedDepartmentData> AssignedDepartmentDataList;
        public void PopulateAssignedDepartmentData(Zaharie_Alexandra_Proiect4Context context,
        Course course)
        {
            var allDepartments = context.Department;
            var courseDepartments = new HashSet<int>(
            course.CourseDepartments.Select(c => c.DepartmentID)); //
            AssignedDepartmentDataList = new List<AssignedDepartmentData>();
            foreach (var dep in allDepartments)
            {
                AssignedDepartmentDataList.Add(new AssignedDepartmentData
                {
                    DepartmentID = dep.ID,
                    Name = dep.DepartmentName,
                    Assigned = courseDepartments.Contains(dep.ID)
                });
            }
        }
        public void UpdateCourseDepartments(Zaharie_Alexandra_Proiect4Context context,
        string[] selectedDepartments, Course courseToUpdate)
        {
            if (selectedDepartments == null)
            {
                courseToUpdate.CourseDepartments = new List<CourseDepartment>();
                return;
            }
            var selectedDepartmentsHS = new HashSet<string>(selectedDepartments);
            var courseDepartments = new HashSet<int>
            (courseToUpdate.CourseDepartments.Select(c => c.Department.ID));
            foreach (var dep in context.Department)
            {
                if (selectedDepartmentsHS.Contains(dep.ID.ToString()))
                {
                    if (!courseDepartments.Contains(dep.ID))
                    {
                        courseToUpdate.CourseDepartments.Add(
                        new CourseDepartment
                        {
                            CourseID = courseToUpdate.ID,
                            DepartmentID = dep.ID
                        });
                    }
                }
                else
                {
                    if (courseDepartments.Contains(dep.ID))
                    {
                        CourseDepartment courseToRemove
                        = courseToUpdate
                        .CourseDepartments
                        .SingleOrDefault(i => i.DepartmentID == dep.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
