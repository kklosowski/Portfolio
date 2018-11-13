using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Portfolio.Models;


namespace Portfolio.ViewModels
{
    public class UsersAllViewModel
    {
        public IEnumerable<IdentityUser> Users { get; set; }
        public RoleManager<IdentityRole> RoleManager { get; set; }
    }
}
