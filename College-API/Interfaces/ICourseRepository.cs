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
        public Task DeleteCourse(int id);
        public Task UpdateCourse(int id, PostCourseViewModel model);
        public Task<bool> SaveAllAsync();

    }
}