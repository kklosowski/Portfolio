using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Models;

namespace Portfolio.ViewModels
{
    public class PostViewModel
    {
        public Post post { get; set; }
        public Comment comment { get; set; }
    }
}
