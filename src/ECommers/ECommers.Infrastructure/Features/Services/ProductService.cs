
using ECommers.Application;
using ECommers.Application.Features.Inventory.Services;
using ECommers.Domain.Entities;
using ECommers.Infrastructure.Features.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Infrastructure.Features.Services
{
    public class ProductService : IProductService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        public ProductService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


          
        public IList<Product> GetProducts()
        {
            return _unitOfWork.Products.GetAll();
        }

        public async Task<(IList<Product> records, int total, int totalDisplay)> GetPagedProductsAsync(int pageIndex,
            int pageSize, string searchText, string orderBy)
        {
            return await Task.Run(() =>
            {
                var result = _unitOfWork.Products.GetDynamic(x => x.Name.Contains(searchText),
                orderBy, string.Empty, pageIndex, pageSize, true);

                return result;
            });
        }

        public void CreateProduct(string name, double price)
        {
            
            if (_unitOfWork.Products.IsDuplicateName(name, null))
            {
                throw new DuplicateNameException("Product name is duplicate");
            }

            Product product = new Product()
            {
                Name = name,
                Price = price
            };
            _unitOfWork.Products.Add(product);
            _unitOfWork.Save();


        }

        public void UpdateProduct(Guid id, string name, double price)
        {
             if (_unitOfWork.Products.IsDuplicateName(name, id))
                throw new DuplicateNameException("Product name is duplicate");

            Product product = _unitOfWork.Products.GetById(id);
            product.Name = name;
            product.Price = price;

            _unitOfWork.Save();
        }

        public Product GetProduct(Guid id)
        {
            return _unitOfWork.Products.GetById(id);
        }


        public void DeleteProduct(Guid id)
        {
            _unitOfWork.Products.Remove(id);
            _unitOfWork.Save();
        }
    }
}
