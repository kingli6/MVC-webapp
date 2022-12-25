using College_API.Models;

namespace College_API.Interfaces
{
    public interface ICourseRepository
    {
        public Task<List<Course>> ListAllCourseAsync();
        public Task<Course?> GetCourseByIdAsync(int id);
        public Task<Course> GetCourseByCourseNumAsync(string courseNumber);
        public Task AddCourseAsync(Course model);
        public void DeleteCourse(int id);
        public void UpdateCourse(int id, Course model);
        public Task<bool> SaveAllAsync();

    }
}