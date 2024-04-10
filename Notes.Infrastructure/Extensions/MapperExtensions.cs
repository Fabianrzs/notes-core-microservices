using Notes.Infrastrunture;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Notes.Infrastructure.Extensions;


public static class AutoMapperExtensions
{
    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.Load(ApiConstants.ApplicationProject));
        return services;
    }
}