using AutoMapper;
using AutoMapper.QueryableExtensions;
using College_API.Data;
using College_API.Interfaces;
using College_API.Models;
using College_API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace College_API.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseContext _context;
        private readonly IMapper _mapper;

        public CourseRepository(CourseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task AddCourseAsync(Course model)
        {
            throw new NotImplementedException();
        }

        public void DeleteCourse(int id) //why is there no need for async/ await?  A. Because Remove doesn't have a async in dbcontext...
        {
            var response = _context.Courses.Find(id);
            if (response is not null) _context.Courses.Remove(response);
        }

        public async Task<CourseViewModel?> GetCourseByIdAsync(int id)
        {
            return await _context.Courses.Where(c => c.Id == id)
            .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public async Task<CourseViewModel?> GetCourseByCourseNumAsync(int courseNumber)
        {
            return await _context.Courses.Where(c => c.CourseNumber == courseNumber)
            .Select(course => new CourseViewModel
            {
                CourseId = course.Id,
                CourseNameNumber = ($"{course.CourseNumber} {course.Name}"),
                DurationDetail = string.Concat(course.Duration, "hrs ", course.Detail)
            }).SingleOrDefaultAsync();
        }

        public async Task<List<Course>> ListAllCourseAsync()
        {
            var response = await _context.Courses.ToListAsync();
            return response;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateCourse(int id, Course model)
        {
            throw new NotImplementedException();
        }
    }
}

//Old code
/*



public async Task<CourseViewModel?> GetCourseByIdAsync(int id)
        {
            return await _context.Courses.Where(c => c.Id == id)
            .Select(course => new CourseViewModel
            {
                CourseId = course.Id,
                CourseNameNumber = ($"{course.CourseNumber} {course.Name}"),
                DurationDetail = string.Concat(course.Duration, "hrs ", course.Detail)
            }).SingleOrDefaultAsync();
        }
*/