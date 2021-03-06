﻿using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(ApplicationDbContext applicationDbContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
        }

        public IActionResult All()
        {
            return View();
        }

        public IActionResult Block(string id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            user.LockoutEnabled = true;
            _userManager.UpdateAsync(user);

            return RedirectToAction("Users", "Admin");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(string id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var comments = _applicationDbContext.Comments.Where(x => x.IdentityUserId == id);
            _applicationDbContext.RemoveRange(comments);
            _userManager.DeleteAsync(user).Wait();

            return RedirectToAction("Users", "Admin");
        }
    }
}