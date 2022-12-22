using College_API.Data;
using College_API.Models;
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
        public async Task<ActionResult<List<Course>>> ListGetCourse()
        {
            var response = await _context.Courses.ToListAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        //api/v1/course/id
        public ActionResult GetCourseById(int id)
        {
            return Ok("{'message': 'Courses by id, empty atm'}");
        }
        [HttpPost()]
        public async Task<ActionResult<Course>> AddCourse(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return StatusCode(201, course);
        }
        // Updates an existing item//204. Don't return Ok 
        [HttpPut("{id}")]
        public ActionResult UpdateCourse(int id)
        {
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteCourse(int id)
        {
            return /*204*/NoContent();
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