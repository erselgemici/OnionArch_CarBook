using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace OnionApp.Application.Extensions
{
    public static class ApplicationRegistrations
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(typeof(ApplicationAssembly).Assembly);
            });

            services.AddValidatorsFromAssembly(typeof(ApplicationAssembly).Assembly);

            return services;
        }
    }
}
