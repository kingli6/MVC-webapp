using College_API.Data;
using College_API.Interfaces;
using College_API.Models;
using Microsoft.EntityFrameworkCore;

namespace College_API.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseContext _context;

        public CourseRepository(CourseContext context)
        {
            _context = context;
        }

        public Task AddCourseAsync(Course model)
        {
            throw new NotImplementedException();
        }

        public void DeleteVehicle(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetCourseAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetCourseAsync(string courseNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Course>> ListAllCourseAsync()
        {
            var response = await _context.Courses.ToListAsync();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateCourse(int id, Course model)
        {
            throw new NotImplementedException();
        }
    }
}