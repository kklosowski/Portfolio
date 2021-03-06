﻿using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Data;

namespace Portfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public AdminController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View("Users");
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View(_dbContext.Projects.ToList());
        }

        public IActionResult Posts()
        {
            return View(_dbContext.Posts.Include(x => x.IdentityUser).ToList());
        }   
    }
}