# MVC-webapp

### TODO TOYellowDuck
- Possible null reference argument for parameter 'connectionString' in 'DbContextOptionsBuilder SqliteDbContextOptionsBuilderExtensions.UseSqlite(DbContextOptionsBuilder optionsBuilder, string connectionString, Action<SqliteDbContextOptionsBuilder>? sqliteOptionsAction = null)'. [College-API]
  - Null referense on program.cs Not sure how to fix it.
  
  builder.Services.AddDbContext<CourseContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"))
);

- Naming Course differently? Class model and other areas have singular course. 
  But in CourseContext class, I use Courses, and it's confusing. I'm changing it to CourseDbSet for now.
- How do change the page to https from http
-I can't create data through PUT method in postman, but it works on Swagger...
  
