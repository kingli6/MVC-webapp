using College_API.Models;
using College_API.ViewModels;

namespace College_API.Interfaces
{
    public interface ICourseRepository
    {
        public Task<List<Course>> ListAllCourseAsync();
        public Task<CourseViewModel?> GetCourseByIdAsync(int id);
        public Task<Course> GetCourseByCourseNumAsync(string courseNumber);
        public Task AddCourseAsync(Course model);
        public void DeleteCourse(int id);
        public void UpdateCourse(int id, Course model);
        public Task<bool> SaveAllAsync();

    }
}