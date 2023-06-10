using ECommers.Domain.Entities;
using ECommers.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Application.Features.Inventory.Repositories
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
        bool IsDuplicateName(string name, Guid? id);
    }
}
