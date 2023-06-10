using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Application.Features.Inventory.Services
{
    public interface IProductRegistrationService
    {
        public void Register(string sellerId, string productId);
    }
}
