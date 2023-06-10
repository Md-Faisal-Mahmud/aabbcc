using Autofac;
using ECommers.Application.Features.Inventory.Services;
using System.ComponentModel.DataAnnotations;

namespace ECommers.Web.Areas.Admin.Models
{
    public class ProductCreateModel
    {
        [Required]      // data annotation
        public string Name { get; set; }
        [Required, Range(0, 50000, ErrorMessage = "Price should be between 0 & 50000")]
        public double Price { get; set; }

        private IProductService _productService;
        public ProductCreateModel()
        {

        }
        public ProductCreateModel(IProductService productService)
        {

        }

        internal void ResolveDependency(ILifetimeScope scope)
        {
            _productService = scope.Resolve<IProductService>();
        }

        internal void CreateProduct()
        {
           if(!string.IsNullOrWhiteSpace(Name) && Price >= 0)
            {
                _productService.CreateProduct(Name, Price);
            }
        }
    }
}
