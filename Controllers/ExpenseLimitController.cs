using Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Controllers
{
    public class ExpenseLimitController : Controller
    {
        private readonly EtDbContext _context;

        public ExpenseLimitController(EtDbContext context)
        {
            _context = context;
        }
        // GET: ExpenseLimitController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Expense_Limit.ToListAsync());
        }

        // GET: ExpenseLimitController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: ExpenseLimitController/Add
        public IActionResult Add()
        {
            return View(new ExpenseLimit());
        }

        // POST: ExpenseLimitController/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add([Bind("LimitID,Expense_Limit")] ExpenseLimit limit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(limit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(limit);
        }

        // GET: ExpenseLimitController/Edit
        public IActionResult Edit(int id)
        {
            return View(_context.Expense_Limit.Find(id));
        }

        // POST: ExpenseLimitController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("LimitID,Expense_Limit")] ExpenseLimit limit)
        {
            if (ModelState.IsValid)
            {
                _context.Update(limit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(limit);
        }

        // GET: ExpenseLimitController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: ExpenseLimitController/Edit/5
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

        // GET: ExpenseLimitController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: ExpenseLimitController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
