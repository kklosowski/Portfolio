using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public BlogController(ApplicationDbContext applicationDbContext, UserManager<IdentityUser> userManager)
        {
            this._applicationDbContext = applicationDbContext;
            this._userManager = userManager;
        }

        public IActionResult Index()
        {
            List<Post> posts = _applicationDbContext.Posts.ToList();

            return View(posts);
        }

        public IActionResult Post(int id)
        {
            var post = _applicationDbContext.Posts.FirstOrDefault(x => x.Id == id);
            return View(post);
        }

        //GET: Project/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Write()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Write(
            [Bind("Id, Title, ShortText, LongText, ImageUrl")]
            Post post)
        {
            //TODO: Fix user assignment
            if (ModelState.IsValid)
            {
                var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                post.DateCreated = DateTime.Now;
                post.Author = await _userManager.FindByIdAsync(userId);

                _applicationDbContext.Add(post);
                await _applicationDbContext.SaveChangesAsync();
                return RedirectToAction("Post", "Blog", new { id = post.Id });
            }

            return View();
        }
    }
}