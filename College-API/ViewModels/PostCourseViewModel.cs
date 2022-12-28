using System.ComponentModel.DataAnnotations;

namespace College_API.ViewModels
{
    public class PostCourseViewModel
    {
        public string? Name { get; set; }
        [Required(ErrorMessage = "Course number is required")]
        public int CourseNumber { get; set; }
        public float Duration { get; set; }
        public string? Detail { get; set; }
    }
}