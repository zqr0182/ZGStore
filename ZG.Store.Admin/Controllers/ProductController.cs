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
using Castle.Core.Logging;

namespace ZG.Store.Admin.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductService _prodService;
        readonly IFileService _fileService;
        readonly ILogger _logger;
        public ProductController(IProductService prodService, IFileService fileService, ILogger logger)
        {
            _prodService = prodService;
            _fileService = fileService;
            _logger = logger;
        }

        public JsonResult List(string filterByStatus)
        {
            bool isActive = (string.Compare(filterByStatus, "active", true) == 0) ? true : false;
            var prods = _prodService.GetProducts(null, isActive, 1, 500);
            return Json(prods, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(string prod)
        {
            return UpsertProduct(prod);   
        }

        public JsonResult Edit(int id)
        {
            try
            {
                var prod = _prodService.GetProductById(id, new string[] { "ProductCategories.Category", "Inventories.Supplier" });
                string dirPath = PathUtil.GetProductImageDirectory(id);
                var viewModel = _prodService.GetProductEditViewModel(prod, dirPath);
                
                return Json(viewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to get product: {0}", id);
                return Json(new { Success = false, Errors = "Error occured, unable to get product. We are fixing it." }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Edit(string prod)
        {
            return UpsertProduct(prod);            
        }

        [HttpDelete]
        public JsonResult Deactivate(int id)
        {
            try
            {
                _prodService.Deactivate(id);

                return Json(new { Success = true}, JsonRequestBehavior.DenyGet);
            }
            catch(Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to deactivate product {0}", id);
                return Json(new { Success = false, Error = "Error occured, unable to deactivate product. We are fixing it." }, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpPost]
        public JsonResult Activate(int id)
        {
            try
            {
                _prodService.Activate(id);

                return Json(new { Success = true }, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to activate product {0}", id);
                return Json(new { Success = false, Error = "Error occured, unable to activate product. We are fixing it." }, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpDelete]
        public JsonResult DeleteImage(int id, string imageName)
        {
            try
            {
                string dirPath = PathUtil.GetProductImageDirectory(id);
                string path = dirPath + "\\" + imageName;

                _fileService.DeleteFile(path);
                var fileNames = _fileService.GetFileNames(dirPath, ImageFileNamePatterns.Patterns);

                return Json(new { Success = true, Images = fileNames }, JsonRequestBehavior.DenyGet); 
            }
            catch(Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to delete product image. Product id {0}, image name: {1}", id, imageName);
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

        private JsonResult UpsertProduct(string prod)
        {
            try
            {
                var productEditViewModel = JsonConvert.DeserializeObject<ProductEditViewModel>(prod);
               
                if (!TryUpdateModel(productEditViewModel))
                {
                    var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                    return Json(new { Success = false, Errors = errors }, JsonRequestBehavior.DenyGet);
                } 
                
                var isUpdate = productEditViewModel.Id > 0 ? true : false;

                Product product = null;
                if (isUpdate)
                {
                    product = _prodService.Update(productEditViewModel);
                }
                else
                {
                    product = _prodService.Create(productEditViewModel);
                }

                string dirPath = PathUtil.GetProductImageDirectory(product.Id);
                _fileService.CreateDirectory(dirPath);

                foreach (string fileName in Request.Files)
                {
                    var postedFile = Request.Files[fileName];
                    if (postedFile.ContentLength > 0)
                    {
                        string path = dirPath + "\\" + postedFile.FileName;
                        postedFile.SaveAs(path);
                    }
                }

                return Json(new { Success = true }, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to upsert product: {0}", prod);
                return Json(new { Success = false, Errors = new []{"Error occured. Unable to upsert product. We are fixing it."} }, JsonRequestBehavior.DenyGet);
            }
        }
    }
}
