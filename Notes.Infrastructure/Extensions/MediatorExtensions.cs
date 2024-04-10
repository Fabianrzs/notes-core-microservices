using Microsoft.Extensions.DependencyInjection;
using Notes.Infrastrunture;
using System.Reflection;
using MediatR;

namespace Notes.Infrastructure.Extensions;

public static class MediatorExtensions
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.Load(ApiConstants.ApplicationProject), Assembly.GetExecutingAssembly());
        return services;
    }
}
