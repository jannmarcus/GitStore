using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoppingStore.Domain.Abstract;
using OnlineShoppingStore.Domain.Entities;

namespace OnlineShoppingStore.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IProductRepository repository;
        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }
        public ActionResult Index()
        {
            return View(repository.Products);
        }
        public ViewResult Create()
        {
            return View(new Product());
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
        public ViewResult Edit(int productID)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productID);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        [HttpPost]
        public ActionResult Delete(int productID)
        {
            Product deleteProduct = repository.DeleteProduct(productID);
            if(deleteProduct != null)
            {
                TempData["message"] = string.Format("{0} has been deleted", deleteProduct.Name);
            }
            return RedirectToAction("Index");
        }
        
    }
}