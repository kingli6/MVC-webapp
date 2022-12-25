using AutoMapper;
using College_API.Models;
using College_API.ViewModels;

namespace College_API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        protected AutoMapperProfiles()
        {
            // Map från -> till
            CreateMap<PostCourseViewModel, Course>();
            CreateMap<Course, CourseViewModel>();
        }
    }
}