using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZG.Store.Application;
using ZG.Store.Presentation.ViewModels;

namespace ZG.Store.Presentation.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        private int _pageSize = 4;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        public ViewResult List(string category, int page = 1)
        {
            var porductsPerPage = _productService.GetProducts(category, page, _pageSize);

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

    }
}
