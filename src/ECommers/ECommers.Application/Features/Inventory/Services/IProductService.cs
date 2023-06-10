using ECommers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Application.Features.Inventory.Services
{
    public interface IProductService
    {
        void CreateProduct(string name, double fees);
        void DeleteProduct(Guid id);
        Task<(IList<Product> records, int total, int totalDisplay)> GetPagedProductsAsync(int pageIndex,
            int pageSize, string searchText, string orderBy);
        Product GetProduct(Guid id);
        public IList<Product> GetProducts();
        void UpdateProduct(Guid id, string name, double price);
    }
}
