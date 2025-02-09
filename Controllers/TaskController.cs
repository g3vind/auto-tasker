using auto_tasker.Services;
using Microsoft.AspNetCore.Mvc;
using Task = auto_tasker.Models.Task;

namespace auto_tasker.Controllers
{
    public class TaskController : Controller
    {
        private readonly AppDbContext _context;
        public TaskController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Task task)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(task);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
