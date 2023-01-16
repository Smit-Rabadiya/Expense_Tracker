using Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Controllers
{
    public class CategoryController : Controller
    {
        private readonly EtDbContext _context;

        public CategoryController(EtDbContext context)
        {
            _context = context;
        }
        // GET: CategoryController
        public async Task<ActionResult> Index()
        {
            return View(await _context.Category.ToListAsync());
        }

        // GET: CategoryController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: CategoryController/AddOREdit
        public IActionResult AddOrEdit(int id=0)
        {
            if (id == 0)
                return View(new Category());
            else
                return View(_context.Category.Find(id));
        }

        // POST: CategoryController/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddOrEdit([Bind("CategoryId,CategoryName,CategoryLimit")] Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.CategoryId == 0)
                {
                    _context.Add(category);
                }
                else
                    _context.Update(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: CategoryController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: CategoryController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // POST: CategoryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Category.FindAsync(id);
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
