using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Domain.Entities
{
    public class Product : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
