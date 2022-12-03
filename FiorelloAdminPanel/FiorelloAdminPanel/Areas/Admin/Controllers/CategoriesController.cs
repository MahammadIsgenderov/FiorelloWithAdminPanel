using FiorelloAdminPanel.DAL;
using FiorelloAdminPanel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FiorelloAdminPanel.Areas.Admin.Controllers
{[Area("Admin")]
    public class CategoriesController : Controller
    {
        

        private readonly AppDbContext _db;
        public CategoriesController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _db.Categories.ToListAsync();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool isExist=await _db.Categories.AnyAsync(x=>x.Name==category.Name);
            if (isExist) 
            {
                 ModelState.AddModelError("Name", "taken name.");
                return View();
            }
            
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id,Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool isExist = await _db.Categories.AnyAsync(x => x.Name == category.Name);
            if (isExist)
            {
                ModelState.AddModelError("Name", "taken name.");
                return View();
            }
            Category dbcategory = await _db.Categories.FirstOrDefaultAsync(x => x.Name == category.Name&&x.Id==id);

            dbcategory.Name = category.Name;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Category dbcategory = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (dbcategory==null)
            {
                return BadRequest();
            }
            if (dbcategory.IsDeactive==true)
            {
                dbcategory.IsDeactive = false;
            }
            else
            {
                dbcategory.IsDeactive = true;

            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
