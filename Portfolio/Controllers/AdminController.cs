﻿using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}