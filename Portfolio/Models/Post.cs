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

        public List<Comment> Comments { get; set; }

        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Title)}: {Title}, {nameof(DateCreated)}: {DateCreated}, {nameof(LongText)}: {LongText}, {nameof(ImageUrl)}: {ImageUrl}, {nameof(ShortText)}: {ShortText}, {nameof(Comments)}: {Comments}, {nameof(IdentityUserId)}: {IdentityUserId}, {nameof(IdentityUser)}: {IdentityUser}";
        }
    }
}
  