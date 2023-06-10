using Autofac;
using ECommers.Application.Features.Inventory.Services;
using ECommers.Domain.Entities;
using ECommers.Infrastructure;

namespace ECommers.Web.Areas.Admin.Models
{
    public class ProductListModel
    {
        private readonly IProductService _productService;
        public ProductListModel()
        {

        }
        public ProductListModel(IProductService productService)
        {
            _productService = productService;
        }

        public IList<Product> GetPopularProducts()
        {
            return _productService.GetProducts();
        }

        public async Task<object> GetPagedProductsAsync(DataTablesAjaxRequestUtility dataTablesUtility)
        {
            var data = await _productService.GetPagedProductsAsync(
                dataTablesUtility.PageIndex,
                dataTablesUtility.PageSize,
                dataTablesUtility.SearchText,
                dataTablesUtility.GetSortText(new string[] { "Name", "Price" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Name,
                                record.Price.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        internal void DeleteProduct(Guid id)
        {
            _productService.DeleteProduct(id);
        }



    }
}
