using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Portfolio.ViewModels
{
    public class UsersAllViewModel
    {
        public IEnumerable<IdentityUser> Users { get; set; }
        public RoleManager<IdentityUser> RoleManager { get; set; }
    }
}
