using AutoMapper;
using College_API.Models;
using College_API.ViewModels;

namespace College_API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Map från -> till
            CreateMap<PostCourseViewModel, Course>();   // for post function?
            CreateMap<Course, CourseViewModel>();
        }
    }
}