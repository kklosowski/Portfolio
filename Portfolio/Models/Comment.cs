using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string Text { get; set; }

        public string CreatorId { get; set; }
    }
}
