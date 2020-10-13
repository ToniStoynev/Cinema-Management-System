namespace CinemaManagementSystem.Web
{
    using Application.Identity;
    using Services;

    using Microsoft.Extensions.DependencyInjection;
    public static class WebConfiguration
    {
        public static IServiceCollection AddWebComponents(this IServiceCollection services)
        {
            services
                .AddScoped<ICurrentUser, CurrentUserService>()
                .AddControllers()
                .AddNewtonsoftJson();

            return services;
        }
    }
}
