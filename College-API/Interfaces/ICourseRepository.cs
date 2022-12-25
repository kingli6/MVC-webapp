using College_API.Models;

namespace College_API.Interfaces
{
    public interface ICourseRepository
    {
        public Task<List<Course>> ListAllCourseAsync();
        public Task<Course> GetCourseAsync(int id);
        public Task<Course> GetCourseAsync(string courseNumber);
        public Task AddCourseAsync(Course model);
        public void DeleteVehicle(int id);
        public void UpdateCourse(int id, Course model);
        public Task<bool> SaveAllAsync();

    }
}