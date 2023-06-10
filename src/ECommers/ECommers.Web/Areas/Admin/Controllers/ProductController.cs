using Autofac;
using ECommers.Infrastructure;
using ECommers.Infrastructure.Features.Exceptions;
using ECommers.Web.Areas.Admin.Models;
using ECommers.Web.Models;
using ECommers.Web.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace ECommers.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        ILifetimeScope _scope;
        ILogger<ProductController> _logger;
        public ProductController(ILifetimeScope scope, ILogger<ProductController> logger)
        {
            _scope = scope;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var model = _scope.Resolve<ProductListModel>();
            return View(model);
        }
        public IActionResult Create()
        {
            var model = _scope.Resolve<ProductCreateModel>();

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(ProductCreateModel model)
        {
            model.ResolveDependency(_scope);
            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateProduct();
                    TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    {
                        Message = "Successfully added a new product.",
                        Type = ResponseTypes.Success
                    });
                    return RedirectToAction("Index");
                }
                catch (DuplicateNameException ex)
                {
                    _logger.LogError(ex, ex.Message);
                    TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    {
                        Message = ex.Message,
                        Type = ResponseTypes.Danger
                    });
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Server Error");
                    TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    {
                        Message = "There was a problem in creating product.",
                        Type = ResponseTypes.Danger
                    });
                }
            }

            return View(model);
        }


        public IActionResult Update(Guid id)
        {
            var model = _scope.Resolve<ProductUpdateModel>();
            model.Load(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Update(ProductUpdateModel model)
        {
            model.ResolveDependency(_scope);

            if (ModelState.IsValid)
            {
                try
                {
                    model.UpdateProduct();
                    return RedirectToAction("Index");
                }
                catch (DuplicateNameException ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Server Error");
                }
            }

            return View(model);
        }



        public IActionResult Delete(Guid id)
        {
            var model = _scope.Resolve<ProductListModel>();

            if (ModelState.IsValid)
            {
                try
                {
                    model.DeleteProduct(id);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Server Error");
                }
            }

            return RedirectToAction("Index");
        }




        public async Task<JsonResult> GetProducts()
        {
            var dataTablesModel = new DataTablesAjaxRequestUtility(Request);
            var model = _scope.Resolve<ProductListModel>();
            
            var data = await model.GetPagedProductsAsync(dataTablesModel);
            return Json(data);
        }
    }
}
