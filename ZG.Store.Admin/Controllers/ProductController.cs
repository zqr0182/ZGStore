using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZG.Application;
using ZG.Domain.Models;
using Newtonsoft.Json;

namespace ZG.Store.Admin.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductService _prodService;
        readonly IFileService _fileService;
        public ProductController(IProductService prodService, IFileService fileService)
        {
            _prodService = prodService;
            _fileService = fileService;
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
        public JsonResult Edit(string prod)
        {
            var product = JsonConvert.DeserializeObject<Product>(prod);

            string dirPath = Server.MapPath(string.Format("~/ProdImages/{0}", product.Id));
            _fileService.CreateDirectory(dirPath);

            foreach(string fileName in Request.Files)
            {
                var postedFile = Request.Files[fileName];
                if (postedFile.ContentLength > 0)
                {
                    string path = dirPath + "\\" + postedFile.FileName;
                    postedFile.SaveAs(path);
                }
            }

            _prodService.Update(product);
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
