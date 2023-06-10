using Autofac;
using ECommers.Application.Features.Inventory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Application
{
    public class ApplicationModule : Module
    {
        public ApplicationModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
        }
    }
}
