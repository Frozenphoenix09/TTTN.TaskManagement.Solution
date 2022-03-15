using Autofac;
using System.Reflection;

namespace TTTN.TaskManagement.WebApi.DependencyInjection
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("TTTN.TaskManagement.Data"))
                     .Where(t => t.Name.EndsWith("Repository"))
                     .AsImplementedInterfaces()
                     .InstancePerLifetimeScope();
        }
    }
}
