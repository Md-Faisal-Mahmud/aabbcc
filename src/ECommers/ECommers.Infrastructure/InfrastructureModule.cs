using Autofac;
using ECommers.Application.Features.Inventory.Services;
using ECommers.Infrastructure.Features.Services;

namespace ECommers.Infrastructure
{
    public class InfrastructureModule : Module
    {
        public InfrastructureModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>().As<IProductService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
