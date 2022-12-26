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
            CreateMap<PostCourseViewModel, Course>();   // Q. for post function? A.Yes

            CreateMap<Course, CourseViewModel>()
            .ForMember(dest => dest.CourseId, options => options.
            MapFrom(src => src.Id))
            .ForMember(dest => dest.CourseNameNumber, options => options.
            MapFrom(dest => string.Concat(dest.CourseNumber, " ", dest.Name)))
            .ForMember(src => src.DurationDetail, options => options.
            MapFrom(dest => string.Concat(dest.Duration, "hrs \n", dest.Detail)));

        }
    }
}