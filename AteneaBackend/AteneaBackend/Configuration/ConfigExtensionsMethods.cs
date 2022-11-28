using AteneaBackend.Businesslayer.Interfaces;
using AteneaBackend.Businesslayer.Services;
using AteneaBackend.Datalayer.Context;
using Microsoft.EntityFrameworkCore;

namespace AteneaBackend.Configuration
{
    public static class ConfigExtensionsMethods
    {
        public static void ConfigureDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MainBDContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MainDB"));
            });
        }

        public static void ConfigureInjections(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<IAuthService, AuthService>();
        }

        public static void ConfigureAutoMapper(this IServiceCollection service)
        {
            var mainAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(c => c.GetName().Name == "AteneaBackend.Businesslayer");
            service.AddAutoMapper(mainAssembly);
        }
    }
}
