using College_API.Models;
using Microsoft.EntityFrameworkCore;

namespace College_API.Data
{
    // this is for data coupling between database and database memory? 1:49:00, vid 20220427_125937
    public class CourseContext : DbContext
    {
        public DbSet<Course> Courses => Set<Course>(); //Set<> creates an instance. And its not null
        public DbSet<Category> Categories => Set<Category>();
        public CourseContext(DbContextOptions options) : base(options) { }


    }
}