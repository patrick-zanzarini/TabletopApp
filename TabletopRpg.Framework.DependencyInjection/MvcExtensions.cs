using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Scrutor;
using TabletopRpg.Framework.DependencyInjection.Interfaces;

namespace TabletopRpg.Framework.DependencyInjection
{
    public static class MvcExtensions
    {
        public static void AddTabletopRpgDependencyInjection(this IServiceCollection services)
        {
            var entryAssembly = Assembly.GetEntryAssembly();
            var referencedAssemblies = entryAssembly.GetReferencedAssemblies().Select(Assembly.Load);
            var assemblies = new List<Assembly> {entryAssembly}.Concat(referencedAssemblies);

            services.Scan(sc =>
                sc.FromAssemblies(assemblies)
                    .AddClasses(cl => cl.AssignableTo<ITransientDependency>())
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsMatchingInterface()
                    .WithTransientLifetime()
            );

            services.Scan(sc =>
                sc.FromAssemblies(assemblies)
                    .AddClasses(classes => classes.AssignableTo<ISingletonDependency>())
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsMatchingInterface()
                    .WithSingletonLifetime()
            );
            
            services.Scan(sc =>
                sc.FromAssemblies(assemblies)
                    .AddClasses(classes => classes.AssignableTo<IScopedDependency>())
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsMatchingInterface()
                    .WithScopedLifetime()
            );
        }
    }
}