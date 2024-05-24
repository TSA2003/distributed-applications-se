using API.Helpers;
using API.Jwt;
using Data;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Interfaces;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

            builder.Services.AddScoped<StudentsRepository>();
            builder.Services.AddScoped<CoursesRepository>();
            builder.Services.AddScoped<TeachersRepository>();
            builder.Services.AddScoped<UsersRepository>();

            builder.Services.AddScoped<StudentService>();
            builder.Services.AddScoped<CourseService>();
            builder.Services.AddScoped<TeacherService>();
            builder.Services.AddScoped<UserService>();

            builder.Services.AddScoped<JwtUtils>();

            builder.Services.AddDbContext<AppDbContext>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<JwtMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}