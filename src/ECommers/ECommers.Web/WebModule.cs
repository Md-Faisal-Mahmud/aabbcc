using Autofac;
using ECommers.Application.Features.Inventory.Repositories;
using ECommers.Persistence.Features.Inventory.Repositories;
using ECommers.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using NuGet.Protocol.Core.Types;

namespace ECommers.Web
{
    public class WebModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public WebModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductListModel>().AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductCreateModel>().AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductUpdateModel>().AsSelf()
                .InstancePerLifetimeScope();


            base.Load(builder);
        }
    }
}
