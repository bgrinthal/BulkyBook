using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        // implimentation of connection strings and tables to retreive the data
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            // sets local variable to db
            _db = db;
        }

        public IActionResult Index()
        {
            // connect to data, then category, then make list 
            // IEnumerable<Category> defines a collect.  If use just "var" need _db.Categories.ToList()
            IEnumerable<Category> objCategoryList = _db.Categories;
            // Pass to view
            return View(objCategoryList);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            // checks if name is equal to display order, and displays a custom error if true
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                // calling the error "name" adds it to the model property of "Name"
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            // checks if entered info aligns with checks (such as [Required]) in the model
            if (ModelState.IsValid) 
            {
                // connects to db, and adds category object
                _db.Categories.Add(obj);
                _db.SaveChanges();
                // redirects to Index method in category controller
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if(id== null || id==0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            // other methods to find correct id.  These will return dafault if nothing is found (instead of throwing error)
            // var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            // var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if(categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            // checks if name is equal to display order, and displays a custom error if true
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                // calling the error "name" adds it to the model property of "Name"
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            // checks if entered info aligns with checks (such as [Required]) in the model
            if (ModelState.IsValid)
            {
                // connects to db, and adds category object
                _db.Categories.Update(obj);
                _db.SaveChanges();
                // redirects to Index method in category controller
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            // other methods to find correct id.  These will return dafault if nothing is found (instead of throwing error)
            // var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            // var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
                // connects to db, and adds category object
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                // redirects to Index method in category controller
                return RedirectToAction("Index");
            return View(obj);
        }
    }
}
