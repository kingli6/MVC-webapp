using College_API.Data;
using College_API.Models;
using College_API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace College_API.Controllers
{
    [Route("api/v1/course")]   //should I name it education?
    public class CollegeController : Controller
    {
        private readonly CourseContext _context;
        public CollegeController(CourseContext context)
        {
            _context = context;
        }

        [HttpGet()]
        //api/v1/course
        public async Task<ActionResult<List<CourseViewModel>>> ListGetCourse()
        {
            var response = await _context.Courses.ToListAsync();
            var courseList = new List<CourseViewModel>();
            foreach (var course in response)
            {
                courseList.Add(
                    new CourseViewModel
                    {
                        CourseId = course.Id,
                        CourseNameNumber = ($"{course.CourseNumber} {course.Name}"),
                        DurationDetail = string.Concat(course.Duration, "hrs ", course.Detail)
                    }
                );
            }
            return Ok(courseList);
        }

        [HttpGet("{id}")]
        //api/v1/course/id
        public async Task<ActionResult<Course>> GetCourseById(int id)
        {
            var response = await _context.Courses.FindAsync(id);
            if (response is null) return NotFound($"CourseID: {id} not found...");
            return Ok(response);
        }
        [HttpGet("coursenumber/{number}")]
        public async Task<ActionResult<Course>> GetCourseByCourseNumber(int number)
        {
            var response = await _context.Courses.SingleOrDefaultAsync(c => c.CourseNumber == number);
            if (response is null) return NotFound($"CourseNr: {number} not found...");
            return Ok(response);
        }
        [HttpPost()]
        public async Task<ActionResult<Course>> AddCourse(PostCourseViewModel course)
        {
            var courseToAdd = new Course
            {
                Name = course.Name,
                CourseNumber = course.CourseNumber,
                Duration = course.Duration,
                Detail = course.Detail
            };
            await _context.Courses.AddAsync(courseToAdd);
            await _context.SaveChangesAsync();
            return StatusCode(201, course);
        }
        // Updates an existing item//204. Don't return Ok 
        [HttpPut("{id}")]
        public async Task<ActionResult<Course>> UpdateCourse(int id, Course model)
        {
            var response = await _context.Courses.FindAsync(id);
            if (response is null) return NotFound($"CourseID: {id} not found...");
            response.Name = model.Name;
            response.CourseNumber = model.CourseNumber;
            response.Duration = model.Duration;
            response.Detail = model.Detail;

            _context.Courses.Update(response);
            await _context.SaveChangesAsync();
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            var response = await _context.Courses.FindAsync(id);
            if (response is null) return NotFound($"CourseID: {id} not found...");
            _context.Courses.Remove(response);
            await _context.SaveChangesAsync();

            return NoContent();/*204*/
        }
    }
}

//Trash
/*
//Status codes
    -return BadRequest(); NotFound();    return StatusCode(200, "{'mess': 'something'}"    
    -NoContent() is StatusCode 204
    -Status Code 201? is in AddCourse
*/
/*
OLD CODE

private readonly ILogger<CollegeController> _logger;

        public CollegeController(ILogger<CollegeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

*/