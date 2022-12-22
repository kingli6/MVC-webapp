using College_API.Models;
using Microsoft.EntityFrameworkCore;

namespace College_API.Data
{
    // this is for data coupling between database and database memory? 1:49:00
    public class CourseContext : DbContext
    {
        public DbSet<Course> Courses => Set<Course>(); //Set<> creates an instance. And its not null
        public CourseContext(DbContextOptions options) : base(options){}

    
    }
}