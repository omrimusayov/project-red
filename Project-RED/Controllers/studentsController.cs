
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_red.Models;
using Project_RED.Models;

public class StudentsController : Controller
{
    private readonly AppDbContext _context;

    public StudentsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: STUDENTS
    public async Task<IActionResult> Index()    
    {
		return View(await _context.Students.Include(s => s.Teacher).ToListAsync());
    }

    // GET: STUDENTS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

		var Student = await _context.Students.Include(s => s.Teacher).FirstOrDefaultAsync(m => m.Id == id);
		if (Student == null)
        {
            return NotFound();
        }

        return View(Student);
    }

    // GET: STUDENTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: STUDENTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,GradeLevel,TeacherId,Teacher,Courses,Enrollments")] Student Student)
    {
        if (ModelState.IsValid)
        {
            _context.Add(Student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(Student);
    }

    // GET: STUDENTS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var Student = await _context.Students.FindAsync(id);
        if (Student == null)
        {
            return NotFound();
        }
        return View(Student);
    }

    // POST: STUDENTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,FirstName,LastName,GradeLevel,TeacherId,Teacher,Courses,Enrollments")] Student Student)
    {
        if (id != Student.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(Student);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(Student.Id))
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
        return View(Student);
    }

    // GET: STUDENTS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var Student = await _context.Students
            .FirstOrDefaultAsync(m => m.Id == id);
        if (Student == null)
        {
            return NotFound();
        }

        return View(Student);
    }

    // POST: STUDENTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var Student = await _context.Students.FindAsync(id);
        if (Student != null)
        {
            _context.Students.Remove(Student);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool StudentExists(int? id)
    {
        return _context.Students.Any(e => e.Id == id);
    }
}
