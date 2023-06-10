using ECommers.Application.Features.Inventory.Repositories;
using ECommers.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Application
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        IProductRepository Products { get;  }
    }
}
