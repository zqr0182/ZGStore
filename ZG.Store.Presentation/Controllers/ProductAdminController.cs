using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using ZG.Application;
using ZG.Store.Presentation.ViewModels;

namespace ZG.Store.Presentation.Controllers
{
    [Authorize(Roles="Admin")]
    public class ProductAdminController : Controller
    {
        private IProductService _productService;

        private int _pageSize = 2;

        public ProductAdminController(IProductService productService)
        {
            _productService = productService;
        }

        public ViewResult List(string category, int page = 1)
        {
            var porductsPerPage = _productService.GetActiveProducts(category, page, _pageSize);

            var productListViewModel = new ProductListViewModel
            {
                Products = porductsPerPage.Products,
                CurrentPageNum = page,
                RecordsPerPage = _pageSize,
                TotalPages = (int)Math.Ceiling((decimal)porductsPerPage.TotalProducts / _pageSize),
                CurrentCategory = category
            };


            return View(productListViewModel);
        }

        public ViewResult Edit(int id)
        {
            var prod = _productService.GetProductById(id);

            return View(prod);
        }
    }
}
