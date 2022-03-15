using Autofac;
using System.Reflection;
namespace TTTN.TaskManagement.WebApi.DependencyInjection
{
    public class ServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("TTTN.TaskManagement.Services"))
                      .Where(t => t.Name.EndsWith("Services"))
                      .AsImplementedInterfaces()
                      .InstancePerLifetimeScope();
        }
    }
}
