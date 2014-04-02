using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZG.Application;
using ZG.Domain.Models;

namespace ZG.Store.Admin.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductService _prodService;
        public ProductController(IProductService prodService)
        {
            _prodService = prodService;
        }
        //
        // GET: /Product/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            var prods = _prodService.GetActiveProducts(null, 1, 500);
            return Json(prods, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Product/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Product/Edit/5
        public JsonResult Edit(int id)
        {
            var prod = _prodService.GetProductById(id);
            return Json(prod, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(Product prod)
        {
            foreach(string fileName in Request.Files)
            {
                var file = Request.Files[fileName];
                if(file.ContentLength > 0)
                {
                    var prodImage = new ProductImage { ProductId = prod.Id, ImageMimeType = file.ContentType, ImageData = new byte[file.ContentLength] };
                    file.InputStream.Read(prodImage.ImageData, 0, file.ContentLength);

                    prod.ProductImages.Add(prodImage);
                }
            }

            _prodService.Update(prod);
            return Json(new { Message = "Product saved successfully." }, JsonRequestBehavior.AllowGet); 
        }

        //
        // GET: /Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
