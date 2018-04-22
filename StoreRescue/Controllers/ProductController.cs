using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreRescue.Models;
using StoreRescue.Repositories;
using Microsoft.AspNetCore.Http;

namespace StoreRescue.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository RepProd;
        ICategoryRepository RepCat;

        public ProductController(IProductRepository repProd, ICategoryRepository repCat)
        {
            RepProd = repProd;
            RepCat = repCat;
        }

        public ViewResult Edit(int ProductID)
        {
            IEnumerable<Category> Cats = RepCat.Categories;

            var catlist = from cat in Cats select cat;

            SelectList categoryList = new SelectList(catlist, "CategoryID", "CategoryName");

            ViewBag.CategoryList = categoryList;
            Product product = RepProd.Products.FirstOrDefault(p => p.ProductID == ProductID);
            return View(product);
        }

        public ViewResult Index()
        {
            HttpContext.Session.SetString("UserID", "1");

            return View(RepProd.Products);
        }
        [HttpPost]
        public IActionResult Delete(int ProductID)
        {
            if (ModelState.IsValid)
            {
                Product _prod = RepProd.RemoveProduct(ProductID);
                if (_prod != null)
                {
                    TempData["message"] = $"{_prod.ProductName} has been deleted";
                }
                else
                {
                    TempData["message"] = $"No product to delete";
                }
                return RedirectToAction("Index");
            }
            else
            { return RedirectToAction("Index"); }
        }
        public ViewResult Create ()
        {
            IEnumerable<Category> Cats = RepCat.Categories;

            var catlist = from cat in Cats select cat;

            SelectList categoryList = new SelectList(catlist, "CategoryID", "CategoryName");

            ViewBag.CategoryList = categoryList;
            return View("Edit", new Product());
        }
        
        [HttpPost]
        public IActionResult Edit(Product product) {
            if (ModelState.IsValid)
            {
                product.ModifiedUserID = int.Parse(HttpContext.Session.GetString("UserID"));
                RepProd.SaveProduct(product);
                TempData["message"] = $"{product.ProductName} has been saved";
                return RedirectToAction("Index");
            }
            else
            { return View(product); }
        }


        
    }
}