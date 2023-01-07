using System.ComponentModel.DataAnnotations;

namespace College_API.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<AppUser> Teachers { get; set; } = new List<AppUser>();
    }
}