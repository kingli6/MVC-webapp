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

        public void DeleteCourse(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Course?> GetCourseByIdAsync(int id)
        {
            return await _context.Courses.SingleOrDefaultAsync(c => c.Id == id);
        }

        public Task<Course> GetCourseByCourseNumAsync(string courseNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Course>> ListAllCourseAsync()
        {
            var response = await _context.Courses.ToListAsync();
            return response;
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