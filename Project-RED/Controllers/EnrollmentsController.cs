
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_red.Models;
using Project_RED.Models;

public class EnrollmentsController : Controller
{
    private readonly AppDbContext _context;

    public EnrollmentsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: ENROLLMENTS
    public async Task<IActionResult> Index()    
    {
        var enrollments = _context.Enrollments.Include(e => e.Student).Include(e => e.Course);return View(await enrollments.ToListAsync());
    }

    // GET: ENROLLMENTS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var enrollment = await _context.Enrollments.Include(e => e.Student).Include(e => e.Course).FirstOrDefaultAsync(m => m.Id == id);
        if (enrollment == null)
        {
            return NotFound();
        }

        return View(enrollment);
    }

    // GET: ENROLLMENTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ENROLLMENTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,StudentId,Student,CourseId,Course,Semester")] Enrollment enrollment)
    {
        if (ModelState.IsValid)
        {
            _context.Add(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(enrollment);
    }

    // GET: ENROLLMENTS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var enrollment = await _context.Enrollments.FindAsync(id);
        if (enrollment == null)
        {
            return NotFound();
        }
        return View(enrollment);
    }

    // POST: ENROLLMENTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,StudentId,Student,CourseId,Course,Semester")] Enrollment enrollment)
    {
        if (id != enrollment.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(enrollment);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentExists(enrollment.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(enrollment);
    }

    // GET: ENROLLMENTS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var enrollment = await _context.Enrollments
            .FirstOrDefaultAsync(m => m.Id == id);
        if (enrollment == null)
        {
            return NotFound();
        }

        return View(enrollment);
    }

    // POST: ENROLLMENTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var enrollment = await _context.Enrollments.FindAsync(id);
        if (enrollment != null)
        {
            _context.Enrollments.Remove(enrollment);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EnrollmentExists(int? id)
    {
        return _context.Enrollments.Any(e => e.Id == id);
    }
}
