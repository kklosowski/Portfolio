using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Portfolio.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime DateCreated { get; set; }

        public string LongText { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [MaxLength(300)]
        public string ShortText { get; set; }

        [ForeignKey("CommentsForeignKey")]
        public List<Comment> Comments { get; set; }

        [ForeignKey("AuthorForeignKey")]
        public IdentityUser Author { get; set; }
    }
}
  