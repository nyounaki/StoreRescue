using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreRescue.Models;
using StoreRescue.Repositories;

namespace StoreRescue.Controllers
{
    public class CategoryController : Controller
    {
        
        ICategoryRepository RepCat;

        public CategoryController(ICategoryRepository repCat)
        {
            
            RepCat = repCat;
        }

        public ViewResult Edit(int CategoryID)
        {
            
            Category cat = RepCat.Categories.FirstOrDefault(c => c.CategoryID == CategoryID);
            return View(cat);
        }

        public ViewResult Index()
        {

            return View(RepCat.Categories);
        }
        [HttpPost]
        public IActionResult Delete(int CategoryID)
        {
            if (ModelState.IsValid)
            {
                Category _Cat = RepCat.RemoveCategory(CategoryID);
                if (_Cat != null)
                {
                    TempData["message"] = $"{_Cat.CategoryName} has been deleted";
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
        public ViewResult Create()
        {
           
            return View("Edit", new Category());
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                RepCat.SaveCategory(category);
                TempData["message"] = $"{category.CategoryName} has been saved";
                return RedirectToAction("Index");
            }
            else
            { return View(category); }
        }



    }
}