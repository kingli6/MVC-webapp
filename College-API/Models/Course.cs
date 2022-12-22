namespace College_API.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }   // ? is the current standard. Find out where it says that!
        public int CourseNumber { get; set; }
        public float Duration { get; set; }
        public string? Detail { get; set; }
    }
}