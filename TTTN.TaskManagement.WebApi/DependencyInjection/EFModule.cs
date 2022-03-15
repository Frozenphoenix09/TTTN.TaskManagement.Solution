using Autofac;
using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;

namespace TTTN.TaskManagement.WebApi.DependencyInjection
{
    public class EFModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());

            builder.RegisterType(typeof(TTTNTaskManagementDbcontext)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}
