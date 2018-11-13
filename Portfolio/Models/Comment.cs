using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Portfolio.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string Text { get; set; }

        [ForeignKey("UserForeignKey")]
        public IdentityUser User { get; set; }

        [ForeignKey("PostForeignKey")]
        public Post Post { get; set; }
    }
}
