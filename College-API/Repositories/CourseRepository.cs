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
        public async Task DeleteCourseAsync(int id) //why is there no need for async/ await?  A. Because Remove doesn't have a async in dbcontext...
        {
            var response = await _context.Courses.FindAsync(id);
            if (response is not null) _context.Courses.Remove(response);
        }
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<List<CourseViewModel>> ListAllCourseAsync()
        {
            return await _context.Courses.ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<CourseViewModel>> GetCourseByNameAsync(string name)
        {
            return await _context.Courses
            .Where(c => c.Name!.ToLower() == name.ToLower())
            .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }
        public async Task<CourseViewModel?> GetCourseByIdAsync(int id)
        {
            return await _context.Courses.Where(c => c.Id == id)
            .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public async Task<CourseViewModel?> GetCourseByCourseNumAsync(int courseNumber)
        {
            return await _context.Courses.Where(c => c.CourseNumber == courseNumber)
           .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }


        public async Task AddCourseAsync(PostCourseViewModel model)
        {
            var courseToAdd = _mapper.Map<Course>(model);
            await _context.Courses.AddAsync(courseToAdd);
        }
        public async Task UpdateCourseAsync(int id, PostCourseViewModel model)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course is null)
                throw new Exception($"We couldn't add the requested Course with id: {id}");

            course.CourseNumber = model.CourseNumber;
            course.Name = model.Name;
            course.Duration = model.Duration;
            course.Detail = model.Detail;
            _context.Courses.Update(course);

        }
        public async Task UpdateCourseAsync(int id, PatchCourseViewModelDetail model)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course is null)
                throw new Exception($"We couldn't add the requested Course with id: {id}");

            course.Detail = model.Detail;
            _context.Courses.Update(course);

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


// code without automapper Get by course number
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
*/