using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolledz.Data;
using TallinnaRakenduslikKolledz.Models;

namespace TallinnaRakenduslikKolledz.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SchoolContext _context;
        public CoursesController(SchoolContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var courses = _context.Courses.Include(c => c.Department)
                .AsNoTracking();

            return View(courses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["action"] = "Create";
            PopulateDepartmentsDropDownList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            PopulateDepartmentsDropDownList(course.DepartmentID);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["action"] = "Delete";

            if (id == null || _context.Courses == null) { return NotFound(); }

            var courses = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.CourseId == id);

            if (courses == null) { return NotFound(); }
            
            return View(courses);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {   

            if (_context.Courses == null) { return NotFound(); }

            var course = await _context.Courses.FindAsync(id);

            if (course != null) { _context.Courses.Remove(course); };

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["action"] = "Details";
            if (id == null) { return NotFound(); }

            var course = await _context.Courses.FirstOrDefaultAsync(d => d.CourseId == id);
            return View(nameof(Delete), course);
        }

        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = from d in _context.Departments
                                   orderby d.Name
                                   select d;
            ViewBag.DepartmentID = new SelectList(departmentsQuery.AsNoTracking(), "DepartmentID", "Name", selectedDepartment);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["action"] = "Edit";
            var course = await _context.Courses.FirstOrDefaultAsync(d => d.CourseId == id);
            return View(nameof(Create), course);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed([Bind("CourseId,Title,Credits,Enrollments,Department,DepartmentID,CourseAssignments")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Update(course);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
