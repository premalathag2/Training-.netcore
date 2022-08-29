using CG_VAK_BooksWeb.Data;
using CG_VAK_BooksWeb.Migrations;
using CG_VAK_BooksWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CG_VAK_BooksWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _db.Categories;
            return View(categories);
        }

        public IActionResult Create(Category category)
        {
            if(category.Name == category.OrderOfDisplay.ToString())
            {
                ModelState.AddModelError("Custome Error", "Display Name should not be match with Display Order");
            }
            if (ModelState.IsValid)
            {
                var iscategoryExist = _db.Categories.FirstOrDefault(c => c.Name == category.Name || c.OrderOfDisplay == category.OrderOfDisplay);
                if (iscategoryExist != null) {
                    TempData["error"] = "Category / Order of display Exists Already";
                    return RedirectToAction("Index");
                }
                else
                {
                    _db.Categories.Add(category);
                    _db.SaveChanges();
                    TempData["Success"] = "category created succdesfully";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            var category = _db.Categories.Find(id);
            return View(category);
        }
        

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (category.Name == category.OrderOfDisplay.ToString())
            {
                ModelState.AddModelError("Custome Error", "Display Name should not be match with Display Order");
            }
            if (ModelState.IsValid)
            {
                var iscategoryExist = _db.Categories.FirstOrDefault(c => c.Name == category.Name);

                if (iscategoryExist != null)
                {
                    TempData["error"] = "Category / Order of display Exists Already";
                    return RedirectToAction("Index");
                }
                else
                {
                    _db.Categories.Update(category);
                    _db.SaveChanges();
                    TempData["Success"] = "No Changes Detected";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }


        public IActionResult Delete(int? id)
        {
            var category = _db.Categories.Find(id);
            return View(category);
        }
       
        [HttpPost]
        public IActionResult Delete(Category category)
        {

                _db.Categories.Remove(category);
                _db.SaveChanges();                
                return RedirectToAction("Index");
           
        }
    }
}
