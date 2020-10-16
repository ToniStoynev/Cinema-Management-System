﻿using CinemaManagementSystem.Domain.CinemasManagement.Models.Cinemas;

namespace CinemaManagementSystem.Domain
{
    using Microsoft.Extensions.DependencyInjection;
    using Common;

    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
            => services
                .AddFactories()
                .AddInitialData();


        private static IServiceCollection AddFactories(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IFactory<>)))
                    .AsMatchingInterface()
                    .WithTransientLifetime());
        private static IServiceCollection AddInitialData(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IInitialData)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());

    }
}
