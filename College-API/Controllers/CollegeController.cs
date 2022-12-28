using AutoMapper;
using College_API.Data;
using College_API.Interfaces;
using College_API.Models;
using College_API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace College_API.Controllers
{
    [ApiController]
    [Route("api/v1/course")]   //should I name it education?
    public class CollegeController : Controller
    {
        private readonly ICourseRepository _courseRepo;
        private readonly IMapper _mapper;

        public CollegeController(ICourseRepository courseRepo, IMapper mapper)
        {
            _courseRepo = courseRepo;
            _mapper = mapper;
        }


        [HttpGet()]
        //api/v1/course
        public async Task<ActionResult<List<CourseViewModel>>> ListGetCourse()//How do I make changes everywhere? VSCODE command...
        {
            var courseList = await _courseRepo.ListAllCourseAsync();
            return Ok(courseList);
        }

        [HttpGet("{id}")]
        //api/v1/course/id
        public async Task<ActionResult<Course>> GetCourseById(int id)
        {
            // var response = await _context.Courses.FindAsync(id);
            var response = await _courseRepo.GetCourseByIdAsync(id);
            if (response is null) return NotFound($"CourseID: {id} not found...");

            return Ok(response);
        }

        [HttpGet("coursenumber/{number}")]
        public async Task<ActionResult<Course>> GetCourseByCourseNumber(int number)
        {
            var response = await _courseRepo.GetCourseByCourseNumAsync(number);
            if (response is null) return NotFound($"CourseNr: {number} not found...");
            return Ok(response);
        }

        [HttpGet("coursename/{name}")]
        public async Task<ActionResult<List<CourseViewModel>>> GetCourseByName(string name)
        {
            return Ok(await _courseRepo.GetCourseByNameAsync(name));
        }

        [HttpPost()]
        public async Task<ActionResult> AddCourse(PostCourseViewModel model)
        {

            if (await _courseRepo.GetCourseByCourseNumAsync(model.CourseNumber) is not null)
                return BadRequest($"Course number {model.CourseNumber} already exists.");
            await _courseRepo.AddCourseAsync(model);
            if (await _courseRepo.SaveAllAsync())
                return StatusCode(201);

            return StatusCode(500, "Wasn't able save the course");
        }


        [HttpPut("{id}")]   //THIS DOESN^T WORK 
        public async Task<ActionResult<Course>> UpdateCourse(int id, PostCourseViewModel model)
        {
            try
            {
                await _courseRepo.UpdateCourseAsync(id, model);
                if (await _courseRepo.SaveAllAsync()) return NoContent();

                return StatusCode(500, "An error has occured when trying to update the course.");
            }
            //here we need to return soemthing, since not all code paths return a...
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateCourse(int id, PatchCourseViewModelDetail model)
        {
            try
            {
                await _courseRepo.UpdateCourseAsync(id, model);
                if (await _courseRepo.SaveAllAsync()) return NoContent();

                return StatusCode(500, "An error has occured when trying to update the course.");
            }
            //here we need to return soemthing, since not all code paths return a...
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            await _courseRepo.DeleteCourseAsync(id);   //why is there no need for async/ await?

            if (await _courseRepo.SaveAllAsync()) return NoContent();

            return StatusCode(500, "Couldn't delete the item. Something went wrong.");/*204*/
        }
    }
}

//OLD CODE
/*



[HttpGet()]
        //api/v1/course
        public async Task<ActionResult<List<CourseViewModel>>> ListGetCourse()//How do I make changes everywhere?
        {
            // var response = await _context.Courses.ToListAsync();
            var response = await _courseRepo.ListAllCourseAsync();
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
-----------------------------------------------
    [HttpPost()]
    public async Task<ActionResult<Course>> AddCourse(PostCourseViewModel course)
    {
        var courseToAdd = _mapper.Map<Course>(course);
        await _context.Courses.AddAsync(courseToAdd);
        await _context.SaveChangesAsync();
        return StatusCode(201, courseToAdd);
    }

[HttpPost()] //Adding automapper, so I removed this.
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
-----------------------------------------------------------

[HttpPut("{id}")]   //THIS DOESN^T WORK 
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
----------------------------------------------------------
[HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            var response = await _context.Courses.FindAsync(id);
            if (response is null) return NotFound($"CourseID: {id} not found...");
            _context.Courses.Remove(response);


            return NoContent();//204
        }
*/


//Trash
/*
//Status codes
    -return BadRequest(); NotFound();    return StatusCode(200, "{'mess': 'something'}"    
    -NoContent() is StatusCode 204
    -Status Code 201? is in AddCourse
*/
