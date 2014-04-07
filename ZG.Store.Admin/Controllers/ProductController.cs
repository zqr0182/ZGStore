using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZG.Application;
using ZG.Domain.Models;
using Newtonsoft.Json;
using ZG.Common;
using ZG.Store.Admin.App_Code;
using ZG.Domain.DTO;

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
            string dirPath = PathUtil.GetProductImageDirectory(id);
            var viewModel = _prodService.GetProductEditViewModel(prod, dirPath);

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(string prod)
        {
            var product = JsonConvert.DeserializeObject<ProductEditViewModel>(prod);

            if(!TryUpdateModel(product))
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                return Json(new { Success = false, Errors = errors }, JsonRequestBehavior.DenyGet); 
            }

            string dirPath = PathUtil.GetProductImageDirectory(product.Id);
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
            return Json(new { Success = true }, JsonRequestBehavior.AllowGet); 
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

        [HttpDelete]
        public JsonResult DeleteImage(int prodId, string imageName)
        {
            try
            {
                string dirPath = PathUtil.GetProductImageDirectory(prodId);
                string path = dirPath + "\\" + imageName;

                _fileService.DeleteFile(path);
                var fileNames = _fileService.GetFileNames(dirPath);

                return Json(new { Success = true, Images = fileNames }, JsonRequestBehavior.AllowGet); 
            }
            catch(Exception ex)
            {
                //TODO: log
                return Json(new {Success = false, Error = "Error occured, unable to delete image. We are fixing it." }, JsonRequestBehavior.DenyGet);
            }
        }

        private void ValidateProduct(Product prod)
        {
            if(string.IsNullOrWhiteSpace(prod.ProductName))
            {
                ModelState.AddModelError("", "Please enter product name");
            }
        }
    }
}
