using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityUser> _roleManager;

        public UserController(ApplicationDbContext applicationDbContext, UserManager<IdentityUser> userManager, RoleManager<IdentityUser> roleManager)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult All()
        {
            UsersAllViewModel usersAllViewModel = new UsersAllViewModel()
            {
                Users = _userManager.Users,
                RoleManager = _roleManager
            };
            return View(usersAllViewModel);
        }
    }
}