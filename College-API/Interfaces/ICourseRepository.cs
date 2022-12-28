using College_API.Models;
using College_API.ViewModels;

namespace College_API.Interfaces
{
    public interface ICourseRepository
    {
        public Task<List<CourseViewModel>> ListAllCourseAsync();
        public Task<CourseViewModel?> GetCourseByIdAsync(int id);
        public Task<CourseViewModel?> GetCourseByCourseNumAsync(int courseNumber);
        public Task AddCourseAsync(PostCourseViewModel model);
        public void DeleteCourse(int id);
        public void UpdateCourse(int id, Course model);
        public Task<bool> SaveAllAsync();

    }
}