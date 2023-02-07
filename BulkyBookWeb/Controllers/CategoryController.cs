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
            // checks if entered info aligns with checks in the model
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
    }
}
