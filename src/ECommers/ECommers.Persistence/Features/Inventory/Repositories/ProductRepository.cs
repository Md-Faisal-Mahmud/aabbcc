using ECommers.Application.Features.Inventory.Repositories;
using ECommers.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Persistence.Features.Inventory.Repositories
{
    public class ProductRepository : Repository<Product, Guid>, IProductRepository
    {
        public ProductRepository(IApplicationDbContext context) : base((DbContext)context)
        {
        }

        public bool IsDuplicateName(string name, Guid? id)
        {
            int? existingCourseCount = null;


            if (id.HasValue)
                existingCourseCount = GetCount(x => x.Name == name && x.Id != id.Value);
            else
                existingCourseCount = GetCount(x => x.Name == name);
            return existingCourseCount > 0;
        }

    }
}
