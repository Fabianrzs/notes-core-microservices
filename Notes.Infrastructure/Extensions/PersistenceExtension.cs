using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Notes.Infrastructure.Adapters;
using Notes.Domain.Ports;
using Microsoft.EntityFrameworkCore;
using Notes.Infrastructure.Context;

namespace Notes.Infrastructure.Extensions {

    public static class PersistenceExtension {
        public static IServiceCollection AddPesistence(this IServiceCollection svc, IConfiguration config)
        {
            svc.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            svc.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return svc;
        }
    }
}