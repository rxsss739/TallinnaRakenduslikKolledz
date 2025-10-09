using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolledz.Data;
using TallinnaRakenduslikKolledz.Models;

namespace TallinnaRakenduslikKolledz.Controllers
{
    public class DelinquentsController : Controller
    {
        private readonly SchoolContext _context;

        public DelinquentsController(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Delinquents.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DelinquentId,FirstName,LastName,Violation,TeacherOrStudent,Situation")] Delinquent delinquent)
        {   
            if (ModelState.IsValid)
            {
                _context.Delinquents.Add(delinquent);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) { return NotFound(); }

            var delinquent = await _context.Delinquents.FirstOrDefaultAsync(x => x.DelinquentId == id);

            if (delinquent == null) { return NotFound(); }

            return View(delinquent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var delinquent = await _context.Delinquents.FirstOrDefaultAsync(x => x.DelinquentId == id);
            return View(delinquent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("DelinquentId,FirstName,LastName,Situation,Violation,TeacherOrStudent")] Delinquent delinquent)
        {
            if (ModelState.IsValid)
            {
                _context.Delinquents.Update(delinquent);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(delinquent);
        }
    }
}
