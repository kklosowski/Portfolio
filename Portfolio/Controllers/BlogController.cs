using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portfolio.Data;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILoggerFactory _loggerFactory;

        public BlogController(ApplicationDbContext applicationDbContext, UserManager<IdentityUser> userManager, ILoggerFactory loggerFactory)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
            _loggerFactory = loggerFactory;

            //TODO: Try to find a more elegant solution
            foreach (var post in _applicationDbContext.Posts)
            {               
                IdentityUser user = userManager.FindByIdAsync(post.IdentityUserId).Result;
                post.IdentityUser = user;
                _applicationDbContext.Posts.Update(post);
            }

            _applicationDbContext.SaveChanges();

        }

        public IActionResult Index()
        {
            var posts = _applicationDbContext.Posts.ToList();

            return View(posts);
        }

        public IActionResult Post(int id)
        {
            var post = _applicationDbContext.Posts.FirstOrDefault(x => x.Id == id);
            post.Comments = _applicationDbContext.Comments.ToList().FindAll(x => x.PostId == id)
                .OrderByDescending(x => x.DateCreated).ToList();

            return View(new PostViewModel(){post = post, comment = null});
        }

        // POST: Blog/Comment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Comment(int postId,
            [Bind("Text")] Comment comment)
        {
            var logger = _loggerFactory.CreateLogger("MyLogger");
            logger.LogDebug("Input post id" + postId);

            if (ModelState.IsValid)
            {
                var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                comment.DateCreated = DateTime.Now;
                comment.IdentityUser = _userManager.Users.First(x => x.Id == userId);
                comment.Post = _applicationDbContext.Posts.First(p => p.Id == postId);

                _applicationDbContext.Comments.Add(comment);
                await _applicationDbContext.SaveChangesAsync();
            }

            return RedirectToAction("Post", "Blog", new {id = postId});
        }

        //GET: Blog/Write
        [Authorize(Roles = "Admin")]
        public IActionResult Write()
        {
            return View();
        }

        // POST: Blog/Write
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
                post.IdentityUser = _userManager.Users.First(x => x.Id == userId);

                _applicationDbContext.Add(post);
                await _applicationDbContext.SaveChangesAsync();
                return RedirectToAction("Post", "Blog", new {id = post.Id});
            }

            return View();
        }
    }
}