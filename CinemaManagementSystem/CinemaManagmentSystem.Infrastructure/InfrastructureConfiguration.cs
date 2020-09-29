using CinemaManagementSystem.Application.Common.Contracts;

namespace CinemaManagementSystem.Infrastructure
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Common.Persistence;
    using Microsoft.EntityFrameworkCore;
    using Domain.Common;


    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDatabase(configuration)
                .AddTransient(typeof(IRepository<>), typeof
                    (DataRepository<>));

        private  static  IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDbContext<CinemaManagementSystemDbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(CinemaManagementSystemDbContext).Assembly.FullName)));

        //private static IServiceCollection AddRepositories(this IServiceCollection services)
        //    => services
        //        .Scan(scan => scan
        //            .FromCallingAssembly()
        //            .AddClasses(classes => classes
        //                .AssignableTo(typeof(IDomainRepository<>)))
        //            .AsMatchingInterface()
        //            .WithTransientLifetime());

    }
}
