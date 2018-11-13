using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime DateCreated { get; set; }

        public string LongText { get; set; }

        public string CreatorId { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [MaxLength(300)]
        public string ShortText { get; set; }
    }
}
  