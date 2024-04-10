using Notes.Infrastructure.Context;
using Notes.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Notes.Infrastrunture;

public static class Startup
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddMediator();
        services.AddDomainServices();
        services.AddPesistence(config);
        services.AddValidator();
        services.AddMapper();
        services.AddSwaggers();
    }

    public static void UseInfrastructure(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwaggers(env);
        app.UseExceptionMiddleware();
        app.UseAuthentication();
        app.UseAuthorization();
        using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
        InitializeDatabase(scope);
    }

    private static void InitializeDatabase(IServiceScope scope)
    {
        if (scope == null) return;
        MigrateDbContextExtensions.MigrateDbContextServices<AppDbContext>(scope);
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        if (!context.Database.CanConnect()) return;
    }
}
