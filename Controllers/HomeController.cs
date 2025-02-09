using System.Diagnostics;
using auto_tasker.Models;
using auto_tasker.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task = auto_tasker.Models.Task;

namespace auto_tasker.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext _context)
        {
            this._context = _context;
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<Task> tasks = new List<Task>();
            tasks = _context.Tasks.ToList();
            if (tasks.Any())
            {
                return View(tasks);
            }
            return View(new List<Task>());
        }

        [Route("/tasks/{id}")]
        public IActionResult GetTaskById(int id)
        {
            if (id > 0)
            {
                var task = _context.Tasks.FirstOrDefault(e => e.Id == id);
                if (task != null)
                {
                    return View(task);
                }
                return View(new Task());
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult EditTask(int id)
        {
            if (id > 0)
            {
                var task = _context.Tasks.FirstOrDefault(e => e.Id == id);
                if (task != null)
                {
                    return View(task);
                }
                return NotFound();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult EditTask(int id, Task updatedTask)
        {
            if (id != updatedTask.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(updatedTask);
                    _context.SaveChanges();
                    return RedirectToAction("GetTaskById", "Home", new { id = updatedTask.Id });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Tasks.Any(t => t.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(updatedTask);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
