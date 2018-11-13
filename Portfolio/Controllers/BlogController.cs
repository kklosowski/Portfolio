using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            List<Post> posts = new List<Post>();
            Post post = new Post()
            {
                Id = 1,
                Title = "New Test Post",
                ShortText = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.",
                LongText = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?",
                DateCreated = DateTime.Now,
                CreatorId = "1",     
                ImageUrl = "data:image/png;base64,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"

            };
            posts.Add(post);
            posts.Add(post);
            posts.Add(post);
            posts.Add(post);
            return View(posts);
        }

        public IActionResult Post(int id)
        {
            return View();
        }
    }
}