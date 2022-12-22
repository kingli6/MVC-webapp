using System.ComponentModel.DataAnnotations;

namespace College_API.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }   // ? is the current standard. Find out where it says that!
        public int CourseNumber { get; set; }
        // Course duration needs to be displayed in date or how many hours?
        // ex 3 days or 40 hours?
        public float Duration { get; set; }
        public string? Detail { get; set; }
    }
}