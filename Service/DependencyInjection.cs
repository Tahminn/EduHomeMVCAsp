using Microsoft.Extensions.DependencyInjection;
using Service.Account;
using Service.BaseModels;
using Service.Interfaces;
using Service.Setting;

namespace Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<ITeacherService, TeacherService>();

            return services;
        }
    }
}
