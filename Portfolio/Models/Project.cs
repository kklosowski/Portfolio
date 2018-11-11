using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [MaxLength(300)]
        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }

        [DataType(DataType.Url)]
        public string GithubUrl { get; set; }
    }
}