using ECommers.Application;
using ECommers.Application.Features.Inventory.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Persistence
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        

        public IProductRepository Products {get; private set;}
        public ApplicationUnitOfWork(IApplicationDbContext dbContext,
            IProductRepository courseRepository) : base((DbContext)dbContext)
        {
            Products = courseRepository;
        }
    }
}
