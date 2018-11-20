using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProjectController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        // GET: Project/{id}
        public IActionResult Index(int id)
        {
            if (_applicationDbContext.Projects.Any(x => x.Id == id))
            {
                var project = _applicationDbContext.Projects.First(x => x.Id == id);
                return View(project);
            }

            return NotFound();
        }

        //GET: Project/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id, Title, ShortDescription, LongDescription, ImageUrl, ImageThumbnailUrl, GithubUrl")]
            Project project)
        {
            if (ModelState.IsValid)
            {
                _applicationDbContext.Add(project);
                await _applicationDbContext.SaveChangesAsync();
                return RedirectToAction("Index", "Project", new {id = project.Id});
            }

            return View();
        }

        // GET: Project/Edit/{id}
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id.HasValue)
            {
                var project = await _applicationDbContext.Projects.FindAsync(id);
                if (project != null)
                    return View(project);
                return NotFound();
            }

            return NotFound();
        }

        //POST Project/Edit/{id}
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id, Title, ShortDescription, LongDescription, ImageUrl, ImageThumbnailUrl, GithubUrl")]
            Project project)
        {
            if (id != project.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _applicationDbContext.Update(project);
                    await _applicationDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_applicationDbContext.Projects.Any(x => x.Id == project.Id))
                        throw;
                    return NotFound();
                }

                return RedirectToAction("Index", "Project", new {id = project.Id});
            }

            return View(project);
        }

        // GET: Project/All
        public IActionResult All()
        {
            var projects = _applicationDbContext.Projects.ToList();

            return View(projects);
        }


        // POST: Project/Delete/{id}
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _applicationDbContext.Projects.FindAsync(id);
            _applicationDbContext.Projects.Remove(project);
            await _applicationDbContext.SaveChangesAsync();

            return RedirectToAction("Projects", "Admin");
        }
    }
}