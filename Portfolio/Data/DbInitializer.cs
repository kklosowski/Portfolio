using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Portfolio.Models;

namespace Portfolio.Data
{
    public class DbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hosting;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;

        public DbInitializer(ApplicationDbContext context, IHostingEnvironment hosting ,UserManager<IdentityUser> userManager, IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _context = context;
            _hosting = hosting;
            _userManager = userManager;
            _serviceProvider = serviceProvider;
            _configuration = configuration;
        }

        public async Task SeedPosts()
        {
            _context.Database.EnsureCreated();

            if (!_context.Posts.Any())
            {
                var userManager = _serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

                var projectsPath = Path.Combine(_hosting.ContentRootPath, "Data/Posts.json");
                var jsonPosts = File.ReadAllText(projectsPath);
                var posts = JsonConvert.DeserializeObject<IEnumerable<Post>>(jsonPosts);

                foreach (var post in posts)
                {
                    var user = await userManager.FindByEmailAsync("Member1@email.com");
                    post.IdentityUser = user;
                    post.DateCreated = DateTime.Now;
                }

                _context.AddRange(posts);
                _context.SaveChanges();
            }
        }

        public void SeedProjects()
        {
            _context.Database.EnsureCreated();

            if (!_context.Projects.Any())
            {
                var projectsPath = Path.Combine(_hosting.ContentRootPath, "Data/Projects.json");
                var jsonProjects = File.ReadAllText(projectsPath);
                var projects = JsonConvert.DeserializeObject<IEnumerable<Project>>(jsonProjects);

                _context.AddRange(projects);
                _context.SaveChanges();
            }
        }

        public async Task SeedUsersAsync()
        {
            _context.Database.EnsureCreated();

            for (int i = 1; i <= 5; i++)
            {
                IdentityUser user = await _userManager.FindByEmailAsync($"Customer{i}@email.com");
                if (user == null)
                {
                    user = new IdentityUser()
                    {
                        UserName = $"Customer{i}@email.com",
                        Email = $"Customer{i}@email.com"
                    };

                    var result = await _userManager.CreateAsync(user, "Password123!");

                    if (result != IdentityResult.Success)
                    {
                        throw new InvalidOperationException("Error while seeding users" + result.ToString());
                    }
                }
            }
            
        }

        public async Task CreateRoles()
        {
            //adding customs roles
            var roleManager = _serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = _serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string[] roleNames = { "Admin", "Blogger", "Member" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                // creating the roles and seeding them to the database
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // creating a super user who could maintain the web app
            var admin = new IdentityUser
            {
                UserName = "Member1@email.com",
                Email = "Member1@email.com"
            };
            
            string adminPassword = "Password123!";
            var user = await userManager.FindByEmailAsync(admin.Email);
            
            if (user == null)
            {
                var createPowerUser = await userManager.CreateAsync(admin, adminPassword);
                if (createPowerUser.Succeeded)
                {
                    // here we assign the new user the "Admin" role 
                    await userManager.AddToRoleAsync(admin, "Admin");

                }
            }
        }
    }
}
