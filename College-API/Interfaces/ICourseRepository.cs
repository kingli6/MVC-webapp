using College_API.Models;
using College_API.ViewModels;

namespace College_API.Interfaces
{
    public interface ICourseRepository
    {
        public Task<List<CourseViewModel>> ListAllCourseAsync();
        public Task<List<CourseViewModel>> GetCourseByNameAsync(string name);
        public Task<CourseViewModel?> GetCourseByIdAsync(int id);
        public Task<CourseViewModel?> GetCourseByCourseNumAsync(int courseNumber);
        public Task AddCourseAsync(PostCourseViewModel model);
        public Task DeleteCourseAsync(int id);
        public Task UpdateCourseAsync(int id, PostCourseViewModel model);
        public Task UpdateCourseAsync(int id, PatchCourseViewModelDetail model);
        public Task<bool> SaveAllAsync();

    }
}