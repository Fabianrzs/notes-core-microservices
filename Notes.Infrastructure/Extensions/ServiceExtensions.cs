using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Notes.Domain.Services.Base;

namespace Notes.Infrastructure.Extensions
{

    public static class ServiceExtensions {
        public static IServiceCollection AddDomainServices(this IServiceCollection svc)
        {
            var assemblyNames = new List<string> { "Notes.Domain.dll" };
            var _services = new List<Type>();
            string baseDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            assemblyNames.ForEach(assemblyName =>
            {
                string assemblyPath = Path.Combine(baseDirectory, assemblyName);
                Assembly assembly = Assembly.LoadFrom(assemblyPath);

                _services.AddRange(assembly.GetTypes()
                    .Where(p => p.CustomAttributes.Any(x => x.AttributeType == typeof(DomainServiceAttribute)))
                );
            });


            _services.ForEach(serviceType => svc.AddTransient(serviceType));

            return svc;
        }
    }
}
