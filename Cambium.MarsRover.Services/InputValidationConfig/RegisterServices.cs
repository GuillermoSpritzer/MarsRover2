using Cambium.MarsRover.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Cambium.MarsRover.Services
{
    public static class RegisterServices
    {
        public static IServiceCollection ConfigureMarsRoverServices<TServiceConfiguration>(
            this IServiceCollection services)
            where TServiceConfiguration : class, IInputConfiguration
        {
            services.AddSingleton<IInputConfiguration, TServiceConfiguration>();
            services.AddSingleton<IPlateauFactory, PlateauFactory>();
            services.AddSingleton<IRoverFactory, RoverFactory>();
            services.AddTransient<INavigationService, NavigationService>();
            services.AddTransient<IInputValidator, InputValidator>();
            return services;
        }
    }
}