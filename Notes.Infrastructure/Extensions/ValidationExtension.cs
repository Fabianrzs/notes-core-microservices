using Notes.Infrastrunture.Adapters;
using Notes.Infrastrunture;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Notes.Infrastructure.Extensions;

public static class ValidationExtension
{
    public static IServiceCollection AddValidator(this IServiceCollection services)
    {
        Assembly validationAssembly = Assembly.Load(ApiConstants.ApplicationProject);
        services.AddValidatorsFromAssembly(validationAssembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}
