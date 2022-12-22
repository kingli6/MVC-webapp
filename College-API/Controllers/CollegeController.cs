using Microsoft.AspNetCore.Mvc;

namespace College_API.Controllers
{
    [Route("api/v1/course")]   //should I name it education?
    public class CollegeController : Controller
    {
        [HttpGet()]
        //api/v1/course
        public ActionResult ListGetCourse(){
            return StatusCode(200, "{'message': 'List of courses, currently empty'}");
        }
        [HttpGet("{id}")]
        //api/v1/course/id
        public ActionResult GetCourseById(int id){
            return Ok("{'message': 'Courses by id, empty atm'}");
        }
        [HttpPost()]
        public ActionResult AddCourse(){
            return StatusCode(201, "{'message': 'save new course to database. not available atm'}");
        }
        // Updates an existing item//204. Don't return Ok 
        [HttpPut("{id}")]
        public ActionResult UpdateCourse(int id){
            return NoContent(); 
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteCourse(int id){
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