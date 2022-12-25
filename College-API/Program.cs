using College_API.Data;
using College_API.Interfaces;
using College_API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Skapa databas koppling
builder.Services.AddDbContext<CourseContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"))
);

// Dependency injection for our own interface and classes.
builder.Services.AddScoped<ICourseRepository, CourseRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
