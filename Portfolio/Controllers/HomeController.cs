using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IServiceProvider _serviceProvider;

        public HomeController(IProjectRepository projectRepository, IServiceProvider serviceProvider)
        {
            _projectRepository = projectRepository;
            _serviceProvider = serviceProvider;
        }

        public IActionResult Index()
        {
            var projects = _projectRepository.GetAllProjects().OrderBy(x => x.Title);

            var homeViewModel = new HomeViewModel()
            {
                Projects = projects.ToList(),
            };

            return View(homeViewModel);
        }

        public IActionResult Send(string email, string title, string content)
        {

            using (var message = new MailMessage())
            {
                var config = _serviceProvider.GetRequiredService<IConfiguration>();

                string host = config.GetValue<String>("Email:Smtp:Host");
                string port = config.GetValue<String>("Email:Smtp:Port");
                string username = config.GetValue<String>("Email:Smtp:Username");
                string password = config.GetValue<String>("Email:Smtp:Password");



                message.To.Add(new MailAddress("kamil.klosowski@yahoo.com", "KamilYahoo"));
                message.From = new MailAddress(email, email);
                message.Subject = title;
                message.Body = content;
                message.IsBodyHtml = false;

                  

                using (var client = new SmtpClient(host))
                {
                    client.Port = Int32.Parse(port);
                    client.Credentials = new NetworkCredential(username, password);
                    client.EnableSsl = true;
                    client.Send(message);
                }
            }

            return RedirectToAction("Index", "Home");
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
