using KwikMedical_Server.Data;
using KwikMedical_Server.Repositories;
using KwikMedical_Server.Services;
using Microsoft.EntityFrameworkCore;

namespace KwikMedical_Server
{
    /// <summary>
    /// Entry point of the application and configuration of middleware, services, and dependency injection.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method to build, configure, and run the application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            // Create a new instance of the WebApplication builder.
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the DI (Dependency Injection) container.
            builder.Services.AddControllers(); // Registers the controllers for handling HTTP requests.

            // Enable Swagger/OpenAPI for API documentation and testing.
            builder.Services.AddEndpointsApiExplorer(); // Enables API endpoints discovery.
            builder.Services.AddSwaggerGen(); // Adds Swagger generation for API documentation.

            // Register the database context with SQL Server configuration.
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            // Register repositories for dependency injection.
            builder.Services.AddScoped<IPatientRepository, PatientRepository>(); // Resolves patient repository.
            builder.Services.AddScoped<IAmbulanceRecordRepository, AmbulanceRecordRepository>(); // Resolves ambulance record repository.

            // Register services for dependency injection.
            builder.Services.AddScoped<IPatientService, PatientService>(); // Resolves patient service.
            builder.Services.AddScoped<IAmbulanceRecordService, AmbulanceRecordService>(); // Resolves ambulance record service.

            // Build the WebApplication object.
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // Enable Swagger UI for API exploration during development.
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection(); // Enforce HTTPS for all incoming requests.

            app.UseAuthorization(); // Add default authorization middleware.

            app.MapControllers(); // Map controllers to routes.

            // Run the application.
            app.Run();
        }
    }
}

